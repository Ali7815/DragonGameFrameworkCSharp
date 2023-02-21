using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameFrameWork.Core;

namespace GameFrameWork.Movement
{
    public class KeyBoardMovement : IMovement
    {
        private int speed;
        private Point boundary;
        private string action = null;
       

        public string Action { get => action; set => action = value; }
        public KeyBoardMovement(int speed, Point boundary)
        {
            this.speed = speed;
            this.boundary = boundary;
        }
        public KeyBoardMovement()
        {

        }
        public void keyPressed(Keys keyCode, Point location)
        {
            if (keyCode == Keys.Up)
            {
                Action = "up";
                
            }
            else if (keyCode == Keys.Down && location.Y < 700)
            {
                Action = "down";
            }
            else if (keyCode == Keys.Left && location.X > 0)
            {
               
                Action = "left";
            }
            else if (keyCode == Keys.Right && location.X + 80 < boundary.X)
            {
                Action = "right";
               
            }
        }
        public Point move(Point location)
        {
            if (Action != null)
            {
                if (Action == "up")
                {
                    /*location.Y -= speed;*/

                }
                else if (Action == "down")
                {
                    location.Y += speed;
                }
                else if (Action == "left")
                {
                    location.X -= speed;
                }
                else if (Action == "right")
                {
                    location.X += speed;
                    
                }
            }
            if (location.Y < 700)
            {
                location.Y = location.Y + (speed - 9);
            }

            Action = null;

            return location;
        }
    }
}
