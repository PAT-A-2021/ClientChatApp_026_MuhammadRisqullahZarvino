using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientChatApp_20190140026_Muhammad_Risqullah_Zarvino
{
    public class ClientCallback : ServiceReference1.IServiceCallbackCallback
    {
        public void pesanKirim(String user, string pesan)
        {
            Console.WriteLine("{0}: {1}", user, pesan);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new ClientCallback());
            ServiceReference1.ServiceCallbackClient server = new ServiceReference1.ServiceCallbackClient(context);

            Console.WriteLine("Enter Username");
            string nama = Console.ReadLine();
            server.gabung(nama);

            Console.WriteLine("kirim Pesan");
            string pesan = Console.ReadLine();  
            while (true)
            {
                if (!string.IsNullOrEmpty(pesan)) server.kirimPesan(pesan);
                Console.WriteLine("Kirim Pesan");
                pesan = Console.ReadLine();
            }
        }
    }
}
