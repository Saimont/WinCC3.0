using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;

namespace WinCC3._0 {
    class QueryPLC {

        private S7Client plc1 = null;
        private S7Client plc2 = null;
        private S7Client plc3 = null;

        private QueryPLC() { }

        private static QueryPLC _instance;

        public static QueryPLC GetInstance() {
            if (_instance == null) {
                _instance = new QueryPLC();
            }
            return _instance;
        }

        public void Disconnect() {
            if (plc1 != null)
                plc1.Disconnect();
            if (plc2 != null)
                plc2.Disconnect();
            if (plc3 != null)
                plc3.Disconnect();
        }

        public Byte[] FetchDB(int db, uint startpos, uint length) {
            if (startpos == 0 && length == 0) {
                byte[] data = new byte[240 * 5];
                byte[] temp = new byte[240];
                //int result = plc1.DBRead(20, 0, 500, data);
                plc1.ConnTimeout = 400;
                for (int i = 0; i < 5; i++) {
                    int result = plc1.ReadArea(S7Consts.S7AreaDB, db, 200 + (240 * i), 240, S7Consts.S7WLByte, temp);
                    //int result = plc1.DBGet(20, data, ref size);
                    if (result != 0) {
                        Console.WriteLine("Error: " + plc1.ErrorText(result));
                        //TODO IMPLEMENT ERROR HANDING IF CONNECTION FAILS
                        return null;
                    }
                    temp.CopyTo(data, 240 * i);
                }
                return data;
            }
            return null;
        }

        public bool Connect() {
            plc1 = new S7Client();
            plc1.SetConnectionType(0x02);
            int result = plc1.ConnectTo("10.57.31.196", 0, 3);
            if (result != 0) {
                Console.WriteLine("Error: " + plc1.ErrorText(result));

                return false;
            }
            return true;
        }


    }
}
