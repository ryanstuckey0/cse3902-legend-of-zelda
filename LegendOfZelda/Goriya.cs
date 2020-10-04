﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Goriya : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Vector2 pos;
        private Vector2 velocity;

        public Goriya(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateDogLikeMonsterSprite();
            this.spriteBatch = spriteBatch;
            pos.X = Sprint2.enemyNPCX;
            pos.Y = Sprint2.enemyNPCY;
            velocity.X = 0;
            velocity.Y = 0;
        }

        public void Update()
        {
        }

        public void Draw()
        {
        }

        public Vector2 getPos()
        {
            return pos;
        }

        public void setPos(Vector2 pos)
        {
            this.pos = pos;
        }

        public void setUpSprite()
        {

        }

        public void setDownSprite()
        {

        }

        public void setLeftSprite()
        {

        }

        public void setRightSprite()
        {

        }
    }
}
