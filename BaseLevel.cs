using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangMadu
{
    internal abstract class BaseLevel
    {
        public abstract string Name { get; }
        public abstract ConsoleColor Color { get; }
        public abstract int Speed { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }

        public int PlayLevel()
        {
            Console.Clear();
            Console.ForegroundColor = Color;
            Console.WriteLine($"Starting level: {Name}");

            Sound soundManager = new Sound(@"..\..\..\Music"); // Adjust this path as necessary
            if (Name == "Easy")
                soundManager.PlayEasyLevel();
            else if (Name == "Medium")
                soundManager.PlayMediumLevel();
            else if (Name == "Hard")
                soundManager.PlayHardLevelMusic();

            Walls walls = new Walls(Width, Height);
            walls.Draw();

            Point p = new Point(4, 5, '#');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            // Create multiple food items
            FoodCreator foodCreator = new FoodCreator(Width, Height);
            List<(Point food, int points)> foods = foodCreator.CreateFoods(3); // Create 3 food items

            foreach (var (food, points) in foods)
            {
                food.Draw();
            }

            int score = 0;

            while (true)
            {
                if (walls.isHit(snake) || snake.isHitTail())
                {
                    soundManager.PlayWallTailHitSound();

                    break;
                }

                // Check if the snake eats any food
                for (int i = 0; i < foods.Count; i++)
                {
                    if (snake.Eat(foods[i].food))
                    {
                        score += foods[i].points; // Add the points from the eaten food
                        foods.RemoveAt(i); // Remove eaten food from the list
                        foods.Add(foodCreator.CreateFoods(1)[0]); // Generate a new food item
                        foods[foods.Count - 1].food.Draw(); // Draw the new food

                        soundManager.PlayEatFoodSound();

                        break; // Exit the loop after eating food
                    }
                }

                snake.Move();

                Thread.Sleep(Speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            Console.WriteLine($"Game Over! You scored: {score}. Press any key to continue...");
            Console.ReadKey();

            return score;
        }

    }
}
