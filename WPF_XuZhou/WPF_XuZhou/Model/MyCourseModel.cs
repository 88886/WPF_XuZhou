using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_XuZhou.Model
{
    public class MyCourseModel
    {
        public bool IsLearnNow { get; set; }
        public string CourseName { get; set; }
        public string CourseUrl { get; set; }
        public decimal Progress { get; set; }

        private string _indexphpto = "";
        public string IndexPhoto
        {
            get
            {
                return _indexphpto.Length > 0 ? BaseConfig.Host + _indexphpto : "";
            }
            set
            {
                _indexphpto = value;
            }
        }
    }
}
