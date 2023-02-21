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
    public class HorizontalMovement : IMovement
    {
        private int speed;
        private Point boundary;
        private string direction;
        private int offset = 170;
        public HorizontalMovement(int speed, Point boundary, string direction)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.direction = direction;
        }
        public Point move(Point location)
        {
            if (location.X < 0)
            {
                direction = "right";
            }
            else if (location.X + offset >= boundary.X)
            {
                direction = "left";
            }
            if (direction == "left")
            {
                location.X -= speed;
            }
            else if (direction == "right")
            {
                location.X += speed;
            }
            return location;
        }
    }
}
