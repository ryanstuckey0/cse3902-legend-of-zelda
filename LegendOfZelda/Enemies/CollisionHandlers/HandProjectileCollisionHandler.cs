﻿using LegendOfZelda.Interface;

namespace LegendOfZelda.Enemies.CollisionHandlers
{
    class HandProjectileCollisionHandler : ICollision<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile projectile, Constants.Direction side)
        {
            enemy.TakeDamage(projectile.DamageAmount());

        }
    }
}
