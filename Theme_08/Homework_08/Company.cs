using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    struct Company
    {
        public List<Worker> workers;
        public List<Department> departments;

        public void AddNewDepartment()
        {
            Console.WriteLine("Введите название департамента");
            string name = Console.ReadLine();
            Console.WriteLine("Введите дату создания департамента");
            DateTime date;
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    break;
                else
                    Console.WriteLine("Некорректное значение");
            }    
            int numOfWorkers;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(),out numOfWorkers))
                    break;
                else
                    Console.WriteLine("Некорректное значение");
            }


        }
    }
}
