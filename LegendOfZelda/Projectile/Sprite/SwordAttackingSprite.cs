﻿using LegendOfZelda.Link;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    internal class SwordAttackingSprite : IProjectileSprite
    {
        private readonly Texture2D sprite;
        private bool animationIsDone;
        private int currentFrame;
        private int bufferFrame;
        private readonly int[] frameToCurrentColumnArray = { 0, 1, 2, 3, 2, 1, 0 };
        private readonly int totalFrames = 7;
        private const int numRows = 2;
        private const int numColumns = 4;
        private readonly int frameWidth;
        private readonly int frameHeight;

        public SwordAttackingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            totalFrames = frameToCurrentColumnArray.Length;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
        }

        public void Update()
        {
            animationIsDone = currentFrame >= totalFrames - 1;
            if (FinishedAnimation()) return;

            if (currentFrame < totalFrames && ++bufferFrame == LinkConstants.UsingSwordFrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            int currentRow = 0;
            int currentColumn = frameToCurrentColumnArray[currentFrame];

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int) (frameWidth * Constants.GameScaler), (int) (frameHeight * Constants.GameScaler));
        }
    }
}
