using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SnakeGame
{
    class Food : Block // class Food extends Block
    {

        //fields
        private int points;
        private Color color;
        private SolidBrush sb;

        //constructor
        public Food(int x, int y, int width, int height, Color color) : base (x, y, width, height) // base reference the super class
        {
            points = 10;
            this.color = color;
            sb = new SolidBrush(this.color);
        }

        public void drawFood(Graphics e)
        {
           
            e.FillRectangle(sb, x, y, width, height);
            e.DrawRectangle(Pens.Black, x, y, width, height);
            
        }

        public int getPoints()
        {
            return points;
        }

        public void setPoints(int points)
        {
            this.points = points;
        }



    }
}
