using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCC3._0 {
    class Position {
        int destination;
        int trpId;
        int type;

        public int Destination {
            get { return destination;}
            set { destination = value;}
        }

        public int TrpId {
            get { return trpId; }
            set { trpId = value; }
        }

        public int Type {
            get { return type; }
            set { type = value; }
        }
    }


}
