﻿using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    internal class BrickTileSprite : ISprite
    {
        private readonly Texture2D sprite;

        public BrickTileSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * sprite.Width), (int)(RoomConstants.SpriteMultiplier * sprite.Height));
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public void Update()
        {

        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int) (sprite.Width * Constants.GameScaler), (int) (sprite.Height * Constants.GameScaler));
        }

    }
}
