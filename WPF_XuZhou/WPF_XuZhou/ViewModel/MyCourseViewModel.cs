using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DMSkin.Core;
using HandyControl.Controls;
using WPF_XuZhou.Model;

namespace WPF_XuZhou.ViewModel
{
    public class MyCourseViewModel : ViewModelBase
    {
        static string regexName = "<li class=\"l1\"><p><a href=['\"]*(\\S+)[\"']>(.*?)</a></p></li>";
        static string regexButton = "<a href=['\"]*(\\S+)[\"'] class=\"layui-btn layui-btn-sm \">(.*?)</a>";
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
                    CourseName = matchsname[a].Groups[2].Value,
                    CourseUrl= matchsbutton[a].Groups[1].Value,
                    Progress=Convert.ToDecimal(sprogress)
                });
            }
            OnPropertyChanged(nameof(MyCourseList));
            if (MyCourseList.Count <= 0)
            {
                Growl.Info("没有找到课程！");
            }
        }



        #region 属性
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
        #endregion
    }
}
