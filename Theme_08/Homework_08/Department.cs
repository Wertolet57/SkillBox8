using System;
using System.Collections.Generic;

namespace Homework_08
{
    struct Department
    {
        /// <summary>
        /// Название
        /// </summary>
        public string nameOfDepartment;
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime dateOfCreate;
        /// <summary>
        /// Кол-во сотрудников
        /// </summary>
        public int numOfWorkers;
        /// <summary>
        /// Конструктор департамента
        /// </summary>
        /// <param name="nameOfDepartment">Название</param>
        /// <param name="dateOfCreate">Дата создания</param>
        /// <param name="numOfWorkers">Кол-во сотрудников</param>
        public Department(string nameOfDepartment, DateTime dateOfCreate, int numOfWorkers)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = numOfWorkers;
        }
        /// <summary>
        /// Конструктор департамента
        /// </summary>
        /// <param name="nameOfDepartment">Название</param>
        /// <param name="dateOfCreate">Дата создания</param>
        public Department(string nameOfDepartment, DateTime dateOfCreate)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = 0;
        }
    }
}
