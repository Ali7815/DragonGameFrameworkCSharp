using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameFrameWork.Core
{
    public interface IGame
    {
        void raisePlayerDieEvent(PictureBox pb);
        void movePlayerUpward();
    }
}
