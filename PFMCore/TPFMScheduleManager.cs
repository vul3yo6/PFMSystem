using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PFMCore
{
    public class TPFMScheduleManager
    {
        private List<TPFMSchedule> schedules;
        private XmlTextReader xmlReader;
        private static string FScheduleFile = "PFM-Schedule.XML";

        public TPFMScheduleManager(string scheduleFile)
        {
            if (!string.IsNullOrEmpty(scheduleFile))
            {
                FScheduleFile = scheduleFile;
            }

            schedules = new List<TPFMSchedule>();
        }

        public TPFMSchedule GetNextSchedule()
        {
            string ext = string.Empty;
            string sTime = string.Empty;
            string interval = string.Empty;

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType.Equals(XmlNodeType.Element))
                {
                    if (xmlReader.LocalName.Equals("Schedule"))
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType.Equals(XmlNodeType.Element))
                            {
                                if (xmlReader.Name.Equals("Time"))
                                {
                                    sTime = xmlReader.ReadElementContentAsString();
                                    continue;
                                }
                                else if (xmlReader.Name.Equals("Interval"))
                                {
                                    interval = xmlReader.ReadElementContentAsString();
                                    break;
                                }
                                else
                                {
                                    ext = xmlReader.ReadElementContentAsString();
                                }
                            }
                        }

                        return new TPFMSchedule(ext, sTime, interval);
                    }
                }
            }

            return null;
        }

        private int GetScheduleCount()
        {
            return schedules.Count;
        }

        public List<TPFMSchedule> GetSchedules()
        {
            return schedules;
        }

        public bool ProcessSchedules()
        {
            try
            {
                try
                {
                    LoadPFMFile(FScheduleFile);
                    schedules.Clear();
                    while (true)
                    {
                        TPFMSchedule schedule = GetNextSchedule();

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
                    xmlReader.Close();
                }
            }
            catch (ENoScheduleFileException)
            {
                return false;
            }
            return true;
        }

        public int Count { get { return GetScheduleCount(); } }

        private TPFMSchedule GetItem(int index)
        {
            if (index < Count)
            {
                return schedules[index] as TPFMSchedule;
            }

            return null;
        }

        public TPFMSchedule this[int index] { get { return GetItem(index); } }

        protected XmlTextReader CreateXmlReader()
        {
            xmlReader = new XmlTextReader(FScheduleFile);
            return xmlReader;
        }

        protected void LoadPFMFile(string fileName)
        {
            string xmlFile = fileName;

            if (System.IO.File.Exists(xmlFile))
            {
                CreateXmlReader();
            }
            else
            {
                throw new ENoScheduleFileException();
            }
        }
    }
}
