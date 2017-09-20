using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;


namespace SnakeGame
{
    class Snake
    {
        //fields
        private int x , y;
        private int width, height;
        private List<Block> snake_body;
        private Color snake_color;
        private SolidBrush sb;
        private int points;

        //constructor/s
        public Snake(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            snake_body = new List<Block>();
            this.snake_color = Color.Blue;
            sb = new SolidBrush(Color.Blue);
            this.points = 0;
        }
        public Snake(int x, int y, int width, int height, Color snake_color)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            snake_body = new List<Block>();
            this.snake_color = snake_color;
            sb = new SolidBrush(snake_color);
            this.points = 0;
        }

        //methods
        public void incrementSnake(){
            //check if snake is empty
            if (snake_body.Count == 0)
            {
                snake_body.Add(new Block(x, y, width, height));
            }
            else
            {
                int snake_length = snake_body.Count;
                Block b = snake_body.ElementAt(snake_length - 1);
                snake_body.Add(new Block(b.getX() - width, b.getY(), width, height));
            }
        }

        public void drawSnake(Graphics e)
        {
            int brightness = 255;
            int snake_length = snake_body.Count;

            //color the snake head
            e.FillRectangle(Brushes.Black, getSnakeHead().getX(), getSnakeHead().getY(), getSnakeHead().getWidth(), getSnakeHead().getHeight());
            e.DrawRectangle(Pens.Black, getSnakeHead().getX(), getSnakeHead().getY(), getSnakeHead().getWidth(), getSnakeHead().getHeight());

            for (int i = 1; i < snake_length; i++)
            {
                sb = new SolidBrush(Color.FromArgb(brightness, sb.Color.R, sb.Color.G, sb.Color.B));
                e.FillRectangle(sb, snake_body.ElementAt(i).getX(), snake_body.ElementAt(i).getY(), snake_body.ElementAt(i).getWidth(), snake_body.ElementAt(i).getHeight());
                e.DrawRectangle(Pens.Black, snake_body.ElementAt(i).getX(), snake_body.ElementAt(i).getY(), snake_body.ElementAt(i).getWidth(), snake_body.ElementAt(i).getHeight());

                if (brightness - 2 >= 150)
                {
                    brightness = brightness - 2;
                }
            }
            
          
        }

        public void moveSnake(int direction)
        {
            
            int snake_length = snake_body.Count;
            int temp_x = snake_body.ElementAt(0).getX();
            int temp_y = snake_body.ElementAt(0).getY();

            if (direction == 0)
                {
                    //move snake up
                    snake_body.ElementAt(0).setY(snake_body.ElementAt(0).getY() - height);
                }
                else if (direction == 1)
                {
                    //move snake down
                    snake_body.ElementAt(0).setY(snake_body.ElementAt(0).getY() + height);
                }
                else if (direction == 2)
                {
                    //move snake left
                    snake_body.ElementAt(0).setX(snake_body.ElementAt(0).getX() - width);
                }
                else if (direction == 3)
                {
                    //move snake right
                    snake_body.ElementAt(0).setX(snake_body.ElementAt(0).getX() + width);
                }

            //follow the snake head
            for (int i = 1; i < snake_length; i++)
            {
                int tmp_x = snake_body.ElementAt(i).getX();
                int tmp_y = snake_body.ElementAt(i).getY();
                snake_body.ElementAt(i).setX(temp_x);
                snake_body.ElementAt(i).setY(temp_y);
                temp_x = tmp_x;
                temp_y = tmp_y;
            }

            }

        public int getPoints()
        {
            return points;
        }

        public void setPoints(int points)
        {
            this.points = points;
        }

        public Block getSnakeHead()
        {
            return snake_body.ElementAt(0);
        }

        public List<Block> getSnakeBody()
        {
            return snake_body;
        }

        public Block getElement(int i)
        {
            return snake_body.ElementAt(i);

        }


    }
}
