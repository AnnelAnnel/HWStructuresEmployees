using RandomUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Company
{
    public class ServiceWorker
    {
        public List<IWorker> staff = new List<IWorker>();
        private static Random rnd = new Random();
        public int countWorkers { get; private set; }
        public void makeTeam()
        {            
            int count = 0;
            int k = 0;
            int g = 0;
            Console.WriteLine("Введите число сотрудников:");
            bool isCount = Int32.TryParse(Console.ReadLine(), out count);
            for (int i = 0; i < count; i++)
            {
                var user = GenerateUser.GetUser();
                string name=user.name.title + " " + user.name.first;                
                k = rnd.Next(0, 3);
                position position = (position)k;
                double salary = rnd.Next(1000, 5000);
                if (k == 1)
                    salary = salary * 2;
                if (k == 2)
                    salary = salary * 1.15;
                g = rnd.Next(0, 2);
                gender gender = (gender)g;
                DateTime startDate = DateTime.Now.AddDays(-(rnd.Next(1, 200)));
                Employee emp = new Employee(name, salary, position, gender, startDate);
                staff.Add(emp);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Команда создана!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            
        }
        public void printAllInfo()
        {
            for (int i = 0; i < staff.Count; i++)
            {
                staff[i].printInfo();
            }
        }

        public void findByPosition(position position)
        {
            for (int i = 0; i < staff.Count; i++)
            {
                if(staff[i].position==position)
                staff[i].printInfo();
            }
        }

        public void managersHigherSalaries()
        {
            staff.OrderBy(e => e.name);
            double averageSalary = 3000;
            for (int i = 0; i < staff.Count; i++)
            {
                if (staff[i].salary >averageSalary && staff[i].position == position.manager)
                    staff[i].printInfo();
            }
        }

        public void hiredBeforeDate()
        {
            staff.OrderBy(e => e.name);
            DateTime startDate = DateTime.Now.AddDays(-(rnd.Next(1,100)));
            Console.WriteLine("Приняты на работу до {0:d}", startDate);
            for (int i = 0; i < staff.Count; i++)
            {
                if (staff[i].startDate > startDate)
                    staff[i].printInfo();
            }
        }

        public void printByGender()
        {
            staff.OrderBy(e => e.name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Введите 1 женского пола, 2 - для мужского, 3 - для вывода информации о всех сотрудниках:");
            Console.ForegroundColor = ConsoleColor.White;
            int choice = 0;
            bool isChoice = Int32.TryParse(Console.ReadLine(), out choice);
            if (isChoice)
            {
                if (choice == 3)
                    printAllInfo();
                else if (choice == 1)
                {
                    for (int i = 0; i < staff.Count; i++)
                    {
                        if (staff[i].gender == gender.female)
                            staff[i].printInfo();
                    }
                }
                else if (choice == 2)
                {
                    for (int i = 0; i < staff.Count; i++)
                    {
                        if (staff[i].gender == gender.male)
                            staff[i].printInfo();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введены некорректные данные");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введены некорректные данные");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Информация о все сотрудниках");
            Console.WriteLine("2. Информация о менеджерах с зарплатой выше средней");
            Console.WriteLine("3. Информация о сотрудниках определенного пола");
            Console.WriteLine("4. Информация о сотрудниках, принятых на работу до определенной даты");
            Console.WriteLine("5. Выход");

            int choice = 0;
            bool isChoice = Int32.TryParse(Console.ReadLine(), out choice);
            if (isChoice)
            {
                if (choice == 1)
                {
                    Console.Clear();
                    printAllInfo();
                    Console.ReadKey();
                    MainMenu();
                }

                else if (choice == 2)
                {
                    Console.Clear();
                    managersHigherSalaries();
                    Console.ReadKey();
                    MainMenu();
                }               
                else if (choice == 3)
                {
                    Console.Clear();
                    printByGender();
                    Console.ReadKey();
                    MainMenu();
                }                
                else if (choice == 4)
                {
                    Console.Clear();
                    hiredBeforeDate();
                    Console.ReadKey();
                    MainMenu();
                }                
                else if (choice == 5)
                    return;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введены некорректные данные");
                    Console.ForegroundColor = ConsoleColor.White;
                    MainMenu();
                }  
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введены некорректные данные");
                Console.ForegroundColor = ConsoleColor.White;
                MainMenu();
            }
        }
    }
}
