using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    struct Employee : IWorker
    {
       
        public Employee(string name, double salary, position position, gender gender,DateTime startDate)
        {
            this.name = name;
            this.position = position;
            this.salary = salary;
            this.gender = gender;
            this.startDate = startDate;
        }        
    
        public string name { get; set; }
        public double salary { get; set; }

        public position position { get; set; }
        public gender gender { get; set; }
        public DateTime startDate { get; set; }

        public void printInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} {1}", position, name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ставка: {0:0,000 KZT}", salary);
            Console.WriteLine("Работает с {0:d}", startDate);            
            Console.WriteLine("Пол: {0}", gender);

        }
    }
}
