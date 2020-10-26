﻿using LegendOfZelda.Enemies;
using LegendOfZelda.Enemies.CollisionHandlers.WithBlock;
using LegendOfZelda.Enemies.CollisionHandlers.WithProjectile;
using LegendOfZelda.Environment;
using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using LegendOfZelda.Link.CollisionHandler.WithBlock;
using LegendOfZelda.Link.CollisionHandler.WithItem;
using LegendOfZelda.Link.CollisionHandler.WithNpc;
using LegendOfZelda.Link.CollisionHandler.WithProjectile;
using LegendOfZelda.Link.CollisionHandlers.WithProjectile;
using LegendOfZelda.Projectile;
using LegendOfZelda.Projectile.CollisionHandler;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameLogic
{
    class CollisionHandlerDictionary
    {
        // IPlayer Collision Dictionaries
        private Dictionary<Type, ICollisionHandler<IPlayer, INpc>> playerNpcDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IProjectile>> playerProjectileDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IItem>> playerItemDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IBlock>> playerBlockDictionary;

        // INpc Collision Dictionaries
        private Dictionary<Type, ICollisionHandler<INpc, IProjectile>> npcProjectileDictionary;
        private Dictionary<Type, ICollisionHandler<INpc, IBlock>> npcBlockDictionary;

        // IProjectile Collision Dictionary
        private Dictionary<Type, ICollisionHandler<IProjectile, IBlock>> projectileBlockDictionary;

        // IItem Collision Dictionary
        private Dictionary<Type, ICollisionHandler<IItem, IBlock>> itemBlockDictionary;

        public CollisionHandlerDictionary()
        {
            InitializePlayerCollisionDictionaries();
            InitializeNpcCollisionDictionaries();
            InitializeProjectileCollisionDictionaries();
            InitializeItemCollisionDictionaries();
        }

        public ICollisionHandler<IPlayer, INpc> GetPlayerNpcHandler(Type type)
        {
            return playerNpcDictionary[type];
        }

        public ICollisionHandler<IPlayer, IProjectile> GetPlayerProjectileHandler(Type type)
        {
            return playerProjectileDictionary[type];
        }

        public ICollisionHandler<IPlayer, IItem> GetPlayerItemHandler(Type type)
        {
            return playerItemDictionary[type];
        }

        public ICollisionHandler<IPlayer, IBlock> GetPlayerBlockHandler(Type type)
        {
            return playerBlockDictionary[type];
        }

        public ICollisionHandler<INpc, IProjectile> GetNpcProjectileHandler(Type type)
        {
            return npcProjectileDictionary[type];
        }

        public ICollisionHandler<INpc, IBlock> GetNpcBlockHandler(Type type)
        {
            return npcBlockDictionary[type];
        }

        public ICollisionHandler<IProjectile, IBlock> GetProjectileBlockHandler(Type type)
        {
            return projectileBlockDictionary[type];
        }

        public ICollisionHandler<IItem, IBlock> GetItemBlockHandler(Type type)
        {
            return itemBlockDictionary[type];
        }

        private void InitializePlayerCollisionDictionaries()
        {
            playerNpcDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, INpc>>()
            {
                {typeof(Aquamentus), new LinkNpcDamageCollisionHandler() },
                {typeof(Bat), new LinkNpcDamageCollisionHandler() },
                {typeof(Goriya), new LinkNpcDamageCollisionHandler() },
                {typeof(Hand), new LinkHandCollisionHandler() },
                {typeof(Jelly), new LinkNpcDamageCollisionHandler() },
                {typeof(Skeleton), new LinkNpcDamageCollisionHandler() },
                {typeof(SpikeTrap), new LinkNpcDamageCollisionHandler() },
                {typeof(OldMan), new LinkNpcDoNothingCollisionHandler() },
                {typeof(Merchant), new LinkNpcDoNothingCollisionHandler() },
                {typeof(MovableSquare), new LinkMovableBlockCollisionHandler() }
            };

            playerProjectileDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IProjectile>>()
            {
                {typeof(ArrowFlyingProjectile), new LinkProjectileDoNothingCollisionHandler() },
                {typeof(BombExplodingProjectile), new LinkBombCollisionHandler() },
                {typeof(BoomerangFlyingProjectile), new LinkProjectileDoNothingCollisionHandler() },
                {typeof(FireballProjectile), new LinkFireballCollisionHandler() },
                {typeof(SwordAttackingProjectile), new LinkProjectileDoNothingCollisionHandler() },
                {typeof(SwordBeamFlyingProjectile), new LinkProjectileDoNothingCollisionHandler() },
            };

            playerItemDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IItem>>()
            {
                {typeof(BombItem), new LinkBombItemCollisionHandler() },
                {typeof(BoomerangItem), new LinkBoomerangItemCollisionHandler() },
                {typeof(BowItem), new LinkBowItemCollisionHandler() },
                {typeof(ClockItem), new LinkClockItemCollisionHandler() },
                {typeof(CompassItem), new LinkCompassItemCollisionHandler() },
                {typeof(FairyItem), new LinkFairyItemCollisionHandler() },
                {typeof(HeartContainerItem), new LinkHeartContainerItemCollisionHandler() },
                {typeof(HeartItem), new LinkHeartItemCollisionHandler() },
                {typeof(KeyItem), new LinkKeyItemCollisionHandler() },
                {typeof(MapItem), new LinkMapItemCollisionHandler() },
                {typeof(RupeeItem), new LinkRupeeItemCollision() },
                {typeof(TriforceItem), new LinkTriforceItemCollisionHandler() }
            };

            playerBlockDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IBlock>>()
            {
                // movable block collision handler is in the NPC dictionary

                // immovable blocks
                {typeof(LockedDoor), new LinkImmovableBlockCollisionHandler() },
                {typeof(Statues), new LinkImmovableBlockCollisionHandler() },
                {typeof(TileWater), new LinkImmovableBlockCollisionHandler() },
                {typeof(Walls), new LinkImmovableBlockCollisionHandler() },
                {typeof(ShutDoor), new LinkImmovableBlockCollisionHandler() },
                {typeof(Square), new LinkImmovableBlockCollisionHandler() },
                {typeof(RoomWall), new LinkImmovableBlockCollisionHandler() },

                // interactive blocks
                {typeof(Fire), new LinkFireCollisionHandler() },
                {typeof(OpenDoor), new LinkDoorCollisionHandler() },
                {typeof(BombedOpening), new LinkDoorCollisionHandler() },
                {typeof(Stairs), new LinkStairsCollisionHandler() }


                // no collision detection
                // BlackBackground, RoomBorder, TileBackground, TileBlueGrass

                // unmovable block
                    // water
                    // wall
                    // gap tile
                    // statue
            };
        }

        private void InitializeNpcCollisionDictionaries()
        {
            npcProjectileDictionary = new Dictionary<Type, ICollisionHandler<INpc, IProjectile>>
            {
                {typeof(ArrowFlyingProjectile), new EnemyArrowCollisionHandler() },
                {typeof(BombExplodingProjectile), new EnemyBombCollisionHandler() },
                {typeof(BoomerangFlyingProjectile), new EnemyBoomerangCollisionHandler() },
                {typeof(FireballProjectile), new EnemyProjectileDoNothingCollisionHandler() },
                {typeof(SwordAttackingProjectile), new EnemySwordCollisionHandler() },
                {typeof(SwordBeamFlyingProjectile), new EnemySwordBeamCollisionHandler() }
            };

            npcBlockDictionary = new Dictionary<Type, ICollisionHandler<INpc, IBlock>>()
            {
                {typeof(Aquamentus), new AquamentusBlockCollisionHandler() },
                {typeof(Bat), new BatBlockCollisionHandler() },
                {typeof(Goriya), new GoriyaBlockCollisionHandler() },
                {typeof(Hand), new HandBlockCollisionHandler() },
                {typeof(Jelly), new JellyBlockCollisionHandler() },
                {typeof(Skeleton), new SkeletonBlockCollisionHandler() },
                {typeof(SpikeTrap), new SpikeTrapBlockCollisionHandler() }
            };
        }

        private void InitializeProjectileCollisionDictionaries()
        {
            projectileBlockDictionary = new Dictionary<Type, ICollisionHandler<IProjectile, IBlock>>
            {
                {typeof(ArrowFlyingProjectile), new ArrowBlockCollisionHandler() },
                {typeof(BoomerangFlyingProjectile), new BoomerangBlockCollisionHandler() },
                {typeof(BombExplodingProjectile), new ProjectileBlockDoNothingCollisionHandler() },
                {typeof(FireballProjectile), new FireballBlockCollisionHandler() },
                {typeof(SwordAttackingProjectile), new ProjectileBlockDoNothingCollisionHandler()},
                {typeof(SwordBeamFlyingProjectile), new SwordBeamBlockCollisionHandler() }
            };
        }

        private void InitializeItemCollisionDictionaries()
        {
            itemBlockDictionary = new Dictionary<Type, ICollisionHandler<IItem, IBlock>>()
            {
                // TODO: initialize me here
            };
        }
    }
}
