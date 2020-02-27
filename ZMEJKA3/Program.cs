using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.Diagnostics;//Stopwatch

namespace ZMEJKA3
{
    
    class Program
    {
        private static int counter2 = 0;
        private static int speed = 0;

        

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);//80,25 v uroke
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            
            Walls walls = new Walls(80, 25);
            walls.Draw();

            

            Music();
            
            //otrisovka to4ek
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            //Console.ReadLine();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');//klass FoodCreator to4ek edi, 80,25-gabariti karti i simvol edi $
            Point food = foodCreator.CreateFood();//kazdij raz pri vizove metoda, v oblasti karti budet proizvolno pojavlatsa eda(metod food vernet to4ku)
            food.Draw(ConsoleColor.DarkRed);//vivod na ekran

            var sw = new Stopwatch();//sozdaem objekt klassa stopwatch
            sw.Start();//vizivaem metod Start, dlja vis4eta metoda ispolnenija



            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                    
                }
                if (snake.Eat(food)) //vozrashaet ili pravdu ili loz
                {
                    counter2++;
                    Speed();
                    food = foodCreator.CreateFood();
                    food.Draw(ConsoleColor.Red);
                    
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();//s4itivaet knopki
                    snake.HandleKey(key.Key);//vizivaem funkziju na dvizenie zmejki
                }
            }

            sw.Stop();
            Console.WriteLine($"\n\n\n\n\n\t\t\tTime spent: {sw.Elapsed}",Console.ForegroundColor=ConsoleColor.Red);
            WriteGameOver();
            
            Console.ReadLine();


        }


        
        

      
       
        static void Speed()
        {
            if (counter2 % 2 == 0)
            {
                speed += 1;
            }
        }
        static void Music()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"C:\Users\37255\Desktop\C#\ZMEJKA3\ZMEJKA3\tetris.wav";
            player.Play();
        }
        static void MessageFood()
        {
            
            Console.WriteLine("\n\t\t\tWas displayed {0} food", FoodCreator.counter);
            
        }
        static void WriteGameOver()
        {

            //int xOffset = 25;
            //int yOffset = 8;
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.SetCursorPosition(xOffset, yOffset++);
            // WriteText("============================", xOffset, yOffset++);
            //WriteText("Game is over", xOffset + 1, yOffset++);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\t\t\t==========================");
            Console.WriteLine("\n\nt\t\t\t\tGAME IS OVER");
            Console.WriteLine("\n\n\t\t\t\t{0}, ate \n", counter2);
            MessageFood();
            
            Console.WriteLine("\n\n\t\t\t==========================");
            //Console.WriteLine("{0,10},You have got {0} of food <FoodCreator>", FoodCreator.counter);
            //yOffset++;
            //WriteText("AUTOR: xxxxx", xOffset + 1, yOffset++);
            //WriteText(" NOT SIMPLE:)", xOffset + 5, yOffset++);
            //WriteText("\n\t\t\t============================", xOffset, yOffset++);
        }
        /*static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }*/
    }
}
