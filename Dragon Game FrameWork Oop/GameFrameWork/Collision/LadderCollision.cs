using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Core;

namespace GameFrameWork.Collision
{
    public class LadderCollision : ICollisionAction
    {
        public void performAction2(IGame game, GameObjectPlayer source1, GameObject source2)
        {
            GameObjectPlayer player = source1;
            GameObject hurdle = source2;
            game.movePlayerUpward();
            
        }
        public void performAction(IGame game, GameObjectPlayer source1, GameObjectPlayer source2)
        {

        }
    }
}
