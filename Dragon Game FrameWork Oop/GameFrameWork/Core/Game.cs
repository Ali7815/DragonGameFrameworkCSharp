using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameFrameWork.Movement;
using GameFrameWork.Fire;
using GameFrameWork.Collision;
using EZInput;

namespace GameFrameWork.Core
{
    public class Game : IGame
    {
        private List<GameObjectPlayer> gameObjectPlayerList;
        private List<GameObject> gameObjectList;
        public event EventHandler onGameObjectAdded;
        public event EventHandler onGameObjectPlayerAdded;
        private List<CollisionClass> collisions;
        public event EventHandler onPlayerDie;
        public event EventHandler onSpacePressed;
        private EventHandler onProgressBarAdded;
        private List<PictureBox> PlayerFireList = new List<PictureBox>();
        private List<PictureBox> EnemyFireList = new List<PictureBox>();
        EventHandler onLeftMove;
        EventHandler onRightMove;

        public EventHandler OnLeftMove { get => onLeftMove; set => onLeftMove = value; }
        public EventHandler OnRightMove { get => onRightMove; set => onRightMove = value; }
        public EventHandler OnProgressBarAdded { get => onProgressBarAdded; set => onProgressBarAdded = value; }

        public Game()
        {
            gameObjectList = new List<GameObject>();
            gameObjectPlayerList = new List<GameObjectPlayer>();
            collisions = new List<CollisionClass>();
        }
        public void addGameObject(Image img, ObjectType otype, int top, int left, IMovement movement)
        {
            GameObject go = new GameObject(img, otype, top, left, movement);
            gameObjectList.Add(go);
            onGameObjectAdded?.Invoke(go.Pb, EventArgs.Empty);
        }
        public void addGameObjectPlayer(Image img, ObjectType otype, int top, int left, IMovement movement,IFire fire)
        {
            GameObjectPlayer go = new GameObjectPlayer(img, otype, top, left, movement,fire);
            gameObjectPlayerList.Add(go);           
            onGameObjectPlayerAdded?.Invoke(go.Pb, EventArgs.Empty);
        }
       
        public void update()
        {
            detectCollision();
            foreach (GameObjectPlayer go in gameObjectPlayerList)
            {
                go.gameObjectMove();
                go.update2();
               
            }
        }
        public void keyPressed(Keys keyCode)
        {
            foreach (var go in gameObjectPlayerList)
            {

                if (go.Movement.GetType() == typeof(KeyBoardMovement))
                {
                    KeyBoardMovement keyBoardHandler = (KeyBoardMovement)go.Movement;
                    keyBoardHandler.keyPressed(keyCode, go.Pb.Location);
                }
            }
        }
        public void fireEnemy()
        {
            for (int i = 0; i < gameObjectPlayerList.Count; i++)
            {
                GameObjectPlayer enemy = gameObjectPlayerList[i];
                if (enemy.Otype == ObjectType.enemy)
                {
                    /*enemy.Fire.*/
                }
            }
        }
        public void checkPlayerIntersectWithPaltform()
        {
            foreach (var go in gameObjectPlayerList)
            {
                if (go.Movement.GetType() == typeof(KeyBoardMovement))
                {
                    foreach (var coll in gameObjectList)
                    {
                        if (go.Pb.Bounds.IntersectsWith(coll.Pb.Bounds))
                        {
                            if (coll.Movement.GetType() == typeof(StandBy))
                            {

                                go.Pb.Top = coll.Pb.Top - (go.Pb.Height + 5);


                            }
                        }
                    }

                }
                
            }
            for (int i = 0; i < gameObjectPlayerList.Count; i++)
            {
                GameObjectPlayer enemy = gameObjectPlayerList[i];
                if (enemy.Otype == ObjectType.enemy)
                {
                    foreach (PictureBox p in PlayerFireList)
                    {
                        if (enemy.Pb.Bounds.IntersectsWith(p.Bounds))
                        {
                            gameObjectPlayerList.Remove(enemy);
                            onPlayerDie?.Invoke(enemy.Pb, EventArgs.Empty);
                        }
                    }
                }
            }
        }
        public void raisePlayerDieEvent(PictureBox playerGameObject)
        {
            onPlayerDie?.Invoke(playerGameObject, EventArgs.Empty);
        }
        public void detectCollision()
        {
            for (int i = 0; i < gameObjectPlayerList.Count; i++)
            {
                for (int j = 0; j < gameObjectPlayerList.Count; j++)
                {
                    if (gameObjectPlayerList[i].Pb.Bounds.IntersectsWith(gameObjectPlayerList[j].Pb.Bounds))
                    {
                        foreach (var c in collisions)
                        {
                            if(c.G2==ObjectType.ladder)
                            {
                                checkPlayerIntersectWithPaltform();
                            }
                            if (c.G1 == gameObjectPlayerList[i].Otype && gameObjectPlayerList[j].Otype == c.G2)
                            {
                                c.Behavior.performAction(this, gameObjectPlayerList[i], gameObjectPlayerList[j]);
                            }
                        }
                    }
                }
                
            }
            for (int i = 0; i < gameObjectPlayerList.Count; i++)
            {
                for (int j = 0; j < gameObjectList.Count; j++)
                {
                    if (gameObjectPlayerList[i].Pb.Bounds.IntersectsWith(gameObjectList[j].Pb.Bounds))
                    {
                        foreach (var c in collisions)
                        {
                            if (c.G1 == gameObjectPlayerList[i].Otype && gameObjectList[j].Otype == c.G2)
                            {
                                c.Behavior.performAction2(this, gameObjectPlayerList[i], gameObjectList[j]);
                            }
                        }
                    }
                }
            }
        }
        public void movePlayerUpward()
        {

            checkPlayerIntersectWithPaltform();



        }
            public void addCollison(CollisionClass C)
            {
                collisions.Add(C);
            }
        public void changeImage(Keys keyCode,Image straight,Image opposite)
        {
            GameObjectPlayer soldier = gameObjectPlayerList.Find(o => o.Otype == ObjectType.player);
            if(keyCode==Keys.Left)
            {
                soldier.Pb.Image = opposite;
                soldier.Pb.Tag = "oppo";
            }
            else if(keyCode==Keys.Right)
            {
                soldier.Pb.Image = straight;
                soldier.Pb.Tag = "straight";
            }
        }
        public void makeFire(Keys keyCode,Image image)
        {
            GameObjectPlayer soldier = gameObjectPlayerList.Find(o => o.Otype == ObjectType.player);
            if(keyCode==Keys.Space)
            {
                PictureBox fireImage = new PictureBox();
                fireImage.Image = image;
                fireImage.Width = image.Width;
                fireImage.Height = image.Height;
                fireImage.BackColor = Color.Transparent;
                if((string)soldier.Pb.Tag=="straight")
                {
                    fireImage.Left += 10;
                    fireImage.Tag = "Left";
                    fireImage.Left = (soldier.Pb.Left +soldier.Pb.Width)+40;
                }
                if ((string)soldier.Pb.Tag == "oppo")
                {
                    fireImage.Left -= 10;
                    fireImage.Tag = "Right";
                    fireImage.Left = soldier.Pb.Left - 40;
                }
                fireImage.Top = soldier.Pb.Top + 37;
                
                PlayerFireList.Add(fireImage);
                onSpacePressed?.Invoke(fireImage, EventArgs.Empty);
            }
            
        }
        public void moveFire()
        {
            foreach (var fire in PlayerFireList)
            {
                if ((string)fire.Tag == "Left")
                {
                    fire.Left = fire.Left + 20;
                }
                    if ((string)fire.Tag == "Right")
                    {
                        fire.Left = fire.Left - 20;
                    }
                }
        }
        private void player_OnProgressBarAdd(object sender, EventArgs e)
        {
            OnProgressBarAdded?.Invoke(sender, EventArgs.Empty);
        }


    }

}
