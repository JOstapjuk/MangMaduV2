using System;
using System.Runtime.Serialization;
namespace MangMadu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Snake Game";

            Menu menu = new Menu();
            menu.Show(); // Call the Show method to display the menu

            Console.ResetColor();
        }
    }
}