using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnakeGame
{
    class Collision
    {
        //constructor
        public Collision() { }

        //methods
        public bool collisionWithWall(Snake s)
        {
          
            if ((s.getSnakeHead().getX()) < 0)
                return true;
            else if ((s.getSnakeHead().getX() + s.getSnakeHead().getWidth()) > 650)
                return true;
            else if ((s.getSnakeHead().getY()) < 0)
                return true;
            else if ((s.getSnakeHead().getY() + s.getSnakeHead().getHeight()) > 350)
                return true;

            return false; // no collision

        }

        public bool collisionWithFood(Snake s, Food f)
        {           
            if(s.getSnakeHead().getX() == f.getX())
                if(s.getSnakeHead().getY() == f.getY())
                   return true;

            return false;

        }

        public bool collisionWithItself(Snake s)
        {

            int snake_length = s.getSnakeBody().Count;
            if (snake_length > 1)
            {
                for (int i = 1; i < snake_length; i++)
                {
                    if (s.getElement(i).getX() == s.getSnakeHead().getX() &&
                        s.getElement(i).getY() == s.getSnakeHead().getY())
                        return true;
                }


             }

           
            return false;
        }

    }
}
