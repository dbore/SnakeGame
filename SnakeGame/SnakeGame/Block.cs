using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Block
    {

        //fields
        protected int x;
        protected int y;
        protected int height;
        protected int width;

        //constructors
        public Block()
        {
            x = 0;
            y = 0;
            height = 10;
            width = 10;
        }

        public Block(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.width = 10;
            this.height = 10;

        }

        public Block(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

        }

        //methods

        //getters 
        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        //setters
        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setWidth(int w)
        {
            this.width = w;
        }

        public void setHeight(int h)
        {
            this.height = h;
        }


    }
}
