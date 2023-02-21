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
    public class StandBy : IMovement
    {
        public StandBy()
        {

        }
        public Point move(Point location)
        {
            return location;
        }
    }
}
