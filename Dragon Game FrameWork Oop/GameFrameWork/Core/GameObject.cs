using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameFrameWork.Movement;

namespace GameFrameWork.Core
{
    public class GameObject
    {
        private PictureBox pb;
        private IMovement movement;
        private ObjectType otype;
        public GameObject(Image img, ObjectType otype, int top, int left, IMovement movement)
        {
            Pb = new PictureBox();
            Pb.Image = img;
            Pb.Width = img.Width;
            Pb.Height = img.Height;
            Pb.Left = left;
            Pb.Tag = "platform";
            Pb.Top = top;
            Pb.BackColor = Color.Transparent;
            this.Movement = movement;
            this.Otype = otype;

        }
        public virtual void update()
        {
            Pb.Location = Movement.move(Pb.Location);
        }
        
        public PictureBox Pb { get => pb; set => pb = value; }
        public ObjectType Otype { get => otype; set => otype = value; }
        internal IMovement Movement { get => movement; set => movement = value; }
    }
}
