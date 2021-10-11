using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company(1);
            while (true)
            {
                Console.WriteLine("Выбирите действие\n" +
                                  "1) Добавление департамента\n" +
                                  "2) Удаление департамента\n" +
                                  "3) Редактировать департамент\n" +
                                  "4) Добавить сотрудника\n" +
                                  "5) Удалить сотрудника\n" +
                                  "6) Редактировать сотрудника\n" +
                                  "7) Отсортировать\n" +
                                  "8) Сохранить в XML\n" +
                                  "9) Сохранить в JSON\n" +
                                  "10) Показать все департаменты\n" +
                                  "11) Показать всех сотрудников\n" +
                                  "12)Выйти\n");
                Console.WriteLine("Введите номер действия ");
                string action = Console.ReadLine();
                if (action != "12" && action != null)
                {
                    switch (action)
                    {
                        case "1":
                            var result = CreateNew();
                            company.AddNewDepartment(result.Item1,result.Item2);
                            Console.WriteLine("Департамент добавлен");
                            break;
                        case "2":
                            if (company.departments.Count == 0)
                            {
                                Console.WriteLine("Нет департаментов");
                                return;
                            }
                            Console.WriteLine("Какой департамент хотите удалить?");
                            company.PrintAllDepartments();
                            int num = Company.Check(company.departments.Count);
                            company.DeleteDepartment(num - 1);
                            Console.WriteLine("Департамент удален");
                            break;
                        case "3":
                            company.PrintAllDepartments();
                            Console.WriteLine("Какой депортамент хотите изменить?");
                            num =Company.Check(company.departments.Count);
                            result = CreateNew();
                            company.ChangeDepartments(num, result.Item1, result.Item2);
                            Console.WriteLine("Департамент изменен");
                            break;
                        case "4":
                            var result1 = CreateNew(company, company.departments, false);
                            company.AddWorker(result1.Item1, result1.Item2, result1.Item3, result1.Item4, result1.Item5, result1.Item6, result1.Item7);
                            Console.WriteLine("Сотрудник добавлен");
                            break;
                        case "5":
                            if (company.workers.Count == 0)
                            {
                                Console.WriteLine("Нет сотрудников");
                                return;
                            }
                            company.PrintAllWorkers();
                            Console.WriteLine("Какого сотрудника удалить?");
                            num = Company.Check(company.workers.Count);
                            foreach (var dep in company.departments)
                            {
                                if (dep.nameOfDepartment == company.workers[num - 1].departmentName)
                                {
                                    company.departments[num - 1] = new Department(company.departments[num - 1].nameOfDepartment, company.departments[num - 1].dateOfCreate, company.departments[num - 1].numOfWorkers - 1);
                                    break;
                                }
                            }
                            company.DeleteWorker(num-1);
                            Console.WriteLine("Работник удален");
                            break;
                        case "6":
                            if (company.workers.Count == 0)
                            {
                                Console.WriteLine("Нет сотрудников");
                                return;
                            }
                            company.PrintAllWorkers();
                            Console.WriteLine("Какого сотрудника редактируем?");
                            num = Company.Check(company.workers.Count);
                            result1 = CreateNew(company, company.departments, true);
                            company.ChangeWorker(num-1,result1.Item1, result1.Item2, result1.Item3, result1.Item4, result1.Item5, result1.Item6, result1.Item7);
                            Console.WriteLine("Работник изменен");
                            break;
                        case "7":
                            if (company.departments.Count == 0)
                            {
                                Console.WriteLine("Нет департаментов");
                                return;
                            }
                            company.PrintAllDepartments();
                            List<Worker> workers = new List<Worker>();
                            Console.WriteLine("В каком департаменте сортируем сотрудников");
                            num = Company.Check(company.departments.Count);
                            if (company.departments[num - 1].numOfWorkers == 0)
                            {
                                Console.WriteLine("Нет сотрудников в этом департаменте");
                                return;
                            }
                            foreach (var worker in company.workers)
                            {
                                if (worker.departmentName == company.departments[num - 1].nameOfDepartment)
                                {
                                    workers.Add(worker);
                                }
                            }
                            company.PrintWorkers(workers);
                            Console.WriteLine("По какому полю сортируем(Имя - 1, Фамилия - 2, Возраст - 3, ID - 4, Зарплата - 5, Кол-во проектов - 6)");
                            num = Company.Check(6, 1);
                            Console.WriteLine("По какому еще полю сортируем(0 - не сортируем, Имя - 1, Фамилия - 2, Возраст - 3, ID - 4, Зарплата - 5, Кол-во проектов - 6)");
                            int num1 = Company.Check(6);
                            company.Sort(num, num1);
                            break;
                        case "8":
                            company.SerializeCompanyXML("_company.xml");
                            break;
                        case "9":
                            company.SerializeCompanyJSON("_company.json");
                            break;
                        case "10":
                            company.PrintAllDepartments();
                            break;
                        case "11":
                            company.PrintAllWorkers();
                            break;
                    }
                }
                else break;
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Новая информация для департамента
        /// </summary>
        /// <returns>Новая информация о департаменте</returns>
        public static (string,DateTime) CreateNew()
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
            return (name, date);
        }
        /// <summary>
        /// Новая информация для сотрдника
        /// </summary>
        /// <param name="company">Компания</param>
        /// <param name="departments">Департаменты</param>
        /// <param name="old">Новый/старый сотрудник</param>
        /// <returns>Новая информация о сотрднике</returns>
        public static (string,string,short,string,int,int,short) CreateNew(Company company, List<Department> departments, bool old)
        {
            Console.WriteLine("Введите имя сотрудника");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите возраст сотрудника");
            int age = Company.Check();
            Console.WriteLine("Введите ID сотрудника");
            int ID = Company.Check();
            Console.WriteLine("Введите зарплату сотрудника");
            int solary = Company.Check();
            Console.WriteLine("Введите кол-во проектов сотрудника");
            int project = Company.Check();
            Console.WriteLine("В каком депортаменте работает");
            company.PrintAllDepartments();
            if (departments.Count == 0)
            {
                Console.WriteLine("Департаментов нет");
                Console.WriteLine("Добавьте департамент, после добавляйте сотрудников");
                return(name, surname, (short)age, "None", ID, solary, (short)project);
            }
            else
            {
                int num = Company.Check(departments.Count);
                if (!old)
                {
                    departments[num - 1] = new Department(departments[num - 1].nameOfDepartment, departments[num - 1].dateOfCreate, departments[num - 1].numOfWorkers + 1);
                }
                return (name, surname, (short)age, departments[num - 1].nameOfDepartment, ID, solary, (short)project);
            }
        }
    }
}
