﻿using LegendOfZelda.Interface;

namespace LegendOfZelda.Enemies.CollisionHandlers
{
    class GoriyaProjectileCollisionHandler : ICollision<INpc, IProjectile>
    {
        public void HandleCollison(INpc enemy, IProjectile projectile, Constants.Direction side)
        {
            enemy.TakeDamage(projectile.DamageAmount());

        }
    }
}
