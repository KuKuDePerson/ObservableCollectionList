using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicRegionNavigation.Common
{
    public class CommonItem : BindableBase
    {

        private string id;
        public string ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

    }
}
