using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Drawing;
using System.Windows.Forms;
using GameFrameWork.Movement;
using GameFrameWork.Fire;
using GameFrameWork.Core;


namespace GameFrameWork.Fire
{
    public class PlayerFire : IFire
    {
        private PictureBox pb;
        private ObjectType oType;
        private string direction = "left";
        private int speed;
        public event EventHandler addFire;
        public PlayerFire(Image img, string type, ObjectType oType, int speed)
        {
            Pb = new PictureBox();
            Pb.Image = img;
            this.Speed = speed;
            Pb.BackColor = Color.Transparent;
            Pb.Tag = type;
            Pb.Width = img.Width;
            Pb.Height = img.Height;
            this.OType = oType;
        }
        public PlayerFire(PlayerFire fire)
        {
            this.pb = fire.Pb;
            this.speed = fire.Speed;
            this.OType = fire.OType;
        }

        public PlayerFire create()
        {
            PlayerFire F = new PlayerFire(Pb.Image, "player", ObjectType.playerFire, 10);
            return F;
        }
        public IFire createFire()
        {
            if (Keyboard.IsKeyPressed(Key.Space))
            {

                PlayerFire fire = create();
                addFire?.Invoke(Pb, EventArgs.Empty);
                return fire;
            }
            return null;
        }
        public PictureBox GetPictureBox()
        {
            return pb;
        }
        public IFire createFire(System.Drawing.Point location)
        {
            if (EZInput.Keyboard.IsKeyPressed(Key.Space))
            {
                if (direction == "left")
                {
                    makeFire(moveDirection.left, location);
                    return new PlayerFire(this);
                }
                if (direction == "right")
                {
                    makeFire(moveDirection.right, location);
                    return new PlayerFire(this);
                }
            }
            return null;
        }
        private void makeFire(moveDirection direction, System.Drawing.Point location)
        {
            pb = new PictureBox();
            pb.Left = location.X;
            pb.Top = location.Y + 30;
            pb.Image = pb.Image;
            pb.Height = pb.Image.Height;
            pb.Width = pb.Image.Width;
            pb.BackColor = Color.Transparent;
            pb.BringToFront();
        }
        public System.Drawing.Point move()
        {
            if (direction == "left")
            {
                pb.Left -= speed;
            }
            else if (direction == "right")
            {
                pb.Left += speed;
            }
            return new System.Drawing.Point(pb.Left, pb.Top);

        }
        public System.Drawing.Point move(System.Drawing.Point location)
        {
            location.X += speed;
            return location;
        }
        public void update()
        {
            createFire();
        }
        public PictureBox Pb { get => pb; set => pb = value; }
        public int Speed { get => speed; set => speed = value; }
        public ObjectType OType { get => oType; set => oType = value; }
    }
}