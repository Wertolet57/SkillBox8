using System;
using System.Collections.Generic;

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
            Worker[] workers1 = new Worker[workers.Count];
            workers1 = workers.ToArray();
            Console.WriteLine("По какому полю сортируем(Имя - 1, Фамилия - 2, Возраст - 3, ID - 4, Зарплата - 5, Кол-во проектов - 6)");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                    if (num>=1 && num <= 6) break;
                Console.WriteLine("Некорректное значение");
            }

            Worker change;
            switch (num)
            {
                case 1:
                    for (int i = 0; i < workers1.Length; i++)
                    {
                        for (int j = 0; j < workers1.Length-1; j++)
                        {
                            if (workers1[j].name.CompareTo(workers1[j + 1].name) == 1)
                            {
                                change = workers1[j];
                                workers1[j] = workers1[j + 1];
                                workers1[j + 1] = change;

                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < workers1.Length; i++)
                    {
                        for (int j = 0; j < workers1.Length - 1; j++)
                        {
                            Console.WriteLine(workers1[j].surname.CompareTo(workers1[j + 1].surname));
                            if (workers1[j].surname.CompareTo(workers1[j + 1].surname) == 1)
                            {
                                change = workers1[j];
                                workers1[j] = workers1[j + 1];
                                workers1[j + 1] = change;

                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < workers1.Length; i++)
                    {
                        for (int j = 0; j < workers1.Length - 1; j++)
                        {
                            if (workers1[j].age>workers1[j + 1].age)
                            {
                                change = workers1[j];
                                workers1[j] = workers1[j + 1];
                                workers1[j + 1] = change;

                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < workers1.Length; i++)
                    {
                        for (int j = 0; j < workers1.Length - 1; j++)
                        {
                            if (workers1[j].ID > workers1[j + 1].ID)
                            {
                                change = workers1[j];
                                workers1[j] = workers1[j + 1];
                                workers1[j + 1] = change;

                            }
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < workers1.Length; i++)
                    {
                        for (int j = 0; j < workers1.Length - 1; j++)
                        {
                            if (workers1[j].salary > workers1[j + 1].salary)
                            {
                                change = workers1[j];
                                workers1[j] = workers1[j + 1];
                                workers1[j + 1] = change;

                            }
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < workers1.Length; i++)
                    {
                        for (int j = 0; j < workers1.Length - 1; j++)
                        {
                            if (workers1[j].numOfProjects > workers1[j + 1].numOfProjects)
                            {
                                change = workers1[j];
                                workers1[j] = workers1[j + 1];
                                workers1[j + 1] = change;

                            }
                        }
                    }
                    break;
            }
            workers = new List<Worker>(workers1);
            PrintWorkers(workers);
            Console.WriteLine("По какому полю отсортировать еще(0 - если не нужно, Имя - 1, Фамилия - 2, Возраст - 3, ID - 4, Зарплата - 5, Кол-во проектов - 6)");
            int num1;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num1))
                    if (num1 >= 0 && num1 <= 6) break;
                Console.WriteLine("Некорректное значение");
            }

            workers = new List<Worker>(workers1);
            PrintWorkers(workers);
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
