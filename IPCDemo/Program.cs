using IPCContract;
using System.Reflection;

namespace IPCDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfDlls = new[]
            {
                @"C:\DEV\IPCDemo\ExternalApp1\bin\Debug\netstandard2.1\ExternalApp1.dll",
                @"C:\DEV\IPCDemo\ExternalApp2\bin\Debug\netstandard2.1\ExternalApp2.dll"
            };

            foreach (var dll in listOfDlls)
            {
                var dllInstance = Assembly.LoadFile(dll);
                var externalAppType = dllInstance.GetExportedTypes().Where(type => typeof(IExternalApp).IsAssignableFrom(type)).FirstOrDefault();
                var externalApp = (IExternalApp)Activator.CreateInstance(externalAppType);
                externalApp.Run();
            }

            Console.ReadKey();
        }
    }
}