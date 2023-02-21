using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Core;

namespace GameFrameWork.Collision
{
    public class PlayerCollision : ICollisionAction
    {
        public void performAction(IGame game, GameObjectPlayer source1, GameObjectPlayer source2)
        {
            GameObjectPlayer player;
            if (source1.Otype == ObjectType.player)
            {
                player = source1;
            }
            else
            {
                player = source2;
            }
            game.raisePlayerDieEvent(player.Pb);
        }
        public void performAction2(IGame game, GameObjectPlayer source1, GameObject source2)
        {

        }
    }
}
