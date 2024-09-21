using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangMadu
{
    internal class Menu 
    {

        private Sound sound;

        public Menu()
        {
            sound = new Sound();
            sound.PlayMenuSound();
        }

        public void Show()
        {
            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        sound.Stop(); 
                        ChooseLevel();
                        break;
                    case "2":
                        ShowScores();
                        break;
                    case "3":
                        Console.WriteLine("Mängust väljumine. Hüvasti!");
                        sound.Stop(); 
                        return; 
                    default:
                        Console.WriteLine("Ebakehtiv valik. Palun proovige uuesti.");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {


            Console.Clear();
            Console.WriteLine("Tere tulemast Maomängule!");
            Console.WriteLine("1. Mängida");
            Console.WriteLine("2. Näita tulemused");
            Console.WriteLine("3. Välja");
            Console.Write("Sisesta oma valik: ");
        }

        private void ChooseLevel()
        {
            Console.Clear();
            Console.WriteLine("Valige mängitav tase:");
            Console.WriteLine("1. Lihtne");
            Console.WriteLine("2. Keskmine");
            Console.WriteLine("3. Kõva");
            Console.Write("Sisesta oma valik: ");

            string levelChoice = Console.ReadLine();
            BaseLevel level;
            string levelName;

            switch (levelChoice)
            {
                case "1":
                    level = new EasyLevel();
                    levelName = "Lihtne";
                    break;
                case "2":
                    level = new MediumLevel();
                    levelName = "Keskmine";
                    break;
                case "3":
                    level = new HardLevel();
                    levelName = "Kõva";
                    break;
                default:
                    Console.WriteLine("Ebakehtiv valik. Tagasi menüüsse.");
                    return; 
            }

            
            sound.Stop();

            Sound levelSound = new Sound();
            if (levelName == "Lihtne")
                levelSound.PlayEasyLevel();
            else if (levelName == "Keskmine")
                levelSound.PlayMediumLevel();
            else if (levelName == "Kõva")
                levelSound.PlayHardLevel();


            
            int score = level.PlayLevel(); 
            levelSound.Stop(); 
            SaveScore(score, level.Name);
        }



        private void SaveScore(int score, string levelName)
        {
            Console.WriteLine("Mäng läbi! Sisesta oma nimi:");
            string name = Console.ReadLine();
            players mängijad = new players();
            // Salvesta skoor, mängija nimi ja taseme nimi faili
            mängijad.Salvesta_faili(name, score, levelName); // Save the score and level
            Console.WriteLine("Skoor salvestatud! Vajutage suvalist võtit, et menüüsse naasta...");
            Console.ReadKey();
            sound.PlayMenuSound();
        }

        private void ShowScores()
        {
            sound.Stop();
            players mängijad = new players();
            Console.Clear();
            Console.WriteLine("Tulemused:");
            // meetod, kuidas kuvada failist saadud hindeid
            mängijad.Naitab_faili();
            Console.WriteLine("Vajutage suvalist võtit, et menüüsse naasta...");
            Console.ReadKey();
            sound.PlayMenuSound();
        }
    }
}
