using System;

namespace lab01_george
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playing = true;
            int correctQuestions = 0;
            int totalQuestions = 0;

            while (playing)
            {
                int playCheck = MenuPrompt();
                if (playCheck == 1 || playCheck == 0)
                {
                    correctQuestions += playCheck;
                    totalQuestions++;
                }
                else if (playCheck == 2)
                {
                    continue;
                }
                else
                {
                    playing = false;
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to ask another question? (type y)");
                playing = Question();
            }
            Console.WriteLine($"You answered {correctQuestions} correct out of {totalQuestions} asked.");
            Console.Read();
        }

        static int MenuPrompt(/*string[] choices*/)
        {
            Console.WriteLine();
            Console.WriteLine("1. How old am I?");
            Console.WriteLine("2. Where did I grow up?");
            Console.WriteLine("3. What programming languages do I know?");
            Console.WriteLine("9. I'm done playing.");
            string selectionString = Console.ReadLine();
            int.TryParse(selectionString, out int selection);

            switch (selection)
            {
                case 1:
                    Console.WriteLine("You selected: 1.How old am I ?");
                    return Age();
                case 2:
                    Console.WriteLine("You selected: 2. Where did I grow up?");
                    return MultipleChoice(2);
                case 3:
                    Console.WriteLine("You selected: 3. What languages do I know?");
                    return MultipleChoice(3);
                case 9:
                    selection = 0;
                    Console.WriteLine("You selected: 9. I'm done playing.");
                    return selection;
                default:
                    selection = 2;
                    Console.WriteLine("Invalid selection!");
                    return selection;
            }
        }

        static bool Question()
        {
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int Age()
        {
            bool badInput = true;
            Console.WriteLine("Please enter an integer");
            while (badInput)
            {

                string y = Console.ReadLine();

                if (int.TryParse(y, out int z))
                {
                    badInput = false;
                    if (CheckAge(z))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine("Please make another attempt to enter an integer");
                }
            }
            return 0;
        }

        static bool CheckAge(int age)
        {
            if (age == 34)
            {
                Console.WriteLine("Correct!");
                return true;
            }
            else if (age > 34 && age < 99)
            {
                Console.WriteLine("Sorry, too high.");
                return false;
            }
            else if (age < 34 && age > 1)
            {
                Console.WriteLine("Sorry, too low.");
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, not a realistic age.");
                return false;
            }
        }

        // I was mid refactoring this when time ran out
        static int MultipleChoice(int selection)
        {
            if (selection == 1)
            {
                // main menu
                //string[] selections = new string[] {" "};
                //char[] arr = new char[] { 'a', 'b', 'c' };
            }
            else if (selection == 2)
            {
                // locations
                return 1;
            }
            else if (selection == 3)
            {
                // languages
                return 1;
            }
            else
            {
                // this will not be reched by normal operation currently.
                return 0;
            }
            // neither will this
            return 0;
        }
    }
}
