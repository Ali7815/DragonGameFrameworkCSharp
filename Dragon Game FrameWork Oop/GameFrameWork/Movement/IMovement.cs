using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameFrameWork.Movement
{
    public interface IMovement
    {
        Point move(Point location);
    }
}
