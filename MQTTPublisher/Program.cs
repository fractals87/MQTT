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

                Random random = new Random();
                Console.WriteLine("Avvio publisher completato");

                // publish a message on "/home/temperature" topic with QoS 2 
                Console.WriteLine("0-exit 1-send");
                int func;
                do
                {
                    client.Publish("/home/temperature", Encoding.UTF8.GetBytes(random.Next().ToString()), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                    func = Console.Read();
                } while (func != 0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
