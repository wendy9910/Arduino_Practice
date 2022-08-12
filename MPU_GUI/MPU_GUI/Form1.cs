using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MPU_GUI
{
    public partial class Form1 : Form
    {

        //藍芽套件
        BluetoothAddress addr; //用於識別一個獨特的藍芽裝置的地址
        BluetoothClient client;  //藍芽用戶端
        BluetoothAddress[] MACs;


        Stream netStream;

        string data;
        Guid serviceClass;

        //數據存放
        List<byte> rawCP, rawBT;
        StringBuilder sbCP, sbBT;
        byte[] RxBuf, RxBufCP;
        Thread RxBT;

        bool btstate, CPstate;
        int i, btNow, cpNow, iStart = 0, iEnd = 0, iStart2 = 0, iEnd2 = 0;


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
            RComPortbtn.Enabled = true;
            RBTbtn.Enabled = true;
            startbtn.Enabled = true;
            stopbtn.Enabled = true;
            clearbtn.Enabled = true;
            startbtn2.Enabled = true;
            stopbtn2.Enabled = true;
            clearbtn2.Enabled = true;

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

            btstate = false;
            CPstate = false;

            rawBT = new List<byte>();
            sbBT = new StringBuilder();
            rawCP = new List<byte>();
            sbCP = new StringBuilder();

            buttonSet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index2 = comboBox1.FindString(comboBox1.Text);
            comboBox1.SelectedIndex = index2;
            CPstate = true;
            if (btstate) 
            {
                DisconnectBT();
                btstate = false;
            }

            if (serialPort1.IsOpen)
                serialPort1.Close();
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            serialPort1.Open();
            timer1.Start();
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            CPstate = false;
            if (serialPort1.IsOpen)
                serialPort1.Close();
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
            client = new BluetoothClient();
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

            btNow = 0;
        }

        static bool isConnected;

        private void startbtn_Click(object sender, EventArgs e)
        {
            iStart2 = 0;
            iEnd2 = 0;
            rawCP.Clear();
            sbCP.Clear();

            btstate = false;
            CPstate = true;

            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            if (!serialPort1.IsOpen)
                serialPort1.Open();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void save2_Click(object sender, EventArgs e)
        {
            DisconnectBT();
            saveFileDialog2.FileName = string.Format("BTData_{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.txt",
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            if (saveFileDialog2.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            File.AppendAllText(saveFileDialog2.FileName, sbBT.ToString());

            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < rawBT.Count; i++) 
            //{
            //    sb.AppendLine((char)rawBT[i]);
            //    while (iStart < iEnd)
            //    {
            //        sbBT.Append((char)rawBT[iStart++]);
            //    }
            //    textBox2.AppendText(sbBT.ToString());
            //    Application.DoEvents();
            //}


        }

        private void save1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            saveFileDialog1.FileName = string.Format("ConPort_Data_{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.txt",
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            File.AppendAllText(saveFileDialog1.FileName, sbCP.ToString());
        }

        private void RBTbtn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            btstate = true;


            ConnectBTDevice();
            timer1.Start();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int LenRead = 0;
            RxBufCP = new byte[1024];
            LenRead = serialPort1.Read(RxBufCP, 0, 1024);

            for (int i = 0; i < LenRead; i++)
            {
                rawCP.Add(RxBufCP[i]);
            }
        }

        private void startbtn2_Click(object sender, EventArgs e)
        {
            iStart = 0;
            iEnd = 0;
            rawBT.Clear();
            sbBT.Clear();

            if (serialPort1.IsOpen)
                serialPort1.Close();
            btstate = true;
            CPstate = false;

            ConnectBTDevice();
            timer1.Start();

        }

        public void ConnectBTDevice()
        {
            try
            {
                index = comboBox2.FindString(comboBox2.Text);
                comboBox2.SelectedIndex = index;
                serviceClass = BluetoothService.SerialPort; //BluetoothService.Handsfree;  
                addr = MACs[comboBox2.SelectedIndex];

                if (client != null)
                {
                    client.Close();
                    client.Dispose();
                    client = null;
                }
                client = new BluetoothClient();
                client.Connect(addr, serviceClass);
                Console.WriteLine("Connected!");
                isConnected = client.Connected;
                netStream = client.GetStream();
                RxBuf = new byte[1024];
                RxBT = new Thread(RecevingPacket);
                RxBT.Start();
            }
            catch (Exception ex)
            {
                Debug.Print("bt disconnect");
            }
            //ReceiveData();
        }

        private void RecevingPacket()
        {
            try
            {
                while (btstate)
                {
                    int LenRead = 0;
                    if (!netStream.CanRead)
                        break;
                    else if (btstate)
                    {
                        LenRead = netStream.Read(RxBuf, 0, 1024);
                    }
                    else
                        break;

                    if (LenRead == 0)
                        continue;

                    for (int i = 0; i < LenRead; i++)
                    {
                        rawBT.Add(RxBuf[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print("bt disconnect");
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (btstate)
            {
                iStart = iEnd;
                iEnd = rawBT.Count;
                while (iStart < iEnd)
                {
                    sbBT.Append((char)rawBT[iStart++]);
                }
                textBox2.AppendText(sbBT.ToString());
                Application.DoEvents();

            }
            if (CPstate) 
            {
                iStart2 = iEnd2;
                iEnd2 = rawCP.Count;
                while (iStart2 < iEnd2)
                {
                    sbCP.Append((char)rawCP[iStart2++]);
                }
                textBox1.AppendText(sbCP.ToString());
                Application.DoEvents();
            }
            
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clearbtn2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void stopbtn2_Click(object sender, EventArgs e)
        {
            DisconnectBT();
        }

        private void DisconnectBT()
        {
            if (client != null)
            {
                client.Close();
                client.Dispose();
                client = null;
                btstate = false;
            }
            if (RxBT != null)
                RxBT.Join();
        }
    }
}
