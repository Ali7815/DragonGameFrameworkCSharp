using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameFrameWork.Core;
using GameFrameWork.Movement;
using GameFrameWork.Fire;
using GameFrameWork.Collision;
namespace ConsumerGame
{
    public partial class Form1 : Form
    {
        Game go;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Maximizing the Window
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Point boundary = new Point(this.Width, this.Height);
             go = new Game();
            PlayerFire firePlayer = new PlayerFire(Properties.Resources.soldierFire2, "player", ObjectType.playerFire, 10);
           EnemyFire fireEnemy = new EnemyFire(Properties.Resources.soldierFire2, "enemy", ObjectType.playerFire, 10);
            go.onGameObjectAdded += new EventHandler(addIntoControls);
            go.onPlayerDie += new EventHandler(removePlayer);
            go.OnProgressBarAdded += Game_OnProgressBarAdd;
            go.onGameObjectPlayerAdded += new EventHandler(addIntoControls);
            go.onSpacePressed += new EventHandler(addIntoControls);
            go.addGameObject(Properties.Resources.longPlatform, ObjectType.platform, 550, 290, new StandBy());
            go.addGameObject(Properties.Resources.longPlatform, ObjectType.platform, 250, 640, new StandBy());
            go.addGameObject(Properties.Resources.image, ObjectType.platform, 550, 1210, new StandBy());
            go.addGameObject(Properties.Resources.image, ObjectType.platform, 330, 90, new StandBy());
            go.addGameObject(Properties.Resources.smalladder, ObjectType.ladder, 600, 1370, new StandBy());
            go.addGameObject(Properties.Resources.ladder3, ObjectType.ladder, 250, 1450, new StandBy());
            go.addGameObject(Properties.Resources.smalladder, ObjectType.ladder, 350, 350, new StandBy());
            go.addGameObjectPlayer(Properties.Resources.newStandStraight, ObjectType.player, 700, 20, new KeyBoardMovement(20, boundary), firePlayer);
            go.addGameObjectPlayer(Properties.Resources.NewPurpleDragon,ObjectType.enemy,120, 200, new HorizontalMovement(10, boundary, "right"),fireEnemy);
            go.addGameObjectPlayer(Properties.Resources.NewPurpleDragon, ObjectType.enemy, 430, 200, new HorizontalMovement(10, boundary, "right"), fireEnemy);
            go.addGameObjectPlayer(Properties.Resources.NewPurpleDragon, ObjectType.enemy, 700, 1450, new HorizontalMovement(10, boundary, "right"), fireEnemy);
            CollisionClass C = new CollisionClass(ObjectType.player, ObjectType.enemy, new PlayerCollision());
            CollisionClass C2 = new CollisionClass(ObjectType.player, ObjectType.ladder, new LadderCollision());
            CollisionClass C3 = new CollisionClass(ObjectType.playerFire, ObjectType.enemy, new LadderCollision());
            go.addCollison(C);
            go.addCollison(C2);
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            
            go.update();
            go.moveFire();
            /*go.checkPlayerIntersectWithPaltform();*/

        }
        private void addIntoControls(object sender, EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }
        private void Game_OnProgressBarAdd(object sender, EventArgs e)
        {
            ProgressBar bar = (ProgressBar)sender;
            this.Controls.Add(bar);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            go.keyPressed(e.KeyCode);
            go.makeFire(e.KeyCode,Properties.Resources.soldierFire2);
            go.changeImage(e.KeyCode, Properties.Resources.newStandStraight, Properties.Resources.NewOppositStraight);
        }
        private void removePlayer(object sender, EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
        }
        private void Player_OnLeftMove(object sender, EventArgs e)
        {
            GameObjectPlayer obj = (GameObjectPlayer)sender;

            obj.changeImage(Properties.Resources.NewOppositStraight);
        }

        private void Player_OnRightMove(object sender, EventArgs e)
        {
            GameObjectPlayer obj = (GameObjectPlayer)sender;

            obj.changeImage(Properties.Resources.newStandStraight);
        }
    }
}
