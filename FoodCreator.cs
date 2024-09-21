using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangMadu
{
    // Klass toidu loomiseks ja mis loob toitu randomsele kohale
    internal class FoodCreator
    {
        private int mapWidth;
        private int mapHeight;
        private List<NewFood> foodItems;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            // Initialize different food items with symbols and points
            foodItems = new List<NewFood>
            {
                new NewFood('$', 1),  // Normal food
                new NewFood('*', 2),  // Special food
                new NewFood('@', 3)   // Rare food
            };
        }

        public List<(Point, int)> CreateFoods(int count) // Returns a list of tuples (Point, Points)
        {
            var foods = new List<(Point, int)>();

            for (int i = 0; i < count; i++)
            {
                int x = random.Next(2, mapWidth - 2);
                int y = random.Next(2, mapHeight - 1);
                var foodItem = foodItems[random.Next(foodItems.Count)];

                foods.Add((new Point(x, y, foodItem.Symbol), foodItem.Points));
            }

            return foods;
        }
    }
}
