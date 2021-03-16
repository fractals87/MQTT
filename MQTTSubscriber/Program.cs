using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            // create client instance 
            MqttClient client = new MqttClient("127.0.0.1");

            // register to message received 
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2 
            client.Subscribe(new string[] { "/home/temperature" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // handle message received 
            string msg = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine($"Topic: {e.Topic}, Message: {msg}");
        }
    }
}
