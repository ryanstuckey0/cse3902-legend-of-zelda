﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class LockedDoor : IBlock
    {
        private readonly ITextureAtlasSprite doorSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        private int textureMapRow;
        private readonly int textureMapColumn = 1;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public LockedDoor(SpriteBatch spriteBatch, Point spawnPosition)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Draw()
        {
            if ((position.X == RoomConstants.TopDoorX) && (position.Y == RoomConstants.TopDoorY))
            {
                textureMapRow = 0;
            }
            else if ((position.X == RoomConstants.LeftDoorX) && (position.Y == RoomConstants.LeftDoorY))
            {
                textureMapRow = 1;
            }
            else if ((position.X == RoomConstants.RightDoorX) && (position.Y == RoomConstants.RightDoorY))
            {
                textureMapRow = 2;
            }
            else if ((position.X == RoomConstants.BottomDoorX) && (position.Y == RoomConstants.BottomDoorY))
            {
                textureMapRow = 3;
            }
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
        }

        public void Update()
        {
            safeToDespawn = safeToDespawn || false; // put condition here for when door can be despawned
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, doorSprite.GetPositionRectangle().Width, doorSprite.GetPositionRectangle().Height);
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
    }
}
