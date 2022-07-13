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
using System.IO;
using System.Diagnostics;

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
        BluetoothClient client;  //藍芽用戶端
        BluetoothAddress[] MACs;
        BluetoothListener bluetoothListener;
        string data;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        private void scan_bt_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            MACs = new BluetoothAddress[devices.Length];

            textBox1.Text = "";

            comboBox1.Items.Clear();
            int i = 0;
            foreach (BluetoothDeviceInfo device in devices)
            {
                textBox1.Text += device.DeviceName + "\r\n";
                textBox1.Text += string.Format("MAC address: {0}",device.DeviceAddress) + "\r\n";
                comboBox1.Items.Add(string.Format("{0}: {1}", device.DeviceName, device.DeviceAddress));
                MACs[i++] = device.DeviceAddress;
            }
            comboBox1.SelectedIndex = 0;
            Cursor = Cursors.Arrow;
        }

        Guid serviceClass;
        int index;
        private void ConnectBT() 
        {
            index = comboBox1.FindString(comboBox1.Text);
            comboBox1.SelectedIndex = index;
            serviceClass = BluetoothService.SerialPort; //BluetoothService.Handsfree;  
            addr = MACs[comboBox1.SelectedIndex];
            Debug.Print("Yes");

            client.Connect(addr, serviceClass);
            Receiving_date();
        }

        private void Receiving_date() 
        {
            bluetoothListener = new BluetoothListener(serviceClass);
            bluetoothListener.Start();

            client = bluetoothListener.AcceptBluetoothClient();//接收

            while (true)
            {
                byte[] buffer = new byte[100];
                Stream peerStream = client.GetStream();
                peerStream.Read(buffer, 0, buffer.Length);
                data = Encoding.UTF8.GetString(buffer).ToString().Replace("\0", "");//去掉後面的\0位元組
            }
            textBox2.Text = data;
            Debug.Print(data);
        }

        private void Receiving_Click(object sender, EventArgs e)
        {
            ConnectBT();
        }
    }
}
