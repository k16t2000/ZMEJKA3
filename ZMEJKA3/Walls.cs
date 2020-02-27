using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMEJKA3
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            //otrisovka ramo4ki
            HorizontalLIne UpLine = new HorizontalLIne(0, mapWidth - 2, 0, '+');
            HorizontalLIne DownLine = new HorizontalLIne(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftline = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightline = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            wallList.Add(UpLine);
            wallList.Add(DownLine);
            wallList.Add(leftline);
            wallList.Add(rightline);
        }
        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }

    }
}
