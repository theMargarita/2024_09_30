namespace _2024_09_30
{
    class WordGuessingGame
    {
        //static string[] words = { "apple", "banana", "cherry", "date", "elderberry", "kiwi", "orange", "pineapple", "pear", "strawberrys", "blueberry", "zuccini" };

        static string[] schoolSubject = { "math", "language", "science", "sports", "geographic" };
        static string[] fruit = { "apple", "pineapple", "banana", "orange", "kiwi" };
        static string[] socialMedia = { "facebook", "instagram", "spotify", "twitter", "tiktok" };
        static string[][] wordsTogether = new string[][] { schoolSubject, fruit, socialMedia };

        static Random random = new Random();
        //static string[] words = wordsTogether[random.Next(0, 3)];



        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWord Guessing Game");
                Console.WriteLine("1. Play Game");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    PlayGame();
                }
                else if (choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void PlayGame()
        {
            int category = random.Next(wordsTogether.Length);
            //1[]category  2[]words
            string wordToGuess = wordsTogether[category][random.Next(wordsTogether[category].Length)];
            char[] guessedWord = new char[wordToGuess.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }



            int attemptsLeft = 6;
            bool giveUp = false;

            //give up choice when you have less than four attempts 
            while (attemptsLeft > 0 && !giveUp)
            {
                Console.WriteLine($"\nWord: {new string(guessedWord)}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Guess a letter: ");


                char guess = Console.ReadLine().ToLower()[0];
                bool correctGuess = false;

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                        correctGuess = true;
                    }
                }

                if (!correctGuess)
                {
                    attemptsLeft--;
                    Console.WriteLine("Incorrect guess!");
                }

                if (new string(guessedWord) == wordToGuess)
                {
                    Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}");
                    return;
                }
                //give up statement with yes or no
                if (attemptsLeft < 4)
                {
                    Console.WriteLine("Do you want to give up? (y/n)");
                    string yesORno = Console.ReadLine();
                    if (yesORno == "y")
                    {
                        giveUp = true;
                    }
                }
            }
            Console.WriteLine($"Game over! The word was: {wordToGuess}");
        }
    }
}
