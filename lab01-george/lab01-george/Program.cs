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
            // this is a while loop so a player can keep asking questions
            while (playing)
            {
                int playCheck = MenuPrompt();
                if (playCheck == 1 || playCheck == 0)
                {
                    correctQuestions += playCheck;
                    totalQuestions++;
                }
                else if (playCheck == -2)
                {
                    continue;
                }
                else
                {
                    playing = false;
                    break;
                }
                Console.WriteLine();
                Console.Write("Would you like to ask another question?   ");
                playing = Question();
            }
            Console.WriteLine($"Thanks for playing! You answered {correctQuestions} correct out of {totalQuestions} asked.");
            Console.Read();
        }

        // this is the main menu
        static int MenuPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("George Quiz Menu");
            Console.WriteLine();
            Console.WriteLine("1. How old am I?");
            Console.WriteLine("2. Am I from Washington?");
            Console.WriteLine("3. What programming languages do I know?");
            Console.WriteLine("9. I'm done playing.");
            string selectionString = Console.ReadLine();
            int.TryParse(selectionString, out int selection);
            switch (selection)
            {
                case 1:
                    Console.WriteLine("You selected: 1.How old am I ?");
                    return NumberInput();
                case 2:
                    Console.WriteLine("You selected: 2. Am I from Washington?");
                    return Location();
                case 3:
                    Console.WriteLine("You selected: 3. What languages do I know?");
                    return LanguagePrompt();
                case 9:
                    Console.WriteLine("You selected: 9. I'm done playing.");
                    return selection;
                default:
                    selection = -2;
                    Console.WriteLine("Invalid selection!");
                    return selection;
            }
        }

        // checks for a yes response from a question
        static bool Question()
        {
            string answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer == "yes")
            {
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }
        }

        // this method just forces a user to input an integer
        // it could be reused for different number inputs with minor refactoring
        static int NumberInput()
        {
            bool badInput = true;
            Console.WriteLine("Please enter an integer");
            while (badInput)
            {// exception block on my only really fragile code
                string y = Console.ReadLine();
                try {
                    int z = Convert.ToInt32(y);
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
                catch (FormatException)
                {
                    Console.WriteLine("Please make another attempt to enter an integer");

                }
                catch (OverflowException e)
                {
                    // this wrecks things, but it was thrown
                    throw(e);
                }
                catch (Exception monkeybutt)
                {
                    Console.WriteLine($"You threw an {monkeybutt}! This is probably really bad!");
                    throw(monkeybutt);
                }
                finally
                {
                    Console.WriteLine("Have fun!");
                }
            }
            return 0;
        }

        // this checks for the age against hard coded values once we have a valid integer
        static bool CheckAge(int age)
        {
            if (age == 34)
            {
                Console.WriteLine("Correct, I'm 34!");
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

        // this asks for where I grew up
        static int Location()
        {
            if (TrueFalse())
            {
                Console.WriteLine("Sorry, I actually grew up in Georgia.");
                return 0;
            }
            else
            {
                Console.WriteLine("Correct, I actually grew up in Georgia.");
                return 1;
            }
        }

        // this gets a true response or returns false
        static bool TrueFalse()
        {// TODO potential try
            Console.WriteLine("Please enter true or false: ");
            string y = Console.ReadLine().ToLower();
            if (y == "true" || y == "t")
                return true;
            else
                return false;
        }

        // This looks a lot like the main menu
        // I was going to refactor this to feed both into a shared function but ran out of time
        static int LanguagePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("1. JavaScript");
            Console.WriteLine("2. Python");
            Console.WriteLine("3. F#");
            Console.WriteLine("4. C#");
            Console.WriteLine("5. Ruby");
            Console.WriteLine("6. SQL");
            Console.WriteLine("7. PHP");
            Console.WriteLine("8. Java");
            Console.WriteLine("9. I'm done playing.");
            // todo potential try
            string selectionString = Console.ReadLine();
            int.TryParse(selectionString, out int selection);
            switch (selection)
            {
                case 1:
                    Console.WriteLine("I know a little JavaScript, enough to do work.");
                    return 1;
                case 2:
                    Console.WriteLine("I know a little Python, enough to do work.");
                    return 1;
                case 3:
                    Console.WriteLine("I've heard of F# but I don't know it.");
                    return 0;
                case 4:
                    Console.WriteLine("Yes, C# is one of the languages I know best!");
                    return 1;
                case 5:
                    Console.WriteLine("I've heard of Ruby but I don't know it.");
                    return 0;
                case 6:
                    Console.WriteLine("Yes, SQL is one of the languages I know best!.");
                    return 1;
                case 7:
                    Console.WriteLine("I've heard of PHP but I don't know it.");
                    return 0;
                case 8:
                    Console.WriteLine("Yes, Java is one of the languages I know best!");
                    return 1;
                case 9:
                    Console.WriteLine("You selected: 9. I'm done playing.");
                    return selection;
                default:
                    Console.WriteLine("Invalid selection!");
                    break;
            }
            // we get here from an invalid selection so show the menu again
            LanguagePrompt();
            return 0;
        }
    }
}