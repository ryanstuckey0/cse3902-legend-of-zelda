﻿using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Sprint2;

namespace LegendOfZelda.Enemies
{
    class Merchant : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        public Merchant(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateMerchantSprite();
            this.spriteBatch = spriteBatch;

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
        }

        public void Update()
        {
        }
        public void ResetPosition()
        {

        }
    }
}
