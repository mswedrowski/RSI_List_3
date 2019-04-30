using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract1;

namespace WcfServiceHost2
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList endpoints = new ArrayList();
            ServiceHost host = new ServiceHost(typeof(Calculator));
            Uri uriAdress = new Uri("net.tcp://localhost:30001/myService/ServiceTCP");
            try
            {
                endpoints.Add(host.Description.Endpoints.Find(typeof(ICalculator)));
                endpoints.Add(host.Description.Endpoints.Find(new Uri("http://localhost:10001/myService/endpoint2")));
                endpoints.Add(host.Description.Endpoints.Find(new Uri("http://localhost:20001/myService/endpoint3")));
                endpoints.Add(host.AddServiceEndpoint(typeof(ICalculator), new NetTcpBinding(), uriAdress));

                Console.WriteLine("\n---> Endpoints: ");

                foreach (ServiceEndpoint serviceEndpoint in endpoints)
                {
                    Console.WriteLine($"\nService endpoint {serviceEndpoint.Name}: ");
                    Console.WriteLine($"Binding: {serviceEndpoint.Binding.ToString()}");
                    Console.WriteLine($"ListenUri: {serviceEndpoint.ListenUri.ToString()}");
                }

                host.Open();
                Console.WriteLine("\n--> Service1 is running... ");
                Console.WriteLine("Contract information: ");
                ContractDescription description = ContractDescription.GetContract(typeof(ICalculator));
                Console.WriteLine($"\tContract Type: {description.ContractType}");
                Console.WriteLine($"\tName: {description.Name}");
                Console.WriteLine("\tOperations: ");

                foreach (var operation in description.Operations)
                {
                    Console.WriteLine($"\t\t{operation.Name}");
                }
                Console.WriteLine("Press <ENTER> to quit.\n");
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                host.Abort();
            }
        }
    }
}
