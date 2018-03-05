using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BIDS_SerCon
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterB(object sender, RoutedEventArgs e)
        {
            Setting.Port = COMPortBox.SelectedItem.ToString();
            Setting.DTR = (bool)DTR.IsChecked;
            Setting.RTS = (bool)RTS.IsChecked;
            Setting.NextDo = (bool)UsualTF.IsChecked;
            Setting.MsgShow = (bool)MessageTF.IsChecked;
            Setting.GIPI = (bool)GIPITF.IsChecked;
            Serial.ReStart();
            Close();
        }

        private void CancelB(object sender, RoutedEventArgs e)
        {
            Close();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private void MoveDo(object sender, MouseButtonEventArgs e)
        {
            //参考:https://techracho.bpsinc.jp/baba/2009_12_09/731
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            PostMessage(hwnd, 0xA1, (IntPtr)2, IntPtr.Zero);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            IPAddr.Content = "IPアドレス：" + "127.0.0.1";
            PortNum.Content = "ポート番号：" + "8501";
            COMPortBox.Items.Refresh();
            for(int i = 0; i < 256; i++)
            {
                COMPortBox.Items.Add("COM"+i.ToString());
            }
            COMPortBox.SelectedItem = Setting.Port;
            DTR.IsChecked = Setting.DTR;
            RTS.IsChecked = Setting.RTS;
            UsualTF.IsChecked = Setting.NextDo;
            MessageTF.IsChecked = Setting.MsgShow;
            GIPITF.IsChecked = Setting.GIPI;
        }
    }
}
