using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Department(string nameOfDepartment, DateTime dateOfCreate, int numOfWorkers)
        {
            this.nameOfDepartment = nameOfDepartment;
            this.dateOfCreate = dateOfCreate;
            this.numOfWorkers = numOfWorkers;
            this.departments = new List<Department>();
        }
    }
}
