﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Sprite
{
    class PickingUpItemLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int delayCounter;

        public PickingUpItemLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
            delayCounter = 0;
        }

        public void Update()
        {
            animationIsDone = delayCounter >= Constants.LinkPickingUpItemPauseTicks;
            if (finishedAnimation()) return;

            if (++damageColorCounter == Constants.LinkDamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool drawWithDamage)
        {
            spriteBatch.Draw(sprite, position, flashRed && drawWithDamage ? Color.Red : Color.White);
        }

        public bool finishedAnimation()
        {
            return animationIsDone;
        }
    }
}
