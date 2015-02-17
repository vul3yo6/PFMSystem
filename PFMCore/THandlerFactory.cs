using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMCore
{
    class THandlerFactory
    {
        internal class TZipHandlerFactory
        {
            static public TZipHandler CreateHandler()
            {
                return new TZipHandler();
            }
        }

        internal class TFileHandlerFactory
        {
            static public TFileHandler CreateHandler()
            {
                return new TFileHandler();
            }
        }

        internal class TNullHandlerFactory
        {
            static public TNullHandler CreateHandler()
            {
                return new TNullHandler();
            }
        }

        public THandlerFactory()
        {

        }

        public virtual TPFMHandler CreateHandler(string handler)
        {
            TPFMHandler tpfmHandler = null;

            if (handler == "ZIP")
            {
                tpfmHandler = TZipHandlerFactory.CreateHandler();
            }
            else if (handler == "FILE")
            {
                tpfmHandler = TFileHandlerFactory.CreateHandler();
            }
            else if (handler == "NULL")
            {
                tpfmHandler = TNullHandlerFactory.CreateHandler();
            }
            else
            {
                tpfmHandler = new TPFMHandler();
            }

            return tpfmHandler;
        }
    }
}
