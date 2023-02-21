using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Core;

namespace GameFrameWork.Collision
{
    public interface ICollisionAction
    {
        void performAction(IGame game, GameObjectPlayer source1, GameObjectPlayer source2);
        void performAction2(IGame game, GameObjectPlayer source1, GameObject source2);
    }
}
