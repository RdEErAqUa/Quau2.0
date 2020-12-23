using Quau2._0.ViewModels;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Quau2._0.Services;
using Quau2._0.Services.Interfaces;
using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.Services.WorkDataFile;

namespace Quau2._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();

        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            displayRootRegistry.RegisterWindowType<MainViewModel, MainWindow>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOneDimensionalConvertService, OneDimensionalConvertService>();
            services.AddScoped<ITwoDimensionalConvertService, TwoDimensionalConvertService>();
            services.AddTransient<ISaveDialogService, SaveDialogService>();
            services.AddTransient<IReadDataService, ReadDataService>();

            services.AddSingleton<MainViewModel>();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await displayRootRegistry.ShowModalPresentation(_serviceProvider.GetService<MainViewModel>());

            Shutdown();
        }
    }
}
