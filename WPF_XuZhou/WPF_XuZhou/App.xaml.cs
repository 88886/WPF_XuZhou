using DMSkin.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_XuZhou
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            /*注册调度-广播-存储器 使用方法请百度DMSkin*/
            UIExecute.Initialize();
            Broadcast.Initialize();
            Storage.Initialize();
           
        }
    }
}
