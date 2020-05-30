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
       static MqttClient client=new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
        public Form1()
        {
            InitializeComponent();
            client.Connect(Guid.NewGuid().ToString());
        }

        private void send_Click(object sender, EventArgs e)
        {
            client.MqttMsgPublished += client_MqttMsgPublished;
            ushort msgId= client.Publish("test/", Encoding.UTF8.GetBytes(X.Text + "," + Y.Text + "," + Z.Text), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            //client.MqttMsgPublishReceived += client_MqttMsgrecieved;
            //client.Subscribe(new string[] { "turnon/" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }
        private static void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
        }
        private static void client_MqttMsgrecieved(object sender, MqttMsgPublishEventArgs e)
        {
            var msg = System.Text.Encoding.UTF8.GetString(e.Message);
            MessageBox.Show("message Recieved" + msg);
            client.MqttMsgPublished += client_MqttMsgPublished;            
        }
    }
}
