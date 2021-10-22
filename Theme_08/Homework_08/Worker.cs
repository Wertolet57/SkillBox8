using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    struct Worker
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string name;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string surname;
        /// <summary>
        /// Возраст
        /// </summary>
        public short age;
        /// <summary>
        /// Департамент в котором работает
        /// </summary>
        public string departmentName;
        /// <summary>
        /// ID
        /// </summary>
        public int ID;
        /// <summary>
        /// Зарплата
        /// </summary>
        public int salary;
        /// <summary>
        /// Кол-во проектов
        /// </summary>
        public short numOfProjects;
        public int depId;
        /// <summary>
        /// Конструктор работника
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="departmentName">Департамент</param>
        /// <param name="ID">ID</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="numOfProjects">Кол-во проектов</param>
        /// <param name="depId">ID департамента</param>
        public Worker(string name, string surname, short age, string departmentName, int ID, int salary, short numOfProjects, int depId)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.departmentName = departmentName;
            this.ID = ID;
            this.salary = salary;
            this.numOfProjects = numOfProjects;
            this.depId = depId;
        }
    }
}
