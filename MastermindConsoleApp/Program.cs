using System;
using System.Linq;

namespace MasterMindConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            welcomeToTheGame();
            explainTheRules();

            char[] hintsArray = new char[4];
            int[] compysArray = getCompysNumber();            
            int[] playersArray = new int[4];
            bool doArraysMatch = false;

            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"You have {i} turns left.");
                playersArray = getPlayersNumber();
                doArraysMatch = compareBothArrays(playersArray, compysArray);

                if (doArraysMatch == true)
                {
                    break;
                }
            }

            if (doArraysMatch == false)
            {
                Console.WriteLine("Well, you didn't guess my number. Too bad.\n");
            }

            Console.WriteLine("I hope you had fun! Press ENTER to close the game.");
            Console.ReadLine();

        }

        public static int[] getCompysNumber()
        {
            int[] compysNumber = new int[4];

            for (int i = 0; i < compysNumber.Length; i++)
            {
                Random rnd = new Random();
                compysNumber[i] = rnd.Next(1, 7); //this tends to produce four of the same digit
                    //but not when I'm debugging -- is it too fast, maybe?
            }

            //this just confirms the number if you want to test it while playing:
            //keep in for easy troubleshooting
            //Console.WriteLine("To confirm the number during writing the program:");
            //for (int i = 0; i < compysNumber.Length; i++)
            //    Console.Write(compysNumber[i]);
            //Console.WriteLine("\n");

            Console.WriteLine("I am thinking of a 4-digit number; all digits are between 1 and 6.");
            Console.WriteLine("Press ENTER to start your guesses.");
            Console.ReadLine();

            return compysNumber;
        }

        public static int[] getPlayersNumber()
        {
            Console.WriteLine("Enter a four digit number, with each digit being from 1-6.");
            int playersGuess = Convert.ToInt32(Console.ReadLine());

            string playersArrayAsString = playersGuess.ToString();
            int[] playersArray = new int[4];
            int idx = 0;

            foreach (char digit in playersArrayAsString)
            {
                int x = (int)Char.GetNumericValue(digit);
                playersArray[idx] = x;
                idx++;
            }

            return playersArray;
        }

        public static bool compareBothArrays(int[] playersArray, int[] compysArray)
        {
            bool doArraysMatch = false;

            char[] hintsArray = new char[] { '_', '_', '_', '_' }; 

            if (playersArray.SequenceEqual(compysArray))
            {
                doArraysMatch = true; 
                Console.WriteLine("Congrats, you read my mind!\n");
                return doArraysMatch;
            }
            else
            {
                GiveHintWhenTwoArraysDoNotMatch(playersArray, compysArray, hintsArray);
            }

            Console.WriteLine("Here is your hint for the next try:");
            for (int k = 0; k < hintsArray.Length; k++)
            {
                Console.Write(hintsArray[k]);
            }
            Console.WriteLine("\n");   

            return doArraysMatch;
        }

        private static void GiveHintWhenTwoArraysDoNotMatch(int[] playersArray, int[] compysArray, char[] hintsArray)
        {
            for (int i = 0; i < playersArray.Length; i++)
            {
                if (compysArray.Contains(playersArray[i]))
                {
                    hintsArray[i] = '-';
                }
                if (playersArray[i] == compysArray[i])
                {
                    hintsArray[i] = '+';
                }
            }
        }

        public static void welcomeToTheGame()
        {
            Console.WriteLine("Welcome to my mind-reading game!\n");
            Console.WriteLine("I'm going to think of a 4-digit number. ");
            Console.WriteLine("Each digit will be from 1-6 only.\n");
            Console.WriteLine("I will give you 10 tries to guess the number,");
            Console.WriteLine("giving you hints to help you get it right.");
            Console.WriteLine("Press ENTER to read the rules.\n");
            Console.ReadLine();
        }

        public static void explainTheRules()
        {
            Console.WriteLine("Here's how you play:\n");
            Console.WriteLine("Type in 4 digits (each one between 1 and 6 only!) and hit enter.");
            Console.WriteLine("If any of your digits match my digits, I'll mark a + in that spot.");
            Console.WriteLine("If any of your digits match any of my digits (but in the wrong spot), I'll mark an - in that spot.");
            Console.WriteLine("And if any of your digits are nowhere in my number, I'll mark those with a blank (_).");
            Console.WriteLine("I will let you know if you guess my number! You have 10 tries.\n");

            Console.WriteLine("Press ENTER to start the game.\n");
            Console.ReadLine();
        }
    }
}

