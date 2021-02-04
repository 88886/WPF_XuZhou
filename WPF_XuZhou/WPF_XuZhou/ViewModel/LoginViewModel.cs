using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using DMSkin.Core;
using HandyControl.Controls;
using WPF_XuZhou.View;

namespace WPF_XuZhou.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {


        #region 事件
        public ICommand LoginCommond => new DelegateCommand(obj =>
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                Growl.Error("账号或密码不能为空！");
                return;
            }
            var loginresult = WebHelper.Post($"{BaseConfig.Host}/member_login.asp?platID={BaseConfig.platID}", $"loginname={name}&password={password}&submit=%B5%C7+%C2%BD");
            if (loginresult.Html.Contains("alert"))
            {
                Regex regex = new Regex("alert['\"]*(\\S+)[\"'];");
                string alert = TextHelper.DeUnicode(regex.Match(loginresult.Html).Groups[1].Value.Replace("(", "").Replace(")", "").Replace("'", ""));
                Growl.Error(alert);
                return;
            }
            WebHelper.UserCookie = loginresult.Cookie;
            Growl.Success("登录成功,正在跳转！");
            Broadcast.PushBroadcast("frameNavigation", new MyCourseView());
        });

        #endregion

        #region 属性
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        #endregion
    }
}
