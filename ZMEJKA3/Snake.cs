using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ZMEJKA3
{
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw(ConsoleColor.Magenta);
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        

        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
                
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)//otve4aet kak reagiruet na nazatie klavish
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }
        public void Speech()
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output.   
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
            synth.Volume = 100;  // (0 - 100)
            synth.Rate = 1;     // (-10 - 10)
            // Speak a string.  
            synth.Speak("Got it!");
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();//GetNextPoint-funkzija vi4islaet v kakoj to4ke zmejka okazitsa v sledujushij moment, polu4aju to4ku sootvetstvujushuju sledujumu polozeniju golovi
            if (head.IsHit(food))//esli to4ka head sovpadet s edoj, to budet akt pitanija, v protivnom slu4ae net
            {
                food.sym = head.sym;//to4ka udlinaetsa sootvetstvujushaja ede
                pList.Add(food);//dobavili v spisok
                Point tail = pList.Last();//dlja uvele4enija hvosta
                Point nextPoint = new Point(tail);
                pList.Add(tail);//uveli4ila hvost
                Speech();

                return true;//akt pitanija sostojalsja
            }
            else
                return false;
        }
    }

    
}
