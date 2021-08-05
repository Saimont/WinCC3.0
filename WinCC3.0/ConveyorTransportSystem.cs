using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCC3._0 {
    class ConveyorTransportSystem {


        Dictionary<int, Position> positions;

        public Dictionary<int, Position> Positions {
            get { return positions; }
        }

        private ConveyorTransportSystem() {
            positions = new Dictionary<int, Position>();
        }

        private static ConveyorTransportSystem _instance;

        public static ConveyorTransportSystem GetInstance() {
            if (_instance == null) {
                _instance = new ConveyorTransportSystem();
            }
            return _instance;
        }
    }


}
