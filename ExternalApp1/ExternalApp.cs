using IPCContract;
using System;

namespace ExternalApp1
{
    public class ExternalApp : IExternalApp
    {
        public void Run()
        {
            Console.WriteLine($"{this.GetType()} is executed");
        }
    }
}
