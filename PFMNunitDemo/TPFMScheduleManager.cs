using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PFMNunitDemo
{
    class TPFMScheduleManager
    {
        private List<TPFMSchedule> schedules;

        public TPFMScheduleManager(string scheduleFile)
        {
            schedules = new List<TPFMSchedule>();
        }

        public TPFMSchedule GetNextSchedule()
        {
            TPFMSchedule schedule = null;

            if (schedules.Count < 2)
            {
                schedule = new TPFMSchedule("tst", "18:00", "Everday");
            }

            return schedule;
        }

        private int GetScheduleCount()
        {
            return schedules.Count;
        }

        public TPFMSchedule GetSchedule(int index)
        {
            TPFMSchedule schedule = null;

            if (index < schedules.Count)
            {
                schedule = schedules[index] as TPFMSchedule;
            }

            return schedule;
        }

        public List<TPFMSchedule> GetSchedules()
        {
            return null;
        }

        public void ProcessSchedules()
        {
            TPFMSchedule schedule = null;
            try
            {
                LoadScheduleFile();
                while (true)
                {
                    schedule = GetNextSchedule();
                    if (schedule != null)
                    {
                        schedules.Add(schedule);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            finally
            {
                CloseScheduleFile();
            }
        }

        private void CloseScheduleFile()
        {
            //throw new NotImplementedException();
        }

        private void LoadScheduleFile()
        {
            //throw new NotImplementedException();
        }

        public int Count { get { return GetScheduleCount(); } }

        public TPFMSchedule GetItem(int index)
        {
            return GetSchedule(index);
        }
    }
}
