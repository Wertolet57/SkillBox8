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
        public List<Worker> workers;
        public List<Department> departments;

        public Department AddNewDepartment(int n = 1)
        {
            List<Department> inDep = new List<Department>();
            Console.WriteLine("Введите название департамента");
            string name = Console.ReadLine();
            Console.WriteLine("Введите дату создания департамента");
            DateTime date;
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out date)) break;
                Console.WriteLine("Некорректное значение");
            }
            //int numOfWorkers;
            //Console.WriteLine("Введите кол-во сотрудников");
            //while (true)
            //{
            //    if (int.TryParse(Console.ReadLine(), out numOfWorkers)) break;
            //    Console.WriteLine("Некорректное значение");
            //}
            Console.WriteLine("Вложенные департаменты");
            Console.WriteLine("Выбрать из существующих(1), добавить новый(2), таких нет(3)");
            int num;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num == 1 || num == 2 || num == 3) break;
                Console.WriteLine("Некорректное значение");
            }
            switch (num)
            {
                case 1:
                    if (departments.Count == 0)
                    {
                        Console.WriteLine("Департаментов нет");
                    }
                    else
                    {
                        while (true)
                        {
                            Console.WriteLine("Выберите департамент");
                            PrintAllDepartments();
                            inDep.Add(departments[int.Parse(Console.ReadLine()) - 1]);
                            Console.WriteLine("Еще? (да/нет)");
                            if (Console.ReadLine() != "да") break;
                        }
                    }
                    break;
                case 2:
                    while (true)
                    {
                        inDep.Add(AddNewDepartment());
                        Console.WriteLine("Еще? (да/нет)");
                        if (Console.ReadLine() != "да") break;
                    }
                    break;
            }
            if (n == 1)
            {
                Console.WriteLine("Департамент добавлен");
                if (inDep.Count == 0)
                {
                    departments.Add(new Department(name, date));
                }
                else
                {
                    departments.Add(new Department(name, date, inDep));
                }
            }
            if (inDep.Count == 0)
            {
                return new Department(name, date);
            }
            else
            {
                return new Department(name, date, inDep);
            }

        }

        public void PrintAllDepartments()
        {
            if (departments.Count == 0) Console.WriteLine("Нет департаментов");
            else
            {
                string str = String.Format("{0, -10} | {1, -20} | {2, 13} | {3,10} | {4,10}",
                           "№",
                           "Название",
                           "Дата создания",
                           "Сотрудники",
                           "Департаменты");
                Console.WriteLine(str);
                int i = 1;
                foreach (var dep in departments)
                {
                    str = String.Format("{0, -10} | {1, -20} | {2, 13} | {3,10} | {4,10}",
                    i++,
                    dep.nameOfDepartment,
                    dep.dateOfCreate.ToString("d"),
                    dep.numOfWorkers,
                    dep.departments.Count);
                    Console.WriteLine(str);
                }
            }
        }

        public void DeleteDepartment()
        {
            if (departments.Count == 0)
            {
                Console.WriteLine("Нет департаментов");
                return;
            }
            Console.WriteLine("Какой департамент хотите удалить?");
            PrintAllDepartments();
            int num;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num <= departments.Count) break;
                Console.WriteLine("Некорректное значение");
            }
            departments.RemoveAt(num - 1);
            Console.WriteLine("Департамент удален");
        }

        public Worker AddWorker(int n = 1)

        {
            Console.WriteLine("Введите имя сотрудника");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите возраст сотрудника");
            int age;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out age))
                    break;
                Console.WriteLine("Некорректное значение");
            }
            Console.WriteLine("В каком депортаменте работает");
            if (departments.Count == 0)
            {
                Console.WriteLine("Департаментов нет");
                Console.WriteLine("Добавьте департамент");
                AddNewDepartment();
            }
            int num;
            while (true)
            {
                PrintAllDepartments();
                Console.WriteLine("Введите номер департамента");
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num <= departments.Count) break;
                Console.WriteLine("Некорректное значение");
            }
            int ID;
            while (true)
            {
                Console.WriteLine("Введите ID");
                if (int.TryParse(Console.ReadLine(), out ID))
                    break;
                Console.WriteLine("Некорректное значение");
            }
            int solary;
            while (true)
            {
                Console.WriteLine("Введите зарплату");
                if (int.TryParse(Console.ReadLine(), out solary))
                    break;
                Console.WriteLine("Некорректное значение");
            }
            int project;
            while (true)
            {
                Console.WriteLine("Введите кол-во проектов");
                if (int.TryParse(Console.ReadLine(), out project))
                    break;
                Console.WriteLine("Некорректное значение");
            }
            if (n == 1)
            {
                workers.Add(new Worker(name, surname, (short)age, departments[num - 1].nameOfDepartment, ID, solary, (short)project));
                departments[num - 1] = new Department(departments[num - 1].nameOfDepartment, departments[num - 1].dateOfCreate, departments[num - 1].numOfWorkers+1, departments[num - 1].departments);
            }
            return new Worker(name, surname, (short)age, departments[num - 1].nameOfDepartment, ID, solary, (short)project);
        }

        public void ChangeDepartments()
        {
            PrintAllDepartments();
            Console.WriteLine("Какой депортамент хотите изменить?");
            int num;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num <= departments.Count) break;
                Console.WriteLine("Некорректное значение");
            }
            departments[num - 1] = AddNewDepartment(0);
            Console.WriteLine("Департамент изменен");
        }

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

        public void DeleteWorker()
        {
            if (workers.Count == 0)
            {
                Console.WriteLine("Нет сотрудников");
                return;
            }
            PrintAllWorkers();
            Console.WriteLine("Какого сотрудника удалить?");
            int num;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num <= workers.Count) break;
                Console.WriteLine("Некорректное значение");
            }
            workers.RemoveAt(num - 1);
            Console.WriteLine("Работник удален");
        }

        public void ChangeWorker()
        {
            if (workers.Count == 0)
            {
                Console.WriteLine("Нет сотрудников");
                return;
            }
            PrintAllWorkers();
            Console.WriteLine("Какого сотрудника редактируем?");
            int num;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num <= workers.Count) break;
                Console.WriteLine("Некорректное значение");
            }
            workers[num - 1] = AddWorker(0);
            Console.WriteLine("Работник изменен");
        }

        public void Sort()
        {
            if (departments.Count == 0)
            {
                Console.WriteLine("Нет департаментов");
                return;
            }
            PrintAllDepartments();
            List<Worker> workers = new List<Worker>();
            Console.WriteLine("В каком департаменте сортируем сотрудников");
            int num;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num <= departments.Count) break;
                Console.WriteLine("Некорректное значение");
            }
            if (departments[num-1].numOfWorkers==0)
            {
                Console.WriteLine("Нет сотрудников в этом департаменте");
                return;
            }
            foreach (var worker in this.workers)
            {
                if (worker.departmentName == departments[num - 1].nameOfDepartment)
                {
                    workers.Add(worker);
                }
            }
            PrintWorkers(workers);
            Console.WriteLine("По какому полю сортируем(Имя - 1, Фамилия - 2, Возраст - 3, ID - 4, Зарплата - 5, Кол-во проектов - 6)");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num >= 1 && num <= 6) break;
                Console.WriteLine("Некорректное значение");
            }

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
            PrintWorkers(result.ToList());
            Console.WriteLine("По какому еще полю сортируем(0 - не сортируем, Имя - 1, Фамилия - 2, Возраст - 3, ID - 4, Зарплата - 5, Кол-во проектов - 6)");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num >= 0 && num <= 6) break;
                Console.WriteLine("Некорректное значение");
            }
            switch (num)
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

        void PrintWorkers(List<Worker> workers)
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

    }
}
