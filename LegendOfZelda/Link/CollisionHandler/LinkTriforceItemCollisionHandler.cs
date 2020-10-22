﻿using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkTriforceItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem triforce, Constants.Direction side)
        {
            link.PickUpTriforce();
            triforce.Despawn();
        }
    }
}
