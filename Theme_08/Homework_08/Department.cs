using System;
using System.Collections.Generic;

namespace Homework_08
{
    struct Department
    {
        public string nameOfDepartment;
        public DateTime dateOfCreate;
        public int numOfWorkers;

        public Department(string nameOfDepartment, DateTime dateOfCreate, int numOfWorkers)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = numOfWorkers;
        }

        public Department(string nameOfDepartment, DateTime dateOfCreate)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = 0;
        }

        public static Department CreateNew()
        {
            Console.WriteLine("Введите название департамента");
            string name = Console.ReadLine();
            Console.WriteLine("Введите дату создания департамента");
            DateTime date;
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out date)) break;
                Console.WriteLine("Некорректное значение");
            }
            
            return new Department(name, date);
        }
    }
}
