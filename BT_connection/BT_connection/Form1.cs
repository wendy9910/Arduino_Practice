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
using System.Net.Sockets;


namespace BT_connection
{
    public partial class Form1 : Form
    {
        static bool isConnected;
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
            textBox2.Text = "";

        }


        private void scan_bt_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            MACs = new BluetoothAddress[devices.Length];

            textBox1.Text = "";
            textBox2.Text = "";

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
            

            client.Connect(addr, serviceClass);
            Console.WriteLine("Connected!");
            ReceiveData2();
        }

        private void ReceiveData2()
        {

            isConnected = client.Connected;
            
            while (isConnected)
            {
                try
                {

                    Stream netStream = client.GetStream();

                    // Send some data to the peer.
                    byte[] sendBuffer = Encoding.UTF8.GetBytes("Is anybody there?");

                    
                    if (!netStream.CanRead) 
                    {

                        Debug.Print("Can't read");
                    }
                    else 
                    {
        
                        byte[] receiveBuffer = new byte[1024];
                        int bytesReceived = netStream.Read(receiveBuffer, 0, 1024);
                        string data = Encoding.UTF8.GetString(receiveBuffer).ToString().Replace("\0", "");

                        textBox2.AppendText(data);
                        //textBox2.SelectionStart = textBox2.Text.Length;
                        //textBox2.ScrollToCaret();

                        Debug.Print(data);

                    }
                   
                }
                catch (Exception e)
                {
                    Console.Write("Error:" + e);
                    break;
                }
            }
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
            Console.Write(data);
            textBox2.Text = data;
            Debug.Print(data);
        }

        private void Receiving_Click(object sender, EventArgs e)
        {
            ConnectBT();
        }
    }
}
