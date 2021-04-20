using System.IO.Ports;

namespace ArduinoKeyboardMouse
{
    public class SerialConnections
    {
        private readonly SerialPort _serialPort;

        public SerialConnections(SerialPort serialPort)
        {
            _serialPort = serialPort;
        }

        public bool OpenConnection()
        {
            if (IsConnected()) return true;

            _serialPort.BaudRate = 57600;
            _serialPort.Open();
            return IsConnected();
        }

        public bool IsConnected()
        {
            return _serialPort.IsOpen;
        }

        public void CloseConnection()
        {
            if (!OpenConnection()) _serialPort.Close();
        }

        public void SendData(string method, string data)
        {
            if (OpenConnection()) _serialPort.Write(method + "*" + data + "!");
        }

        //public static string[] GetPorts()
        //{
        //    return SerialPort.GetPortNames();
        //}
    }
}