using System;
using System.Collections.Generic;

namespace Homework_08
{
    struct Department
    {
        public string nameOfDepartment;
        public DateTime dateOfCreate;
        public int numOfWorkers;
        public List<Department> departments;

        public Department(string nameOfDepartment, DateTime dateOfCreate, int numOfWorkers, List<Department> departments)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = numOfWorkers;
            this.departments = departments;
        }

        public Department(string nameOfDepartment, DateTime dateOfCreate, List<Department> departments)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = 0;
            this.departments = departments;
        }

        public Department(string nameOfDepartment, DateTime dateOfCreate)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = 0;
            this.departments = new List<Department>();
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
