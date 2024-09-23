﻿using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        static void ExamineList()
        {
            List<string> theList = new List<string>();
            bool isActive = true;

            while (isActive)
            {
                Utils.RenderMenu("Examine List Menu", Constants.ExamineListMenuOptions);
                string input = Utils.AskForMenuOption("+/-(&& any name) OR the digit 0 to exit");

                char nav = input[0]; // detect the First sign (+ or -)
                string value = input.Substring(1).Trim().ToLower(); // rest of the value (name in the best case)

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"The name: {value} has been added to the List");
                        break;

                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.WriteLine($"The name: {value} has been deleted from the List");
                        }
                        else
                        {
                            Console.WriteLine($"The name {value} not been found.");
                        }
                        break;

                    case '0':
                        Console.WriteLine($"Back to Main Menu");
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Please enter som valid input (+, -) or 0 to exit");
                        break;
                }

                Console.WriteLine($"Ammount: {theList.Count}, Capasity: {theList.Capacity}");
            }
        }


        /* <summary>
        2. Listans kapacitet ökar när antalet element i listan överstiger dess nuvarande kapacitet. 
        När man  lägga till ett nytt element och listan inte har tillräckligt med plats, 
        skapas en ny array med en större kapacitet, och de gamla elementen kopieras över till den nya arrayen.

        3. Kapaciteten fördubblas varje gång den överskrids. 
        Om den initiala kapaciteten exempelvis är 4 och du lägger till ett femte element, kommer kapaciteten att öka till 8

        4. Kapaciteten fördubblas, genom att fördubbla kapaciteten sker minnesallokeringen mer sällan.
        Om kapaciteten ökade exakt för varje nytt element skulle det innebära att en ny array skulle behöva skapas och alla befintliga element kopieras varje gång ett element läggs till, vilket skulle bli mycket dyrt för prestandan
       
        5. Kapaciteten minskar inte automatiskt när element tas bort från listan. 
        För att anpassa den till det aktuella antalet element  => TrimExcess()

        6. I situationer där hög prestanda och minneskontroll är avgörande, kan en egendefinierad array vara det bästa alternativet. 
        Men om datamängden kan förändras eller om enkel användning är viktigare, kan en lista vara mer lämplig
       </summary> */


        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /* <summary>
        
        </summary> */
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

