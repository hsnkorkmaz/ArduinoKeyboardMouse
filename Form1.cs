using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace ArduinoKeyboardMouse
{
    public partial class Form1 : Form
    {
        private readonly ArduinoOperations _serial;
        private const string ConnectedPort = "COM3";

        public Form1()
        {
            InitializeComponent();
            LblConnection(false);
            _serial = new ArduinoOperations(new SerialPort(ConnectedPort));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            LblConnection(_serial.OpenConnection());
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

        private void btnSendData_Click(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            _serial.MouseMoveToPosition(new Point(100, 100), 1);


        }
    }
}