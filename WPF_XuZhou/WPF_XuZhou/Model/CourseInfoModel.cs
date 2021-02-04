using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_XuZhou.Model
{
    public class CourseInfoModel
    {
        public string title { get; set; }
        public string url { get; set; }

        private string _img { get; set; }
        public string imgurl
        {
            get
            {
                return _img.Length > 0 ? BaseConfig.Host + _img : "";
            }
            set { _img = value; }
        }
    }
}
