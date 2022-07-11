using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MPU_GUI
{
    public partial class Form1 : Form
    {
        List<byte> raw;
        byte[] buf;
        StringBuilder sb;

        public Form1()
        {
            InitializeComponent();
            getAllPorts();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void getAllPorts() 
        {
            comboBox1.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            foreach (string port in ports)
                comboBox1.Items.Add(port);
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getAllPorts();
        }
    }
}
