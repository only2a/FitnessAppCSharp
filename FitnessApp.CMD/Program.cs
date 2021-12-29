using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;  
            var text = (@"                           ______ _ _                                            
                          |  ____(_) |                         /\                
                          | |__   _| |_ _ __   ___  ___ ___   /  \   _ __  _ __  
                          |  __| | | __| '_ \ / _ \/ __/ __| / /\ \ | '_ \| '_ \ 
                          | |    | | |_| | | |  __/\__ \__ \/ ____ \| |_) | |_) |
                          |_|    |_|\__|_| |_|\___||___/___/_/    \_\ .__/| .__/ 
                                                                    | |   | |    
                                                                    |_|   |_|");
            
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseBateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");
                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine();
        }

        private static DateTime ParseBateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения(dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}а");
                }
            }
        }
    }
}
