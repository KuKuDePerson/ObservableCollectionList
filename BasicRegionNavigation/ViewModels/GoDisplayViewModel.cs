using BasicRegionNavigation.Common;
using BasicRegionNavigation.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace BasicRegionNavigation.ViewModels
{
    public class GoDisplayViewModel : BindableBase
    {
        IContainerExtension _container;
        DataListView _dataListView;
        public Window Wnd { get; set; }
        public DataListView ShowClipView { get => _dataListView; private set => _dataListView = value; }
        public GoDisplayViewModel(IContainerExtension container)
        {
            _container = container;
            _dataListView = _container.Resolve<DataListView>();
            PreResItems = new List<CommonItem>();
            MidResItems = new ObservableCollection<CommonItem>();

            _dataListView.DataContext = this;
            _dataListView.Show();
        }


        public void SetDisplay()
        {
            for (int i = 0; i < 5; i++)
            {
                CommonItem item = new CommonItem();
                item.ID = i.ToString();
                item.Title = "List测试" + i.ToString();
                preResItems.Add(item);
            }

        }

        public void SetMidDisplay()
        {
            for (int i = 0; i < 5; i++)
            {
                CommonItem item = new CommonItem();
                item.ID = i.ToString();
                item.Title = "ObservableCollection测试" + i.ToString();
                midResItems.Add(item);
            }

        }


        private DelegateCommand<object> _addListCommand;
        public DelegateCommand<object> AddListCommand =>
            _addListCommand ?? (_addListCommand = new DelegateCommand<object>(ExecuteAddListCommand));

        void ExecuteAddListCommand(object parameter)
        {
            CommonItem item = new CommonItem();
            item.ID = "1000";
            item.Title = "List测试1000";
            preResItems.Add(item);
        }

        private DelegateCommand<object> _addObservableCollectionCommand;
        public DelegateCommand<object> AddObservableCollectionCommand =>
            _addObservableCollectionCommand ?? (_addObservableCollectionCommand = new DelegateCommand<object>(ExecuteAddObservableCollectionCommand));

        void ExecuteAddObservableCollectionCommand(object parameter)
        {
            CommonItem item = new CommonItem();
            item.ID = "1000";
            item.Title = "List测试1000";
            midResItems.Add(item);
        }

        private List<CommonItem> preResItems;

        /// <summary>
        /// 课前资源
        /// </summary>
        public List<CommonItem> PreResItems
        {
            get
            {
                Debug.WriteLine($"pre res {preResItems.Count}");
                return preResItems;
            }
            set { SetProperty(ref preResItems, value); }
        }

        private ObservableCollection<CommonItem> midResItems;

        /// <summary>
        /// 课前资源
        /// </summary>
        public ObservableCollection<CommonItem> MidResItems
        {
            get
            {
                //Debug.WriteLine($"pre res {midResItems.Count}");
                return midResItems;
            }
            set { SetProperty(ref midResItems, value); }
        }

        private DelegateCommand<object> _showClipLoadedCommand;

        public DelegateCommand<object> ShowClipLoadedCommand =>
            _showClipLoadedCommand ?? (_showClipLoadedCommand = new DelegateCommand<object>(ExecuteLoadedCommand));

        void ExecuteLoadedCommand(object parameter)
        {
            InitWndInfo();
        }

        public void InitWndInfo()
        {
            //子窗口和父窗口联动
            if (this.Wnd != null)
            {

                var container = this.Wnd.Content as FrameworkElement;
                container.SizeChanged += Owner_SizeChanged;
            }
        }
        private void Owner_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //触发：全屏，取消全屏，最大化，还原
            //最小化，还原不会
            ShowClipView.Width = e.NewSize.Width;
            ShowClipView.Height = e.NewSize.Height;
        }
    }
}
