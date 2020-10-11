﻿using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Interface
{
    interface ILinkPlayer : IDynamic
    {
        void BeHealthy(int healAmount);
        void BeDamaged(int damage);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void UseSword();
        void UseBow();
        void PickUpSword();
        void PickUpHeartContainer();
        void PickUpBow();
        void PickUpTriforce();
        void UseBomb();
        void UseBoomerang();
        void PickUpBoomerang();
        void UseSwordBeam();
    }
}
