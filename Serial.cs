using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows;
using System.IO;

namespace BIDS_SerCon
{
    static public class Serial
    {
        static private SerialPort SP = new SerialPort();
        static public bool TF;
        static public bool Start(string port)
        {
            if (SP.IsOpen != true)
            {
                try
                {
                    SP.RtsEnable = Setting.RTS;
                    SP.DtrEnable = Setting.DTR;
                    SP.BaudRate = 115200;
                    SP.PortName = port;
                    SP.ReadTimeout = 10 * 1000;
                    SP.NewLine = "\n";
                    SP.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Port Open Error | BIDS-SerCon", MessageBoxButton.OK, MessageBoxImage.Error);
                    TF = false;
                    return false;
                }
            }
            else
            {
                MessageBox.Show("既存のポートが閉じられていません。", "Port Open Error | BIDS-SerCon", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            TF = true;
            return true;
        }
        static public string Get()
        {
            if (SP.IsOpen == true)
            {
                try
                {
                    return SP.ReadLine();
                }
                catch(InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Serial Sending Error | BIDS-SerCon", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                catch (TimeoutException ex)
                {
                    return null;
                }
            }
            else
            {
                MessageBox.Show("ポートが開いていません。", "Serial Error | BIDS-SerCon", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        static private bool Send(string str)
        {
            if (SP.IsOpen == true)
            {
                try
                {
                    SP.WriteLine(str);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Serial Sending Error | BIDS-SerCon", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("ポートが開いていません。", "Serial Error | BIDS-SerCon", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        static public bool End()
        {
            if (SP.IsOpen == true)
            {
                try
                {
                    SP.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Port Close Error | BIDS-SerCon", MessageBoxButton.OK, MessageBoxImage.Error);
                    TF = SP.IsOpen;
                    return false;
                }
            }
            TF = false;
            return true;
        }


        static public void ReStart()
        {
            if (TF == true)
            {
                End();
            }
            Start(Setting.Port);
        }

    }
}
