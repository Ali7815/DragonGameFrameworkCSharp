using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using GameFrameWork.Core;

namespace GameFrameWork.Fire
{
    public class EnemyFire : IFire
    {
        private PictureBox pb;
        private ObjectType oType;
        private int speed;

        public PictureBox Pb { get => pb; set => pb = value; }
        public ObjectType OType { get => oType; set => oType = value; }
        public int Speed { get => speed; set => speed = value; }

        public EnemyFire(Image img, string type, ObjectType oType, int speed)
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
        public PlayerFire create()
        {
            PlayerFire F = new PlayerFire(Pb.Image, "player", ObjectType.playerFire, 10);
            return F;
        }
        public IFire createFire()
        {
           
            return null;
        }
        public PictureBox GetPictureBox()
        {
            return pb;
        }
        public IFire createFire(System.Drawing.Point location)
        {
            
            return null;
        }
        public Point move()
        {
        
            return Pb.Location;
        }
    }
}
