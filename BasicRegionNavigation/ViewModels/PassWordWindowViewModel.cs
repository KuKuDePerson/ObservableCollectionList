using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicRegionNavigation.ViewModels
{
    public class PassWordWindowViewModel : BindableBase
    {
        public PassWordWindowViewModel()
        {

        }
        private string _textPassWord;
        public string TextPassWord
        {
            get { return _textPassWord; }
            set { SetProperty(ref _textPassWord, value); }
        }
        private DelegateCommand<object> _loginVerifyCommond;
        public DelegateCommand<object> LoginVerifyCommond =>
            _loginVerifyCommond ?? (_loginVerifyCommond = new DelegateCommand<object>(ExecuteLoginVerifyChangedCommand));

        void ExecuteLoginVerifyChangedCommand(object parameter)
        {
            var UserPwd = TextPassWord;
            var UserPwd1 = _textPassWord;
        }
    }
}
