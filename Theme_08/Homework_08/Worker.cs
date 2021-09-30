using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    struct Worker
    {
        public string name;
        public string surname;
        public short age;
        public string departmentName;
        public int ID;
        public int salary;
        public short numOfProjects;

        public Worker(string name, string surname, short age, string departmentName, int ID, int salary, short numOfProjects)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.departmentName = departmentName;
            this.ID = ID;
            this.salary = salary;
            this.numOfProjects = numOfProjects;
        }
        public static Worker CreateNew(List<Department> departments, bool old)
        {
            Console.WriteLine("Введите имя сотрудника");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите возраст сотрудника");
            int age = Company.Check();
            int ID = Company.Check();
            int solary = Company.Check();
            int project = Company.Check();
            Console.WriteLine("В каком депортаменте работает");
            if (departments.Count == 0)
            {
                Console.WriteLine("Департаментов нет");
                Console.WriteLine("Добавьте департамент, после добавляйте сотрудников");
                return new Worker(name, surname, (short)age, "None", ID, solary, (short)project);
            }
            else
            {
                int num = Company.Check(departments.Count);
                if (!old)
                {
                    departments[num - 1] = new Department(departments[num - 1].nameOfDepartment, departments[num - 1].dateOfCreate, departments[num - 1].numOfWorkers + 1);
                }
                return new Worker(name, surname, (short)age, departments[num - 1].nameOfDepartment, ID, solary, (short)project);
            }
        }
    }
}
