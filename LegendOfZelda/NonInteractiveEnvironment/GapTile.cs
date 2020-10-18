﻿using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class GapTile : IBlock
    {
        private ISprite tileBlackSprite;
        private SpriteBatch sB;
        private Point position;
        private bool safeToDespawn;

        public GapTile(SpriteBatch spriteBatch, Point spawnPosition)
        {
            tileBlackSprite = SpriteFactory.Instance.CreateTileBlackSprite();
            sB = spriteBatch;
            position = spawnPosition;
            safeToDespawn = false;
        }

        public void Draw()
        {
            tileBlackSprite.Draw(sB, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return tileBlackSprite.GetPositionRectangle();
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void SetPosition(Point position)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // some condition here if we want to despawn
        }
    }
}
