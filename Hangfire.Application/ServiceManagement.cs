using System;

namespace Hangfire.Application
{
    public class ServiceManagement : IServiceManagement
    {
        public void Run()
        {
            Console.WriteLine("Processando");
        }
    }
}
