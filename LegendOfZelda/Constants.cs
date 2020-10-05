namespace LegendOfZelda
{
    public static class Constants
    {
        public const int Number = 69;
        public const int FrameDelay = 6;
        public const double SpriteScaler = 1;

        // Link
        public const int LinkWalkStepDistanceInterval = 1;
        public const int LinkWalkDistanceInterval = 20;
        public const int LinkHealth = 100;
        public const int LinkDamageEffectTimeMs = 2000;
        public const int LinkDamageFlashDelayTicks = 5;
        public const int LinkPickingUpItemPauseTicks = 60;
        public const int LinkUsingItemPauseTicks = 5;
        public const int LinkStrikingPauseTicks = 5;
        public const int LinkWalkingFrameDelay = 10;

        // Link's Items
        public const int ArrowSpawnXOffsetFromLink = 0;
        public const int ArrowSpawnYOffsetFromLink = 6;        
        public const int ArrowFlyingDistanceInterval = 5;
        public const int BombSpawnXOffsetFromLink = 0;
        public const int BombSpawnYOffsetFromLink = 6;
        public const int BombDelayBeforeExplosion = 60;
        public const int BoomerangSpawnXOffsetFromLink = 0;
        public const int BoomerangSpawnYOffsetFromLink = 6;
        public const int BoomerangDespawnMaxXFromLink = 15;
        public const int BoomerangDespawnMinXFromLink = 0;
        public const int BoomerangDespawnMaxYFromLink = 15;
        public const int BoomerangDespawnMinYFromLink = 0;
        public const int BoomerangMaxDistanceFromLink = 300;
        public const int SwordBeamSpawnXOffsetFromLink = 4;
        public const int SwordBeamSpawnYOffsetFromLink = 5;
        public const int SwordBeamFlyingDistanceInterval = 5;
        public const int SwordBeamExplodingDistanceInterval = 1;
        public const int SwordBeamExplodingRange = 50;
        public const int SwordBeamExplodingFrameDelay = 2;

        // Picking Up Item Spawn Offsets
        public const int LinkPickingUpBoomerangSpawnOffsetX = 0;
        public const int LinkPickingUpBoomerangSpawnOffsetY = -9;
        public const int LinkPickingUpBowSpawnOffsetX = 0;
        public const int LinkPickingUpBowSpawnOffsetY = -15;
        public const int LinkPickingUpTriforceSpawnOffsetX = 0;
        public const int LinkPickingUpTriforceSpawnOffsetY = -11;
        public const int LinkPickingUpHeartSpawnOffsetX = 0;
        public const int LinkPickingUpHeartSpawnOffsetY = -14;
        public const int LinkPickingUpSwordSpawnOffsetX = 0;
        public const int LinkPickingUpSwordSpawnOffsetY = -12;

        // Game Screen
        public const int MaxXPos = 800;
        public const int MinXPos = 0;
        public const int MaxYPos = 480;
        public const int MinYPos = 0;

        // Directions
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }

        // Items
        public enum Item
        {
            Arrow,
            Bomb,
            Boomerang,
            SwordBeam
        }
    }
}
