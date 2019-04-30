using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract1;

namespace WcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var _myServiceUri = new Uri("http://localhost:10001/myService");
            ServiceHost host = new ServiceHost(typeof(Calculator), _myServiceUri);

            try
            {
                WSHttpBinding binder = new WSHttpBinding();
                host.AddServiceEndpoint(typeof(ICalculator),binder, "endpoint1");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);

                host.Open();
                Console.WriteLine("Service is running.");
                Console.WriteLine("Press <ENTER> to quit.\n");
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException e)
            {
                {
                    Console.WriteLine(e);
                    Console.ReadLine();
                    host.Abort();
                }
            }
        }
    }
}
