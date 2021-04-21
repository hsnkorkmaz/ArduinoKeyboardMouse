using System.Drawing;
using System.Drawing.Imaging;
using System.Formats.Asn1;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace ArduinoKeyboardMouse
{
    public class ArduinoOperations
    {
        private readonly SerialPort _serialPort;

        public ArduinoOperations(SerialPort serialPort)
        {
            _serialPort = serialPort;
        }

        public bool OpenConnection()
        {
            if (_serialPort.IsOpen) return true;

            _serialPort.BaudRate = 57600;
            _serialPort.Open();
            return _serialPort.IsOpen;
        }

        public void CloseConnection()
        {
            if (!OpenConnection()) _serialPort.Close();
        }

        internal void SendData(string method, string data)
        {
            if (OpenConnection()) _serialPort.Write(method + "*" + data + "!");
        }

        //Keyboard mouse operations
        public void Delay(string data)
        {
            SendData("delay", data);
        }

        public void KeyboardPress(string data)
        {
            SendData("keyboardPress", data);
        }

        public void KeyboardPrint(string data)
        {
            SendData("keyboardPrint", data);
        }

        public void KeyboardPrintln(string data)
        {
            SendData("keyboardPrintln", data);
        }

        public void KeyboardRelease(string data)
        {
            SendData("keyboardRelease", data);
        }

        public void KeyboardReleaseAll(string data)
        {
            SendData("keyboardReleaseAll", data);
        }
        public void KeyboardWrite(string data)
        {
            SendData("keyboardWrite", data);
        }
        public void MouseClick(string data)
        {
            SendData("mouseClick", data);
        }
        public void MouseMove(Point data, int speed)
        {
            SendData("mouseMove", data.X + "," + data.Y);
        }

        public void MousePress(string data)
        {
            SendData("mousePress", data);
        }
        public void MouseRelease(string data)
        {
            SendData("mouseRelease", data);
        }


        public void MouseMoveToPosition(Point destinationPos, int speed)
        {
            var movementGraphic = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            var currentPos = new Point(Cursor.Position.X, Cursor.Position.Y);
            var currentSum = currentPos.X + currentPos.Y;
            var destinationSum = destinationPos.X + destinationPos.Y;

            while (currentSum != destinationSum)
            {
                //Slow down a little bit at the end
                var difference = destinationSum - currentSum;
                if (difference is > -100 and < 100)
                {
                    speed = 1;
                    Thread.Sleep(2);
                }

                var move = new Point(0, 0);
                if (currentPos.X < destinationPos.X)
                {
                    move.X = speed;
                }
                if (currentPos.Y < destinationPos.Y)
                {
                    move.Y = speed;
                }
                if (currentPos.X > destinationPos.X)
                {
                    move.X = speed * -1;
                }
                if (currentPos.Y > destinationPos.Y)
                {
                    move.Y = speed * -1;
                }

                MouseMove(move, speed);

                currentPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                currentSum = currentPos.X + currentPos.Y; ;
                

                movementGraphic.SetPixel(currentPos.X,currentPos.Y,Color.White);

            }

            var jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            var myEncoder = Encoder.Quality;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            movementGraphic.Save(@"c:\pp\temp\mouse.jpg", jgpEncoder, myEncoderParameters);
            movementGraphic.Dispose();
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}