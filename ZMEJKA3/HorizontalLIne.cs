using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMEJKA3
{
    class HorizontalLIne : Figure
    {
        public HorizontalLIne(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }

        }
        /*public override void Draw()
        {
            Console.ForegroundColor=ConsoleColor.Yellow;

            base.Draw();

            Console.ForegroundColor = ConsoleColor.White;

        }*/
    }
}
