using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangMadu
{
    internal class players
    {
        private string _failiTee = @"..\..\..\tulemus.txt"; // Path to the file

        public players() { }

        // Adds the player's name, score, and level to the text file
        public void Salvesta_faili(string nimi, int punktid, string level)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_failiTee, true))
                {
                    sw.WriteLine($"{nimi}: {punktid} points, Level: {level}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // Reads and displays the contents of the text file
        public void Naitab_faili()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_failiTee))
                {
                    string lines = sr.ReadToEnd();
                    Console.WriteLine(lines);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
