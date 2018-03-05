using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIDS_SerCon
{
    static public class Setting
    {
        static public string Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
                ReSer();
            }
        }
        static public bool RTS
        {
            get
            {
                return rts;
            }
            set
            {
                rts = value;
                ReSer();
            }
        }
        static public bool DTR
        {
            get
            {
                return dtr;
            }
            set
            {
                dtr = value;
                ReSer();
            }
        }
        static public bool NextDo
        {
            get
            {
                return nextdo;
            }
            set
            {
                nextdo = value;
            }
        }
        static public bool MsgShow
        {
            get
            {
                return msgshow;
            }
            set
            {
                msgshow = value;
            }
        }
        static public bool GIPI
        {
            get
            {
                return gipi;
            }
            set
            {
                gipi = value;
            }
        }

        static private bool msgshow = true;
        static private string port = "COM5";
        static private bool rts = false;
        static private bool dtr = false;
        static private bool nextdo = true;
        static private bool gipi = false;
        static private void ReSer()
        {
            /*if (Serial.TF == true)
            {
                Serial.End();
            }
            Serial.Start(Port);*/
        }
    }
}
