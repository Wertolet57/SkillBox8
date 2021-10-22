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
        /// ID департамента
        /// </summary>
        public int depId;
        /// <summary>
        /// Конструктор департамента
        /// </summary>
        /// <param name="nameOfDepartment">Название</param>
        /// <param name="dateOfCreate">Дата создания</param>
        /// <param name="numOfWorkers">Кол-во сотрудников</param>
        /// <param name="depId">ID департамента</param>
        public Department(string nameOfDepartment, DateTime dateOfCreate, int numOfWorkers, int depId)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = numOfWorkers;
            this.depId = depId;
        }
        /// <summary>
        /// Конструктор департамента
        /// </summary>
        /// <param name="nameOfDepartment">Название</param>
        /// <param name="dateOfCreate">Дата создания</param>
        /// <param name="depId">ID департамента</param>
        public Department(string nameOfDepartment, DateTime dateOfCreate, int depId)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = 0;
            this.depId = depId;
        }
    }
}
