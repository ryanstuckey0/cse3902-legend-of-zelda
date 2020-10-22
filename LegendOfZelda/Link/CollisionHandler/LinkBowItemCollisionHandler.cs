﻿using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkBowItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem bow, Constants.Direction side)
        {
            link.PickUpBow();
            bow.Despawn();
        }
    }
}
