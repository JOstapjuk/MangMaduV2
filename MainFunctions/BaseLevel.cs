using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangMadu
{
    //
    internal abstract class BaseLevel
    {

        //abstract - klass on malliks kõikidele alamklassidele
        public abstract string Name { get; }
        public abstract ConsoleColor Color { get; }
        public abstract int Speed { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }

        public int PlayLevel()
        {
            Console.Clear();
            Console.ForegroundColor = Color;
            Console.WriteLine($"Lähtetase: {Name}");
           
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

            DisplayScore(score, Width + 5, 2);

            while (true)
            {
                if (walls.isHit(snake) || snake.isHitTail())
                {
                    Sound sound = new Sound();
                    sound.PlayWallTailHitSound();

                    break;
                }

                for (int i = 0; i < foods.Count; i++)
                {
                    if (snake.Eat(foods[i].food))
                    {
                        score += foods[i].points; // Lisa söödud toidust punktid
                        foods.RemoveAt(i); // Eemalda söödud toit nimekirjast
                        foods.Add(foodCreator.CreateFoods(1)[0]); // Uue toidukauba loomine
                        foods[foods.Count - 1].food.Draw(); // Joonista uus toit

                        Sound sound = new Sound();
                        sound.PlayEatFoodSound();

                        DisplayScore(score, Width + 5, 2);

                        break; 
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

            Console.SetCursorPosition(0, Height + 2);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"You scored: {score}.");


            return score;
        }


        private void DisplayScore(int score, int x, int y)
        {
            Console.SetCursorPosition(x, y); // Määra kursori asend väljaspool mänguala
            Console.ForegroundColor = Color; // Määra hindeteksti värv
            Console.Write($"Score: {score}  "); 
        }

    }
}
