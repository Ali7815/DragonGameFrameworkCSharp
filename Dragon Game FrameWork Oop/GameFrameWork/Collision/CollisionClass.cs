using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Core;
namespace GameFrameWork.Collision
{
    public class CollisionClass
    {
        private ObjectType g1;
        private ObjectType g2;
        private ICollisionAction behavior;
        public CollisionClass(ObjectType g1, ObjectType g2, ICollisionAction behavior)
        {
            this.G1 = g1;
            this.G2 = g2;
            this.Behavior = behavior;
        }

        public ObjectType G1 { get => g1; set => g1 = value; }
        public ObjectType G2 { get => g2; set => g2 = value; }
        public ICollisionAction Behavior { get => behavior; set => behavior = value; }
    }
}
