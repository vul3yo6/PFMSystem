using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMCore
{
    class TPFMConfig
    {
        public TPFMConfig(string ext, string location,
            string subdirectory, string fUnit,
            string remove, string handler,
            string destination, string dir,
            string connectString)
        {
            this.Ext = ext;
            this.Location = location;
            this.Subdirectory = subdirectory;
            this.FUnit = fUnit;
            this.Remove = remove;
            this.Handler = handler;
            this.Destunation = destination;
            this.DIR = dir;
            this.ConnectString = connectString;
        }

        public string Ext { get; private set; }
        public string Location { get; private set; }
        public string Subdirectory { get; private set; }
        public string FUnit { get; private set; }
        public string Remove { get; private set; }
        public string Handler { get; private set; }
        public string Destunation { get; private set; }
        public string DIR { get; private set; }
        public string ConnectString { get; private set; }
    }
}
