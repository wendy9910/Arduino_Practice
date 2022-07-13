using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.Threading;
using System.Diagnostics;
using System.Collections;


namespace MPU_GUI
{
    public partial class Form1 : Form
    {
        List<byte> raw;
        byte[] buf;
        StringBuilder sb;
        

        //藍芽套件
        BluetoothAddress addr; //用於識別一個獨特的藍芽裝置的地址
        BluetoothEndPoint ep;  //代表一個設備上的藍芽服務(端點)
        BluetoothClient client;  //藍芽用戶端
        BluetoothAddress[] MACs;
        Stream btStream;
        Thread RxBT;
        Guid serviceClass;

        //數據儲存
        byte[] RxBuf, buffer;
        const int bufLen = 2040;

        bool btstate,CPstate;
        int i;
        string Text;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSet() 
        {
            GetComPortbtn.Enabled = true;
            GetBTbtn.Enabled = true;
            RComPortbtn.Enabled = false;
            RBTbtn.Enabled = false;
            startbtn.Enabled = false;
            stopbtn.Enabled = false;
            clearbtn.Enabled = false;

            raw.Clear();
        }

        private void getAllPorts() 
        {
            comboBox1.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            foreach (string port in ports)
                comboBox1.Items.Add(port);
            comboBox1.SelectedIndex = comboBox1.Items.Count - 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            raw = new List<byte>();
            sb = new StringBuilder();
            btstate = false;
            CPstate = false;

            buttonSet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {

        }

        private void GetComPortbtn_Click(object sender, EventArgs e)
        {
            getAllPorts();
        }


        int index;
        private void GetBTbtn_Click(object sender, EventArgs e)
        {
          
            Cursor = Cursors.WaitCursor;
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            MACs = new BluetoothAddress[devices.Length];

            i = 0;
            comboBox2.Items.Clear();
            foreach (BluetoothDeviceInfo device in devices) 
            {
                comboBox2.Items.Add(string.Format("{0}: {1}", device.DeviceName, device.DeviceAddress));
                MACs[i++] = device.DeviceAddress;
            }
            comboBox2.SelectedIndex = 0;
            Cursor = Cursors.Arrow;
            if (devices.Length > 0)
                RBTbtn.Enabled = true;

            
        }

        private void RBTbtn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            btstate = true;
            CPstate = false;
            iStart = 0;
            iEnd = -1;
            index = comboBox2.FindString(comboBox2.Text);
            comboBox2.SelectedIndex = index;
            ConnectBTDevice();

            btstate = true;
            timer1.Start();
        }

        public void ConnectBTDevice() 
        {
            try
            {
                serviceClass = BluetoothService.SerialPort;
                addr = MACs[comboBox2.SelectedIndex];

                if (ep != null)
                    ep = null;
                ep = new BluetoothEndPoint(addr, serviceClass);
                if (client != null)
                {
                    client.Close();
                    client.Dispose();
                    client = null;
                }
                client = new BluetoothClient();
                client.Connect(ep);

                btStream = client.GetStream();
                RxBuf = new byte[bufLen];
                RxBT = new Thread(ReceivingPacket);
                RxBT.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Connecting BlueTooth");
            
            }
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(btstate) 
                displayRx();
        }

        int LenRead,i0,iStart,iEnd;
        byte val;
        private void ReceivingPacket()
        {
            while (btstate) 
            {
                LenRead = 0;
                if (!btStream.CanRead)
                    break;
                else if (btstate)
                    LenRead = btStream.Read(RxBuf, 0, bufLen);
                else
                    break;

                if (LenRead == 0)
                    continue;
                for (i0 = 0; i0 < LenRead; i0++)
                    raw.Add(RxBuf[i0]);
            }
        
        }

        byte value;

        private void displayRx() 
        {
            //iStart = iEnd;
            iStart = 0;
            iEnd = raw.Count - 1;
            Text = string.Format("iStart({0})->iEnd({1})", iStart, iEnd);
            while (iStart <= iEnd) 
            {
                value = raw[iStart++];
                sb.AppendFormat("{0}", (char)value);
                
            }
            textBox1.Text = sb.ToString();
            Application.DoEvents();
        }
    }
}
