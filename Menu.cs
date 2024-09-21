using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangMadu
{
    internal class Menu
    {
        public void Show()
        {
            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ChooseLevel();
                        break;
                    case "2":
                        ShowScores();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the game. Goodbye!");
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Sound soundManager = new Sound(@"..\..\..\Music"); // Adjust this path as necessary
            soundManager.PlayMenuSound();


            Console.Clear();
            Console.WriteLine("Welcome to the Snake Game!");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Show Scores");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
        }

        private void ChooseLevel()
        {
            Console.Clear();
            Console.WriteLine("Choose a level to play:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Enter your choice: ");

            string levelChoice = Console.ReadLine();
            BaseLevel level;
            string levelName;

            switch (levelChoice)
            {
                case "1":
                    level = new EasyLevel();
                    levelName = "Easy";
                    break;
                case "2":
                    level = new MediumLevel();
                    levelName = "Medium";
                    break;
                case "3":
                    level = new HardLevel();
                    levelName = "Hard";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to menu.");
                    return; // Return to the main menu
            }

            // Play the level and capture the score
            int score = level.PlayLevel();
            SaveScore(score, levelName);
        }

        private void SaveScore(int score, string levelName)
        {
            Console.WriteLine("Game Over! Enter your name:");
            string name = Console.ReadLine();

            players mängijad = new players();
            mängijad.Salvesta_faili(name, score, levelName); // Save the score and level
            Console.WriteLine("Score saved! Press any key to return to the menu...");
            Console.ReadKey();
        }

        private void ShowScores()
        {
            players mängijad = new players();
            Console.Clear();
            Console.WriteLine("Scores:");
            mängijad.Naitab_faili();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
