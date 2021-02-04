using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DMSkin.Core;
using HandyControl.Controls;
using WPF_XuZhou.Model;

namespace WPF_XuZhou.ViewModel
{
    public class MyCourseViewModel : ViewModelBase
    {
        /// <summary>
        /// 正则匹配
        /// </summary>
        static string regexName = "<a href=['\"]*(\\S+)[\"']><img src=['\"]*(\\S+)[\"'] alt=['\"]*(\\S+)[\"'] class=\"themePic\"></a>";
        static string regexButton = "<a href=['\"]*(\\S+)[\"'] class=\"layui-btn layui-btn-sm \">(.*?)</a>";
        static string regexCourse = "<li title=['\"]*(\\S+)[\"']><a href=['\"]*(\\S+)[\"']><img src=['\"]*(\\S+)[\"']></a><p><a href=['\"]*(\\S+)[\"'] class=\"kj_title layui-elip\">(.*?)</a></p><div class=['\"]*(\\S+)[\"']><p>(.*?)</p></div></li>";


        public MyCourseViewModel()
        {
            var mycourseresult = WebHelper.Get(BaseConfig.Host + "/myCourses.asp").Html;
            var matchsname = Regex.Matches(mycourseresult, regexName);
            var matchsbutton = Regex.Matches(mycourseresult, regexButton);
            for (int a = 0; a < matchsbutton.Count; a++)
            {
                string sprogress = TextHelper.Between(matchsbutton[a].Groups[2].Value, "（", "%");
                MyCourseList.Add(new MyCourseModel
                {
                    IndexPhoto = matchsname[a].Groups[2].Value,
                    CourseName = matchsname[a].Groups[3].Value,
                    CourseUrl = matchsbutton[a].Groups[1].Value,
                    Progress = Convert.ToDecimal(sprogress)
                });
            }
            OnPropertyChanged(nameof(MyCourseList));
            if (MyCourseList.Count <= 0)
            {
                Growl.Info("没有找到课程！");
            }
        }

        #region 行为
        public ICommand OpenCourseCommond => new DelegateCommand(obj =>
        {
            var cmodel = obj as MyCourseModel;
            if (cmodel == null) return;


            PageIndex = 2;
            var mycourse = WebHelper.Get(BaseConfig.Host + "/" + cmodel.CourseUrl).Html;
            var coursematchs = Regex.Matches(mycourse, regexCourse);           
            List<CourseInfoModel> clist = new List<CourseInfoModel>();
            foreach (Match m in coursematchs)
            {
                clist.Add(new CourseInfoModel()
                {
                    title= m.Groups[1].Value,
                    url= m.Groups[2].Value,
                    imgurl= m.Groups[3].Value,

                });
            }
            CourseInfo = clist;
            OnPropertyChanged(nameof(CourseInfo));
            OnPropertyChanged(nameof(ShowCourse));
            OnPropertyChanged(nameof(ShowCourseInfo));
        });
        public ICommand ShowPageHome => new DelegateCommand(obj =>
        {
            PageIndex = 1;
            OnPropertyChanged(nameof(ShowCourse));
            OnPropertyChanged(nameof(ShowCourseInfo));
        });
        #endregion

        #region 属性
        static int PageIndex = 1;

        /// <summary>
        /// 我的课程
        /// </summary>
        private List<MyCourseModel> _mycoursemodel = new List<MyCourseModel>();
        public List<MyCourseModel> MyCourseList
        {
            get { return _mycoursemodel; }
            set
            {
                _mycoursemodel = value;
            }
        }

        /// <summary>
        /// 课程信息
        /// </summary>

        private List<CourseInfoModel> _courseinfo = new List<CourseInfoModel>();

        public List<CourseInfoModel> CourseInfo
        {
            get { 
                return _courseinfo;
            }
            set {
                _courseinfo = value; 
            }
        }

        public Visibility ShowCourse
        {
            get {
                return PageIndex == 1 ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public Visibility ShowCourseInfo
        {
            get
            {
                return PageIndex == 2 ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        #endregion
    }
}
