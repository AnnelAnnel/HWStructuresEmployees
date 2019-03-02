
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceWorker sw = new ServiceWorker();
            sw.makeTeam();
            
            sw.MainMenu();
        }
      
    }
}
