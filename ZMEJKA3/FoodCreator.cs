using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMEJKA3
{
    class FoodCreator
    {
        private int mapWidth;//peremennie hranat objekt klassa
        private int mapHeight;
        private char sym;

        public static int counter = 0; // счетчиk экземпляров еды

        Random random = new Random( );

        public FoodCreator(int mapWidth, int mapHeight, char sym)//v konstruktore peredaju koordinati karti, peremennie peredajutsa v ka4estve argumentov
        {
            this.mapWidth = mapWidth;//this.mapWidth eto perem-ja kot-ja hranit objekt klassa, mapWidth eto perem-ja argumenta
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()//proizvolnie koordinati v predelah karti
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            counter++;  // увеличиваем счетчик каждый раз когда создается еда
            return new Point(x, y, sym);//sozdaetsa to4ka s koordinatami
        }
    }
}
