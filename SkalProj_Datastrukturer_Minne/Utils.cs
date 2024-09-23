using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class Utils
    {
        public static string AskForMenuOption(string prompt)
        {

            bool success = false;
            string answer;

            do
            {
                Console.Write($"Enter the a valid input: {prompt}:");
                answer = Console.ReadLine() ?? "";
                if (answer == "0") success = true;

                if (string.IsNullOrWhiteSpace(answer) || answer.Length < 2)
                {
                    Console.WriteLine($"You must enter a valid {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }


        public static void RenderMenu(string menuTitle, string[] menuOptions)
        {
            Console.WriteLine("*********************");
            Console.WriteLine(menuTitle);

            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine("*********************");
            Console.WriteLine("");
        }
    }
}