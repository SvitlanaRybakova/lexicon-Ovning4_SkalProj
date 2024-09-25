using System;

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
                    + "\n5. RecursiveEven"
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
                        ExamineCollection(new List<string>(), Constants.MenuOption.List, AddToList, RemoveFromList);
                        break;
                    case '2':
                        ExamineCollection(new Queue<string>(), Constants.MenuOption.Queue, AddToQueue, RemoveFromQueue);
                        break;
                    case '3':
                        ExamineCollection(new Stack<string>(), Constants.MenuOption.Stack, AddToStack, RemoveFromStack);
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        CalculateAndDisplay(RecursiveEven, 5);
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


        static void ExamineCollection<T>(T collection, Constants.MenuOption menuTitle, Action<T, string> addAction, Func<T, string, bool> removeAction) where T : IEnumerable<string>
        {
            bool isActive = true;

            while (isActive)
            {
                Utils.RenderMenu(menuTitle);
                string input = Utils.AskForMenuOption("+/- (& exact name) OR the digit 0 to exit");

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a valid input.");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1).Trim().ToLower();

                switch (nav)
                {
                    case '+':
                        addAction(collection, value);
                        break;

                    case '-':
                        if (removeAction(collection, value))
                        {
                            Console.WriteLine($"The name '{value}' has been deleted.");
                        }
                        else
                        {
                            Console.WriteLine($"The name '{value}' was not found.");
                        }
                        break;

                    case '0':
                        Console.WriteLine("Back to Main Menu");
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input (+, -) or 0 to exit");
                        break;
                }

                DisplayCollectionStatus(collection);
            }
        }

        // List
        static void AddToList(List<string> list, string value) => list.Add(value);
        static bool RemoveFromList(List<string> list, string value) => list.Remove(value);

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


        // Queue
        static void AddToQueue(Queue<string> queue, string value) => queue.Enqueue(value);
        static bool RemoveFromQueue(Queue<string> queue, string value)
        {
            if (queue.Count > 0)
            {
                queue.Dequeue();
                return true;
            }
            if (queue.Count == 0) Console.WriteLine("Queue is empty");
            return false;
        }

        /* <summary>
         FIFO = First in, First Out
        </summary> */


        // Stack
        static void AddToStack(Stack<string> stack, string value) => stack.Push(value);
        static bool RemoveFromStack(Stack<string> stack, string value)
        {
            if (stack.Count > 0)
            {
                stack.Pop();
                return true;
            }
            if (stack.Count == 0) Console.WriteLine("Stack is empty");
            return false;
        }

        static void DisplayCollectionStatus<T>(T collection) where T : IEnumerable<string>
        {
            string collectionName = collection.GetType().Name;

            if (collection is List<string> list)
            {
                Console.WriteLine($"Ammount: {list.Count}, Capasity: {list.Capacity}");
            }
            if (collection is Queue<string> queue)
            {
                Console.WriteLine($"Ammount in queue: {queue.Count}");
            }
            if (collection is Stack<string> stack)
            {
                Console.WriteLine($"Ammount in stack: {stack.Count}");
            }

            Console.WriteLine($"Current values in {collectionName}: {string.Join(", ", collection)}");
        }
        /* <summary>
         LIFO = Last in, First Out
       </summary> */

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            string input = "(())}";
            Stack<char> stack = new Stack<char>();

            foreach (char currentParanthese in input)
            {
                if (currentParanthese == '(' || currentParanthese == '{' || currentParanthese == '[')
                {
                    stack.Push(currentParanthese); // Push to stack
                }
                else if (currentParanthese == ')' || currentParanthese == '}' || currentParanthese == ']')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Incorrect formatting");
                        return;
                    }

                    char parantheseInStack = stack.Pop(); // Get the last opening bracket from the stack
                    if (!Utils.IsFormattingCorrect(parantheseInStack, currentParanthese))
                    {
                        Console.WriteLine("Incorrect formatting");
                        return;
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("Formatting is correct");
            }
            else
            {
                Console.WriteLine("Incorrect formatting");
            }
        }

        delegate int EvenNumberCallback(int n);
        static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 2;
            }
            return RecursiveEven(n - 1) + 2;
        }

        static void CalculateAndDisplay(EvenNumberCallback callback, int n)
        {
            int evenNumber = callback(n);  
            Console.WriteLine($"The {n}th even number is: {evenNumber}");
        }




    }
}

