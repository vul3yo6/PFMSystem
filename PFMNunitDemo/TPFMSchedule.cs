using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMNunitDemo
{
    class TPFMSchedule
    {
        public TPFMSchedule(string ext, string sTime, string interval)
        {
            this.Ext = ext;
            this.STime = sTime;
            this.Interval = interval;
        }

        public string Ext { get; set; }

        public string STime { get; set; }

        public string Interval { get; set; }
    }
}
