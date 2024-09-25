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

                if (string.IsNullOrWhiteSpace(answer))
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


        public static void RenderMenu(Constants.MenuOption menuTitle)
        {
            string[] menuOptions = GetMenuOptions(menuTitle);

            Console.WriteLine("*********************");
            Console.WriteLine($"Examine {menuTitle} Menu");

            foreach (string option in menuOptions)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine("*********************");
            Console.WriteLine("");
        }

        public static string[] GetMenuOptions(Constants.MenuOption menuTitle)
        {
            switch (menuTitle)
            {
                case Constants.MenuOption.List:
                    return
                    [
                $"Press +(exact name) to add a name to the {menuTitle}",
                $"Press -(exact name) to remove a name from the {menuTitle}",
                "Press the digit 0 to exit to the Main Menu"
                    ];

                case Constants.MenuOption.Queue:
                    return
                    [
                $"Press +(exact name) to add a name to the {menuTitle}",
                $"Press - to remove FIFO name from the {menuTitle}",
                "Press the digit 0 to exit to the Main Menu"
                    ];

                case Constants.MenuOption.Stack:
                    return
                    [
                $"Press +(exact name) to add a name to the {menuTitle}",
                $"Press - to remove LIFO name from the {menuTitle}",
                "Press the digit 0 to exit to the Main Menu"
                    ];

                default:
                    return ["Invalid menu option. Please try again."];
            }
        }

        public static bool IsFormattingCorrect (char openParanthese, char closeParanthese)
        {
            return (openParanthese == '(' && closeParanthese == ')') ||
                   (openParanthese == '{' && closeParanthese == '}') ||
                   (openParanthese == '[' && closeParanthese == ']');
        }

    }
}