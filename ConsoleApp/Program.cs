using BusinessLogic;
using DataAccessLayer;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.Logic;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            Logic logic = ninjectKernel.Get<Logic>();

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("\n=== Система управления студентами ===");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Показать всех студентов");
                Console.WriteLine("4. Показать статистику по специальностям");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n=== Добавление студента ===");

                        Console.Write("ФИО: ");
                        string name = Console.ReadLine();

                        Console.Write("Специальность: ");
                        string speciality = Console.ReadLine();

                        Console.Write("Группа: ");
                        string group = Console.ReadLine();

                        Console.Write("Номер зачетки: ");
                        string studentNumber = Console.ReadLine();

                        try
                        {
                            if (logic.AddStudent(name, speciality, group, studentNumber))
                            {
                                Console.WriteLine("Студент добавлен успешно");
                            }
                            else
                            {
                                Console.WriteLine("Нельзя добавить студентов с одинаковым номером зачетной книжки");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n=== Удаление студента ===");

                        Console.Write("Введите ID студента: ");
                        int ID = Convert.ToInt16(Console.ReadLine());

                        try
                        {
                            if (logic.DeleteStudent(ID))
                            {
                                Console.WriteLine("Студент удален");
                            }
                            else
                            {
                                Console.WriteLine("Возникла ошибка при попытке удаления");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        break;
                        //logic.DeleteStudent(ID);
                        //break;

                    case "3":
                        Console.WriteLine("\n=== Список всех студентов ===");

                        var students = logic.GetAllStudents();
                        foreach (var student in students)
                        {
                            Console.WriteLine(student);
                        }
                        break;

                    case "4":
                        Console.WriteLine("\n=== Статистика по специальностям ===");

                        logic.PrintSpecialityHistogram();
                        break;

                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Недопустимое значение");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения....");
                    Console.ReadKey();
                }
            }
        }
    }
}
