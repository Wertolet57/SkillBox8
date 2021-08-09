﻿using System;
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

            /// Создать прототип информационной системы, в которой есть возможност работать со структурой организации
            /// В структуре присутствуют департаменты и сотрудники
            /// Каждый департамент может содержать не более 1_000_000 сотрудников.
            /// У каждого департамента есть поля: наименование, дата создания,
            /// количество сотрудников числящихся в нём 
            /// (можно добавить свои пожелания)
            /// 
            /// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
            /// уникальный номер, размер оплаты труда, количество закрепленным за ним.
            ///
            /// В данной информаиционной системе должна быть возможность 
            /// - импорта и экспорта всей информации в xml и json
            /// Добавление, удаление, редактирование сотрудников и департаментов
            /// 
            /// * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
            /// по нескольким полям, например возрасту и оплате труда
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            /// 
            /// 
            /// Упорядочивание по одному полю возраст
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 
            ///
            /// Упорядочивание по полям возраст и оплате труда
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 
            /// 
            /// Упорядочивание по полям возраст и оплате труда в рамках одного департамента
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3
            Company company = new Company();
            company.workers = new List<Worker>();
            company.departments = new List<Department>();
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
                            company.AddNewDepartment();
                            break;
                        case "2":
                            company.DeleteDepartment();
                            break;
                        case "3":
                            company.ChangeDepartments();
                            break;
                        case "4":
                            company.AddWorker();
                            break;
                        case "5":
                            company.DeleteWorker();
                            break;
                        case "6":
                            company.ChangeWorker();
                            break;
                        case "7":
                            company.Sort();
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
    }
}
