using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Homework_08
{
    struct Company
    {
        /// <summary>
        /// Сотрудники
        /// </summary>
        public List<Worker> workers;
        /// <summary>
        /// Департаменты
        /// </summary>
        public List<Department> departments;

        /// <summary>
        /// Создание компании
        /// </summary>
        /// <param name="_1"></param>
        public Company(int _1)
        {
            workers = new List<Worker>();
            departments = new List<Department>();
        }

        /// <summary>
        /// Добавление нового департамента
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="date">Дата создания</param>
        /// <param name="depId">ID департамента</param>
        public void AddNewDepartment(string name, DateTime date, int depId)
        {
            departments.Add(new Department(name, date, depId));
        }

        /// <summary>
        /// Вывести все департаменты
        /// </summary>
        public void PrintAllDepartments()
        {
            if (departments.Count == 0) Console.WriteLine("Нет департаментов");
            else
            {
                string str = String.Format("{0, -10} | {1, -20} | {2, 13} | {3,10} ",
                           "№",
                           "Название",
                           "Дата создания",
                           "Сотрудники");
                Console.WriteLine(str);
                int i = 1;
                foreach (var dep in departments)
                {
                    str = String.Format("{0, -10} | {1, -20} | {2, 13} | {3,10}",
                    i++,
                    dep.nameOfDepartment,
                    dep.dateOfCreate.ToString("d"),
                    dep.numOfWorkers);
                    Console.WriteLine(str);
                }
            }
        }

        /// <summary>
        /// Удалить департамент
        /// </summary>
        /// <param name="num">Индекс</param>
        public void DeleteDepartment(int num)
        {
            
            departments.RemoveAt(num);
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="departmentName"></param>
        /// <param name="ID">ID</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="numOfProjects">Кол-во проектов</param>
        /// <param name="depId">ID департамента</param>
        public void AddWorker(string name, string surname, short age, string departmentName, int ID, int salary, short numOfProjects, int depId)
        {
            workers.Add(new Worker(name,surname,age,departmentName,ID,salary,numOfProjects, depId));
        }

        /// <summary>
        /// Изменить сотрудника
        /// </summary>
        /// <param name="num">Индекс</param>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="departmentName"></param>
        /// <param name="ID">ID</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="numOfProjects">Кол-во проектов</param>
        /// <param name="depId">ID департамента</param>
        public void ChangeWorker(int num, string name, string surname, short age, string departmentName, int ID, int salary, short numOfProjects, int depId)
        {
            workers[num] = new Worker(name, surname, age, departmentName, ID, salary, numOfProjects, depId);
        }

        /// <summary>
        /// Изменить департамент
        /// </summary>
        /// <param name="num">Индекс</param>
        /// <param name="name">Название</param>
        /// <param name="date">Дата создания</param>
        /// <param name="depId">ID департамента</param>
        public void ChangeDepartments(int num, string name, DateTime date, int depId)
        {
            departments[num - 1] = new Department(name, date, depId);
        }

        /// <summary>
        /// Вывести всех сотрудников
        /// </summary>
        public void PrintAllWorkers()
        {
            if (workers.Count == 0) Console.WriteLine("Нет сотрудников");
            else
            {
                string str = String.Format("{0, -10} | {1, -20} | {2, -20} | {3,7} | {4,11} | {5,10} | {6,10} | {7,10}",
                           "№",
                           "Имя",
                           "Фамилия",
                           "Возраст",
                           "Департамент",
                           "ID",
                           "Зарплата",
                           "Проекты");
                Console.WriteLine(str);
                int i = 1;
                foreach (var wor in workers)
                {
                    str = String.Format("{0, -10} | {1, -20} | {2, -20} | {3,7} | {4,11} | {5,10} | {6,10} | {7,10}",
                           i++,
                           wor.name,
                           wor.surname,
                           wor.age,
                           wor.departmentName,
                           wor.ID,
                           wor.salary,
                           wor.numOfProjects);
                    Console.WriteLine(str);
                }
            }
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="num">Индекс</param>
        public void DeleteWorker(int num)
        {
            workers.RemoveAt(num);
        }

        /// <summary>
        /// Сортировка
        /// </summary>
        /// <param name="num">Первое поля для сортировки</param>
        /// <param name="num1">Дополнительное поле</param>
        public void Sort(int num, int num1)
        {
            IOrderedEnumerable<Worker> result = null;
            switch (num)
            {
                case 1:
                    result = workers.OrderBy(w => w.name);
                    break;
                case 2:
                    result = workers.OrderBy(w => w.surname);
                    break;
                case 3:
                    result = workers.OrderBy(w => w.age);
                    break;
                case 4:
                    result = workers.OrderBy(w => w.ID);
                    break;
                case 5:
                    result = workers.OrderBy(w => w.salary);
                    break;
                case 6:
                    result = workers.OrderBy(w => w.numOfProjects);
                    break;
            }
            switch (num1)
            {
                case 1:
                    result = result.ThenBy(w => w.name);
                    break;
                case 2:
                    result = result.ThenBy(w => w.surname);
                    break;
                case 3:
                    result = result.ThenBy(w => w.age);
                    break;
                case 4:
                    result = result.ThenBy(w => w.ID);
                    break;
                case 5:
                    result = result.ThenBy(w => w.salary);
                    break;
                case 6:
                    result = result.ThenBy(w => w.numOfProjects);
                    break;
            }
            PrintWorkers(result.ToList());
        }

        /// <summary>
        /// Сериализаци в XML
        /// </summary>
        /// <param name="Path">Путь у файлу</param>
        public void SerializeCompanyXML(string Path)
        {
            XElement myCompany = new XElement("COMPANY");
            XElement myDepartment;
            XElement myWorker;
            XAttribute[] xAttributeDepartment = new XAttribute[3];
            XAttribute[] xAttributeWorker = new XAttribute[7];
            for (int i = 0; i < departments.Count; i++)
            {
                myDepartment = new XElement("DEPARTMENT");
                xAttributeDepartment[0] = new XAttribute("nameOfDepartment", departments[i].nameOfDepartment);
                xAttributeDepartment[1] = new XAttribute("dateOfCreate", departments[i].dateOfCreate);
                xAttributeDepartment[2] = new XAttribute("numOfWorkers", departments[i].numOfWorkers);
                myDepartment.Add(xAttributeDepartment);
                for (int j = 0; j < workers.Count; j++)
                {
                    myWorker = new XElement("WORKER");
                    if (workers[j].departmentName == departments[i].nameOfDepartment)
                    {
                        xAttributeWorker[0] = new XAttribute("name", workers[j].name);
                        xAttributeWorker[1] = new XAttribute("surname", workers[j].surname);
                        xAttributeWorker[2] = new XAttribute("age", workers[j].age);
                        xAttributeWorker[3] = new XAttribute("departmentName", workers[j].departmentName);
                        xAttributeWorker[4] = new XAttribute("ID", workers[j].ID);
                        xAttributeWorker[5] = new XAttribute("salary", workers[j].salary);
                        xAttributeWorker[6] = new XAttribute("numOfProjects", workers[j].numOfProjects);
                        myWorker.Add(xAttributeWorker);
                        myDepartment.Add(myWorker);
                    }
                }
                myCompany.Add(myDepartment);
            }

            myCompany.Save(Path);
            
        }

        /// <summary>
        /// Сериализация в JSON
        /// </summary>
        /// <param name="Path">Путь у файлу</param>
        public void SerializeCompanyJSON(string Path)
        {
            JArray arrayWorkers;
            JArray arrayDepartment = new JArray();
            JObject company = new JObject();
            JObject depatrment;
            JObject worker;
            for (int i = 0; i < departments.Count; i++)
            {
                depatrment = new JObject();
                arrayWorkers = new JArray();
                depatrment["nameOfDepartment"] = departments[i].nameOfDepartment;
                depatrment["dateOfCreate"] = departments[i].dateOfCreate;
                depatrment["numOfWorkers"] = departments[i].numOfWorkers;
                for (int j = 0; j < workers.Count; j++)
                {
                    worker = new JObject();
                    if (workers[j].departmentName == departments[i].nameOfDepartment)
                    {
                        worker["name"] = workers[j].name;
                        worker["surname"] = workers[j].surname;
                        worker["age"] = workers[j].age;
                        worker["departmentName"] = workers[j].departmentName;
                        worker["ID"] = workers[j].ID;
                        worker["salary"] = workers[j].salary;
                        worker["numOfProjects"] = workers[j].numOfProjects;
                        arrayWorkers.Add(worker);
                    }
                }
                depatrment["WORKERS"] = arrayWorkers;
                arrayDepartment.Add(depatrment);
            }
            company["DEPARTMENTS"] = arrayDepartment;
            string json = company.ToString();
            File.WriteAllText(Path, json);
        }

        /// <summary>
        /// Вывести список сотрудников
        /// </summary>
        /// <param name="workers">Список сотрудников</param>
        public void PrintWorkers(List<Worker> workers)
        {
            string str = String.Format("{0, -10} | {1, -20} | {2, -20} | {3,7} | {4,11} | {5,10} | {6,10} | {7,10}",
                           "№",
                           "Имя",
                           "Фамилия",
                           "Возраст",
                           "Департамент",
                           "ID",
                           "Зарплата",
                           "Проекты");
            Console.WriteLine(str);
            int i = 1;
            foreach (var worker in workers)
            {
                str = String.Format("{0, -10} | {1, -20} | {2, -20} | {3,7} | {4,11} | {5,10} | {6,10} | {7,10}",
                           i++,
                           worker.name,
                           worker.surname,
                           worker.age,
                           worker.departmentName,
                           worker.ID,
                           worker.salary,
                           worker.numOfProjects);
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Проверка ввода для int
        /// </summary>
        /// <param name="max">Максимальное значение</param>
        /// <param name="min">Минимальное значение</param>
        /// <returns></returns>
        public static int Check(int max = int.MaxValue, int min = 0)
        {
            int num;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num <= max && num >= min) break;
                Console.WriteLine("Некорректное значение");
            }
            return num;
        }

    }
}
