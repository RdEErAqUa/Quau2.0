using Quau2._0.ViewModels;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Quau2._0.Services;
using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.Services.WorkDataFile;
using Quau2._0.ViewModels.MenuViewModels;
using Quau2._0.Views.UserControls.Menu;
using Quau2._0.ViewModels.PreviewViewModels;
using Quau2._0.Views.Windows.PreviewWindows;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices;
using Quau2._0.Services.Interfaces;
using Quau2._0.ViewModels.DataViewModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService;
using Quau2._0.Services.SeriesServices.OneDimServices.Interfaces;
using Quau2._0.Services.SeriesServices.OneDimServices;

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
            displayRootRegistry.RegisterWindowType<PreviewViewModel, PreviewWindow>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOneDimensionalConvertService, OneDimensionalConvertService>();
            services.AddScoped<ITwoDimensionalConvertService, TwoDimensionalConvertService>();
            services.AddTransient<ISaveDialogService, SaveDialogService>();
            services.AddTransient<IReadDataService, ReadDataService>();
            //Сервис первичного статистического анализа
            services.AddTransient<IVariationSeriesService, VariationSeriesService>();
            services.AddTransient<IClassSizeService, ClassSizeService>();
            services.AddTransient<IPercentageSeriesService, PercentageSeriesService>();
            services.AddTransient<IPrimaryStatisticAnalysisService, PrimaryStatisticAnalysisService>();
            //Сервис графиков
            services.AddTransient<IPrimaryAnalysisSeriesService, PrimaryAnalysisSeriesService>();
            //Сервис мульти-привязки команд
            services.AddTransient<IMultipleBindingCommand, MultipleBindingCommand>();
            //Сервис Превью модели
            services.AddTransient<PreviewViewModel>();
            //
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<DataViewModel>();
            services.AddSingleton<DisplayDataViewModel>();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await displayRootRegistry.ShowModalPresentation(_serviceProvider.GetService<MainViewModel>());

            Shutdown();
        }
    }
}
