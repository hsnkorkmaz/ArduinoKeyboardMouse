using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace ArduinoKeyboardMouse
{
    public partial class Form1 : Form
    {
        private readonly SerialConnections _serial;
        private const string ConnectedPort = "COM3";

        public Form1()
        {
            InitializeComponent();
            LblConnection(false);
            _serial = new SerialConnections(new SerialPort(ConnectedPort));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            LblConnection(_serial.OpenConnection());
            
            _serial.SendData("","");
        }

        private void LblConnection(bool connected)
        {
            if (connected)
            {
                lblIsConnected.BackColor = Color.DarkSeaGreen;
                lblIsConnected.Text = @"Connected!";
            }
            else
            {
                lblIsConnected.BackColor = Color.Red;
                lblIsConnected.Text = @"Not Connected!";
            }
        }

        private void btnCloseConnection_Click(object sender, EventArgs e)
        {
            _serial.CloseConnection();
            LblConnection(false);
        }
    }
}