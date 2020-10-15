﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class GoriyaLeftSprite : ISprite
    {
        private Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;
        private int width;
        private int height;
        private int row;
        private int column;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public GoriyaLeftSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = Columns;
        }
        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == 6)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            int width = sprite.Width / Columns;
            int height = sprite.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            sourceRectangle = new Rectangle(width * column, height * row, width, height);
            destinationRectangle = new Rectangle(position.X, position.Y, 2 * width, 2 * height);

            spriteBatch.Begin();
            if (damaged)
            {
                spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.Red);
            }
            else
            {
                spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);

            }
            spriteBatch.End();
        }

        public Rectangle GetSizeRectangle()
        {
            return destinationRectangle;
        }
    }
}
