using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;

namespace BT_connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BluetoothAddress addr; //用於識別一個獨特的藍芽裝置的地址
        BluetoothEndPoint ep;  //代表一個設備上的藍芽服務(端點)
        BluetoothClient cli;  //藍芽用戶端
        BluetoothAddress[] MACs;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void scan_bt_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            MACs = new BluetoothAddress[devices.Length];

            textBox1.Text = "";

            foreach (BluetoothDeviceInfo device in devices)
            {
                textBox1.Text += device.DeviceName + "\r\n";
                textBox1.Text += string.Format("MAC address: {0}",device.DeviceAddress) + "\r\n";
            }
            Cursor = Cursors.Arrow;
        }
    }
}
