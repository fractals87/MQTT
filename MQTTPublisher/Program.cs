using System;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // create client instance 
                MqttClient client = new MqttClient("127.0.0.1");

                string clientId = Guid.NewGuid().ToString();
                client.Connect(clientId);

                string strValue = Convert.ToString(20);

                // publish a message on "/home/temperature" topic with QoS 2 
                client.Publish("/home/temperature", Encoding.UTF8.GetBytes(strValue), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
