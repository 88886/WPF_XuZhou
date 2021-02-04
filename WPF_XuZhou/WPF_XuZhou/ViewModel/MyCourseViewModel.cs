using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DMSkin.Core;
using HandyControl.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        static string regexvideostr = "<li class=\"\"><a href=\"#\" vid=['\"]*(\\S+)[\"'] vurl=['\"]*(\\S+)[\"'] vtype=\"1\" class=['\"]*(\\S+)[\"'] lastpoint=['\"]*(\\S+)[\"']>(.*?)<";

        #region 方法
        static string GetStudyInfo(string html)
        {
            string str = "study=(.*?);";
            Regex regex = new Regex(str);
            return regex.Match(html).Groups[1].Value;

        }
        #endregion

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
        /// <summary>
        /// 学习或者暂停
        /// </summary>
        public ICommand LearnOrStopCommond => new DelegateCommand(obj =>
        {
            if (NowLearnCourse != null && NowLearnCourse.IsLearnNow)
            {
                Growl.Info("当前有项目正在学习,请暂停其他课程后再开启本课程！");
                return;
            }
            NowLearnCourse.IsLearnNow = !NowLearnCourse.IsLearnNow;
            OnPropertyChanged(nameof(BorderText));
            if (NowLearnCourse.IsLearnNow == false) return;
            /*下方代码表示要开始学习了*/
            Message = "正在获取待学视频...";
            tasklearnvideo= new Task(() =>
            {
                CourseInfo.ForEach(x =>
                {
                    if (x.DProgress >= 100) return;
                    string onlineVideo = WebHelper.Get(BaseConfig.Host + "/" + x.url).Html;
                    string studyjson = GetStudyInfo(onlineVideo);
                    var videomatchs = Regex.Matches(onlineVideo, regexvideostr);
                    foreach (Match match in videomatchs)
                    {

                        string videoId = match.Groups[1].Value;
                        string videoname = match.Groups[5].Value;
                        Message = $"正在学习视频{videoname}";
                        int videoprogress = Convert.ToInt32(match.Groups[4].Value);
                        int videolength = Convert.ToInt32(videoprogress * x.DProgress);
                        decimal dpercent = x.DProgress;
                        decimal doldprogress = dpercent;
                        string videoinit = WebHelper.Post(BaseConfig.Host + "/ajax/video.asp", "video_id=" + videoId).Html;
                        while (dpercent < 100)
                        {
                            Console.WriteLine("正在学习" + videoname);
                            servervideo jstudy = JsonConvert.DeserializeObject<servervideo>(studyjson);
                            jstudy.curVideo = Convert.ToInt32(videoId);
                            jstudy.curPoint = videolength;
                            string sdata = $"platid={jstudy.platid}&gcid={jstudy.gcid}&kcid={jstudy.kcid}&kjid={jstudy.kjid}&st={jstudy.st}&chcode={jstudy.chcode}&v={jstudy.v}&curVideo={videolength}&curPoint={videolength}";

                            string learn_server = WebHelper.Post(BaseConfig.Host + "/learn_server.asp", sdata).Html;
                            JObject jlearn = JObject.Parse(learn_server);
                            int state = Convert.ToInt32(jlearn["state"]);
                            if (state == 1)
                            {
                                string jnPostData = WebHelper.Post(BaseConfig.Host + "/api/jnPostData.asp", "gcid=" + jstudy.gcid).Html;
                            }
                            dpercent = Convert.ToDecimal(jlearn["percent"].ToString().Replace("%", ""));
                            int dstudy = Convert.ToInt32((dpercent - doldprogress) * videolength) / 60;
                            Console.WriteLine("当前进度:" + dpercent + "相当于学习了:" + dstudy + "秒");
                            NowVideoProgress = dpercent;
                            Thread.Sleep(250000);
                            doldprogress = dpercent;
                        }
                    }
                });

            });
            tasklearnvideo.Start();


        });

        public ICommand OpenCourseCommond => new DelegateCommand(obj =>
        {
            var cmodel = obj as MyCourseModel;
            if (cmodel == null) return;
            NowLearnCourse = cmodel;
            PageIndex = 2;
            var mycourse = WebHelper.Get(BaseConfig.Host + "/" + cmodel.CourseUrl).Html;
            var coursematchs = Regex.Matches(mycourse, regexCourse);
            List<CourseInfoModel> clist = new List<CourseInfoModel>();
            foreach (Match m in coursematchs)
            {
                clist.Add(new CourseInfoModel()
                {
                    title = m.Groups[1].Value,
                    url = m.Groups[2].Value,
                    imgurl = m.Groups[3].Value,
                    progress = m.Groups[7].Value,
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
        Task tasklearnvideo;
        static MyCourseModel NowLearnCourse = new MyCourseModel();//当前学习的课程
        static int PageIndex = 1;
        private string _message = "正在学习";

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private decimal _nowVideoProgress = 0m;

        public decimal NowVideoProgress
        {
            get { return _nowVideoProgress; }
            set
            {
                _nowVideoProgress = value;
                OnPropertyChanged(nameof(NowVideoProgress));
            }
        }


        /// <summary>
        /// 播放暂停开关
        /// </summary>
        public string BorderText
        {
            get
            {
                if (NowLearnCourse == null || NowLearnCourse.IsLearnNow == false)
                {
                    return "\uea8d";
                } else
                {
                    /*暂停*/
                    //tasklearnvideo.Cancel();//暂停上一个task
                    return "\ue6fc";
                }       
            }
        }

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
            get
            {
                return _courseinfo;
            }
            set
            {
                _courseinfo = value;
            }
        }

        public Visibility ShowCourse
        {
            get
            {
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
