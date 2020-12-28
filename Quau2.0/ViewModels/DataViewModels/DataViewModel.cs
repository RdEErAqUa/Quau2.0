﻿using GongSolutions.Wpf.DragDrop;
using Quau2._0.Infrastructure.Commands;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Quau2._0.ViewModels.DataViewModels
{
    class DataViewModel : ViewModel, IDropTarget
    {
        /// <summary>
        /// Поле для хранения главного окна
        /// </summary>
        private MainViewModel _MainViewModel;

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - коллекция одномерных выборок
        private ObservableCollection<OneDimClusterModel> _OneDimClusterModels;
        /// <summary>
        /// Коллекция кластеров одномерных выборок
        /// </summary>
        public ObservableCollection<OneDimClusterModel> OneDimClusterModels { get => _OneDimClusterModels; set => Set(ref _OneDimClusterModels, value); }
        #endregion

        #region TwoDimensionalModels : ObservableCollection<TwoDimensionalModel> - коллекция одномерных выборок
        private ObservableCollection<TwoDimensionalModel> _TwoDimensionalModels;
        /// <summary>
        /// Коллекция одномерных выборок
        /// </summary>
        public ObservableCollection<TwoDimensionalModel> TwoDimensionalModels { get => _TwoDimensionalModels; set => Set(ref _TwoDimensionalModels, value); }
        #endregion

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - Класс выборок, который используются
        private ObservableCollection<OneDimensionalModel> _OneDimensionalModels;
        /// <summary>
        /// Класс выборок, который используются
        /// </summary>
        public ObservableCollection<OneDimensionalModel> OneDimensionalModels { get => _OneDimensionalModels; set => Set(ref _OneDimensionalModels, value); }
        #endregion


        #region

        #endregion

        #region DragOver and Drop - для перетаскивания элементов
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dropInfo"></param>
        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is OneDimensionalModel or OneDimClusterModel)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is OneDimensionalModel)
            {
                OneDimensionalModel Data = (OneDimensionalModel)dropInfo.Data;
                if (!OneDimensionalModels.Contains(Data))
                    OneDimensionalModels.Add(Data);
            }
            else if(dropInfo.Data is OneDimClusterModel)
            {
                OneDimClusterModel Data = (OneDimClusterModel)dropInfo.Data;
                foreach(var el in Data.OneDimensionalModels)
                    if (!OneDimensionalModels.Contains(el))
                        OneDimensionalModels.Add(el);
            }
        }
        #endregion

        /// <summary>
        /// Функция, для установки главного окна
        /// </summary>
        /// <param name="_MainViewModel">Ссылка на главное окно</param>
        public void SetMainViewModel(MainViewModel _MainViewModel)
        {
            this._MainViewModel = _MainViewModel;
        }

        /// <summary>
        /// Конструктор модели для конструктора VisualStudio
        /// </summary>
        public DataViewModel()
        {

        }
        /// <summary>
        /// Конструктор модели для DependencyInjection
        /// </summary>
    }
}
