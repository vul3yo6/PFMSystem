using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PFMCore
{
    public class TPFMConfigManager
    {
        private List<TPFMConfig> configs;
        private XmlTextReader xmlReader;
        private static string FConfigFile = "PFM-Config.XML";

        public TPFMConfigManager(string configFile)
        {
            if (!string.IsNullOrEmpty(configFile))
            {
                FConfigFile = configFile;
            }

            configs = new List<TPFMConfig>();
        }

        public int Count { get { return GetConfigCount(); } }

        private int GetConfigCount()
        {
            return configs.Count;
        }

        public bool ProcessConfigs()
        {
            try
            {
                try
                {
                    LoadPFMFile(FConfigFile);
                    configs.Clear();
                    while (true)
                    {
                        TPFMConfig config = GetNextConfig();

                        if (config != null)
                        {
                            configs.Add(config);
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
            catch (ENoConfigFileException)
            {
                return false;
            }
            return true;
        }

        private TPFMConfig GetItem(int index)
        {
            if (index < Count)
            {
                return configs[index] as TPFMConfig;
            }

            return null;
        }

        public TPFMConfig this[int index] { get { return GetItem(index); } }

        protected XmlTextReader CreateXmlReader()
        {
            xmlReader = new XmlTextReader(FConfigFile);
            return xmlReader;
        }

        protected void LoadPFMFile(string fileName)
        {
            string xmlFile = System.IO.Path.Combine("..\\", fileName);

            if (System.IO.File.Exists(xmlFile))
            {
                CreateXmlReader();
            }
            else
            {
                throw new ENoConfigFileException();
            }
        }

        public List<TPFMConfig> GetConfigs()
        {
            return configs;
        }

        public TPFMConfig GetNextConfig()
        {
            string ext = string.Empty;
            string location = string.Empty;
            string subdirectory = string.Empty;
            string fUnit = string.Empty;
            string remove = string.Empty;
            string handler = string.Empty;
            string destination = string.Empty;
            string dir = string.Empty;
            string connectString = string.Empty;

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType.Equals(XmlNodeType.Element))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType.Equals(XmlNodeType.Element))
                        {
                            if (xmlReader.Name.Equals("EXT"))
                            {
                                ext = xmlReader.ReadElementContentAsString();
                                continue;
                            }
                            else if (xmlReader.Name.Equals("LOCATION"))
                            {
                                location = xmlReader.ReadElementContentAsString();
                                continue;
                            }
                            else if (xmlReader.Name.Equals("SUBDIRECTORY"))
                            {
                                subdirectory = xmlReader.ReadElementContentAsString();
                                continue;
                            }
                            else if (xmlReader.Name.Equals("UNIT"))
                            {
                                fUnit = xmlReader.ReadElementContentAsString();
                                continue;
                            }
                            else if (xmlReader.Name.Equals("REMOVE"))
                            {
                                remove = xmlReader.ReadElementContentAsString();
                                continue;
                            }
                            else if (xmlReader.Name.Equals("HANDLER"))
                            {
                                handler = xmlReader.ReadElementContentAsString();
                                continue;
                            }
                            else if (xmlReader.Name.Equals("DESTINATION"))
                            {
                                destination = xmlReader.ReadElementContentAsString();
                                continue;
                            }
                            else if (xmlReader.Name.Equals("DIR"))
                            {
                                dir = xmlReader.ReadElementContentAsString();
                                continue;
                            }
                            else if (xmlReader.Name.Equals("CONNECTIONSTRING"))
                            {
                                connectString = xmlReader.ReadElementContentAsString();
                                break;
                            }
                        }
                    }

                    return new TPFMConfig(ext, location, subdirectory, fUnit, remove, handler, destination, dir, connectString);
                }
            }

            return null;
        }
    }
}
