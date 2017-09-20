using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace SnakeGame
{
    enum Direction { Up, Down, Left, Right};  
    public partial class Form1 : Form
    {
        private System.Timers.Timer t;
        private Random r;
        private Graphics g;
        private Bitmap b;
        private Image bg = Image.FromFile("images/picField_bg.png");
        private Color food_color;

        private Food f;
        private Snake s;
        Collision c;

        private int food_width = 10;
        private int food_height = 10;
        private int snake_width = 10;
        private int snake_height = 10;

        private int direction = -1;
        private bool endgame = false;
        private bool increase_speed = true;


        public Form1()
        {
            InitializeComponent();

        }
        public void resetBeforeNewGame()
        {
            lblScore.Text = "0";
            endgame = false;
            if (g != null)
                g.Dispose();
            direction = -1;
            if (t != null)
            {
                t.Stop();
                t.Enabled = false;
            }
            increase_speed = true;
       

        }

        public void newGame()
        {

            //reset values
            resetBeforeNewGame();
     
            r = new Random();
            b = new Bitmap(picField.Width, picField.Height);
            g = Graphics.FromImage(b);
            s = new Snake(10, 10, snake_width, snake_height, Color.Yellow);
            c = new Collision();
            t = new System.Timers.Timer(100);

            food_color = Color.Red;
            g.DrawImage(bg, 0, 0, picField.Width, picField.Height);
            t.Elapsed += OnTimedEvent;

            createFood();
            increaseSnake();
         

        }

        //methods
        public void createFood()
        {

            //align the food in grid
            int x = (r.Next(1, (picField.Width / 10) + 1) * 10) - food_width; // 0 - 640
            int y = (r.Next(1, (picField.Height / 10) + 1) * 10) - food_height;

            f = new Food(x, y, food_width, food_height, food_color);
            f.drawFood(g);

            refreshImage();
        }

        public void increaseSnake()
        {
            s.incrementSnake();
            s.drawSnake(g);

            refreshImage();
        }

        public void refreshImage()
        {
            //the code commented causes error "object is currently used elsewhere"
            //lock(b) ?
            //picField.Image = b;

            if (picField.Image != null)
                picField.Image.Dispose();
            picField.Image = b.Clone(new Rectangle(0, 0, b.Width, b.Height), System.Drawing.Imaging.PixelFormat.DontCare);
        }

      
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame(); // start the game
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (!endgame)
            {

                if (e.KeyCode == Keys.Up)
                {
                    if (direction != 1)
                    {
                        direction = (int)Direction.Up;
                    }
                    if (t.Enabled == false)
                    {
                        t.Start();
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (direction != 0)
                    {
                        direction = (int)Direction.Down;
                    }
                    if (t.Enabled == false)
                    {
                        t.Start();
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (direction != 3)
                    {
                        direction = (int)Direction.Left;
                    }
                    if (t.Enabled == false)
                    {
                        t.Start();
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (direction != 2)
                    {
                        direction = (int)Direction.Right;
                    }
                    if (t.Enabled == false)
                    {
                        t.Start();
                    }
                }
            }



        }

        public void increaseSpeed(int score)
        {
            //increase the snake spead based on the player score
            if (score % 100 == 0 && score != 0 && increase_speed == true)
            {
                  if(t.Interval - 10 >= 40)
                     t.Interval = t.Interval - 10; // 40 maximum speed

                  increase_speed = false;
               
            }


        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (!endgame)
            {
                g.Clear(picField.BackColor);
                g.DrawImage(bg, 0, 0, picField.Width, picField.Height);
                f.drawFood(g);

                s.moveSnake(direction);
                s.drawSnake(g);

                //check for collisions
                if (c.collisionWithFood(s, f))
                {
                    //add points
                    s.setPoints(s.getPoints() + f.getPoints());
                    lblScore.Text = s.getPoints().ToString();
                    //remove food
                    f = null;
                    increaseSnake();
                    createFood();
                    increase_speed = true;
                }
                if (c.collisionWithWall(s))
                {
                    //end the game on collision
                    endgame = true;
                    
                }
                if (c.collisionWithItself(s))
                {
                    //end the game on collision
                    endgame = true;
    
                }

                //increase the speed based on points
                increaseSpeed(s.getPoints());


                refreshImage();
            }else
            {
                //stop the timer event
                t.Stop();
                t.Enabled = false;
                MessageBox.Show("Your score: " + s.getPoints().ToString(), "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Snake Game   version: 1.0.0" + Environment.NewLine + Environment.NewLine +
            "Don't run the snake into the wall, or his own tail: you die." + Environment.NewLine +
            "Use your cursor keys: up, left, right, and down." + Environment.NewLine +
            "Eat the red squares to gain points." +Environment.NewLine + Environment.NewLine + 
            "Programmed by: Damian Borecki", "Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }



    }
}

