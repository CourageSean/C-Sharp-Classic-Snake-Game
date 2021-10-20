using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        //private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;

        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            } 
            
            if(e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            } 
            
            if(e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
            
            if(e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left )
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right )
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Down )
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Up )
            {
                goUp = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // setting the directions

            if (goLeft)
            {
                Settings.directions = "left";
            }  if (goRight)
            {
                Settings.directions = "right";
            }  if (goUp)
            {
                Settings.directions = "up";
            }  if (goDown)
            {
                Settings.directions = "down";
            }

            // end of directions

            for (int i = Snake.Count-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].x--;
                            break;

                        case "right":
                            Snake[i].x++;
                            break;

                        case "down":
                            Snake[i].y++;
                            break;

                        case "up":
                            Snake[i].y--;
                            break;

                    }

                    if(Snake[i].x < 0)
                    {
                        Snake[i].x = maxWidth;
                    } 
                    if(Snake[i].x > maxWidth)
                    {
                        Snake[i].x = 0;
                    } 
                    if(Snake[i].y < 0)
                    {
                        Snake[i].y = maxHeight;
                    } 
                    if(Snake[i].y > maxHeight)
                    {
                        Snake[i].y = 0;
                    }
                }
                else
                {
                    Snake[i].x = Snake[i - 1].x;
                    Snake[i].y = Snake[i - 1].y;
                }
            }

            picCanvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor;

            for (int i = 0; i < Snake.Count; i++)
            {
                if(i == 0)
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor = Brushes.DarkGreen;
                }

                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                    Snake[i].x * Settings.Width,
                    Snake[i].y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));

            }

         /*   canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                 (
                 food.x * Settings.Width,
                 food.y * Settings.Height,
                 Settings.Width, Settings.Height
                 ));
         */

        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxWidth = picCanvas.Height / Settings.Height - 1;

            Snake.Clear();

            startButton.Enabled = false;
            snapButton.Enabled = false;

            score = 0;

            txtHighScore.Text = "Score: " + score;

            Circle head = new Circle { x = 10, y = 5 };
            Snake.Add(head);// adding the head part of the snake to the list

            for(int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

          //  food = new Circle { x = rand.Next(2, maxWidth), y = rand.Next(2, maxHeight) };

            gameTimer.Start();

        }

        private void EatFood()
        {

        }

        private void GameOver()
        {

        }
    }
}
