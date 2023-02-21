using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using GameFrameWork.Movement;
using GameFrameWork.Fire;

namespace GameFrameWork.Core
{
    public class GameObjectPlayer
    {
        private PictureBox pb;
        private IMovement movement;
        private ObjectType otype;
        private IFire fire;
        private ProgressBar healthBar;
        private List<IFire> fireList;
        private EventHandler fireAdded;
        private EventHandler onhealthProgressBarAdded;
        public GameObjectPlayer(Image img, ObjectType otype, int top, int left, IMovement movement, IFire fire) 
        {
            Pb = new PictureBox();
            Pb.Image = img;
            Pb.Width = img.Width;
            Pb.Height = img.Height;
            Pb.Left = left;
            pb.BackColor = Color.Transparent;
            this.Fire = fire;
            this.movement = movement;
            FireList = new List<IFire>();
            Pb.Top = top;
            Pb.BackColor = Color.Transparent;
            this.Movement = movement;
            this.Otype = otype;
            makeHealthBar();


        }
        public void gameObjectMove()
        {

            Pb.Location = Movement.move(Pb.Location);
        }
        public void makeHealthBar()
        {
            healthBar = new ProgressBar();
            this.healthBar.Location = new Point(Pb.Left, Pb.Top - 20);
            this.healthBar.Name = "progressBar1";
            this.healthBar.Size = new System.Drawing.Size(89, 16);
            this.healthBar.Value = 100;
            this.healthBar.BringToFront();
            onHealthProgressBarAdded?.Invoke(healthBar, new EventArgs());
        }

        public void changeImage(Image img)
        {
            Pb.Image = img;
            Pb.Width = img.Width;
            Pb.Height = img.Height;
        }
        public void createFire()
        {
            IFire f = fire.createFire(new Point(Pb.Left, Pb.Top));
            if (f != null)
            {
                fireList.Add(f);
                FireAdded?.Invoke(f.GetPictureBox(), new EventArgs());
            }
        }
        public void moveFires()
        {
            foreach (IFire f in fireList)
            {
                f.GetPictureBox().Location = f.move();
            }
        }
       
        public void moveHealthBar()
        {
            healthBar.Left = Pb.Left;
            healthBar.Top = Pb.Top - 20;
        }
        public void update2()
        {
            
            moveFires();
            moveHealthBar();
        }

        public PictureBox Pb { get => pb; set => pb = value; }
        public ObjectType Otype { get => otype; set => otype = value; }
        internal IMovement Movement { get => movement; set => movement = value; }

        public EventHandler FireAdded { get => fireAdded; set => fireAdded = value; }
        public EventHandler onHealthProgressBarAdded { get => onhealthProgressBarAdded; set => onhealthProgressBarAdded = value; }
        public ProgressBar HealthBar { get => healthBar; set => healthBar = value; }
        public List<IFire> FireList { get => fireList; set => fireList = value; }
        public IFire Fire { get => fire; set => fire = value; }
    }

}
