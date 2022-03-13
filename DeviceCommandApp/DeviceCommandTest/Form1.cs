using DeviceCommandApp.CommandCommunication;
using DeviceCommandApp.Util;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace DeviceCommandTest
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stream == null)
            {
                MessageBox.Show("未接続です");
                return;
            }

            CommandHeader header = new CommandHeader()
            {
                CommandID = CommandID.MotorCommand,
                Size = 4
            };
            int input = 0;
            try
            {
                input = Convert.ToInt32(this.textBox1.Text);
            }
            catch
            {
                MessageBox.Show("入力値不正");
                return;
            }
            MotorCommand command = new MotorCommand
            {
                Move_mm = input
            };

            var headerbuf = StructConvert.ConvertToBytes<CommandHeader>(header);
            var commandbuf = StructConvert.ConvertToBytes<MotorCommand>(command);

            stream.Write(headerbuf.Concat(commandbuf).ToArray());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stream != null)
            {
                stream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (stream == null)
            {
                MessageBox.Show("未接続です");
                return;
            }

            CommandHeader header = new CommandHeader()
            {
                CommandID = CommandID.SensorCommand,
                Size = 1
            };

            ReadSensorCommand command = new ReadSensorCommand
            {
                Reserved = 0x00
            };

            var headerbuf = StructConvert.ConvertToBytes<CommandHeader>(header);
            var commandbuf = StructConvert.ConvertToBytes<ReadSensorCommand>(command);
            stream.Write(headerbuf.Concat(commandbuf).ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client = new TcpClient("localhost", 10000);
            stream = client.GetStream();
        }
    }
}
