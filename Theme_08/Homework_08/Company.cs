using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
	struct Company
	{
		public List<Worker> workers;
		public List<Department> departments;

		public Department AddNewDepartment()
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
			int numOfWorkers;
			Console.WriteLine("Введите кол-во сотрудников");
			while (true)
			{
				if (int.TryParse(Console.ReadLine(),out numOfWorkers)) break;
				Console.WriteLine("Некорректное значение");
			}
			Console.WriteLine("Вложенные департаменты");
			Console.WriteLine("Выбрать из существующих(1), добавить новый(2), таких нет(3)");
			int num;
			while (true)
			{
				if (int.TryParse(Console.ReadLine(),out num))
					if(num==1||num==2||num==3) break;
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
							inDep.Add(departments[int.Parse(Console.ReadLine())-1]);
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
			Console.WriteLine("Департамент добавлен");
            if(inDep.Count>0)return new Department(name, date, numOfWorkers);
			return new Department(name, date, numOfWorkers, inDep);
		}
		public void PrintAllDepartments()
		{
			if (departments.Count==0)Console.WriteLine("Нет департаментов");
            else
			{
                Console.WriteLine("Название\tДата\tСотрудники\tДепартаменты");
				foreach (var dep in departments)
				{
					Console.WriteLine($"{dep.nameOfDepartment}\t{dep.dateOfCreate}\t{dep.numOfWorkers}\t{dep.departments.Count}");
				}
			}
		}
	}
}
