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
    }
}
