using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DMSkin.Core;
using WPF_XuZhou.View;

namespace WPF_XuZhou
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.framemain.Navigate(new LoginView());
            Init();
        }

        /// <summary>
        /// 注册页面跳转
        /// </summary>
        void Init()
        {
            Broadcast.RegisterBroadcast<Page>("frameNavigation", obj =>
            {
                framemain.Navigate(obj);
            });
        }
    }
}
