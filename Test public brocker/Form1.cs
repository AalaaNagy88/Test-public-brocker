using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Test_public_brocker
{
    public partial class Form1 : Form
    {
        MqttClient client;
        public Form1()
        {
            InitializeComponent();
            client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            client.Connect(Guid.NewGuid().ToString());
        }

        private void send_Click(object sender, EventArgs e)
        {
            client.MqttMsgPublished += client_MqttMsgPublished;
            ushort msgId = client.Publish("test/", Encoding.UTF8.GetBytes(X.Text +","+ Y.Text +","+ Z.Text), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }
        private static void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
        }
    }
}
