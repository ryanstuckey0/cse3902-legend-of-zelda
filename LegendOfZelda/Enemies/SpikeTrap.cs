﻿using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    class SpikeTrap : INpc
    {
        private IDamageableSprite sprite;
        private SpriteBatch spriteBatch;
        private Point position;
        private int maxDistance = Constants.SpikeTrapMaxDist;
        private int currentDist = 0;
        private int goingVelocity = Constants.SpikeTrapGoingVelocity;
        private int returningVelocity = Constants.SpikeTrapReturningVelocity;
        private bool returning = false;
        private bool going = false;
        private IPlayer link;
        private Rectangle LinkPosition;
        private Rectangle TrapPosition;
        private Constants.Direction currentDirection;
        private bool safeToDespawn;

        public SpikeTrap(SpriteBatch spriteBatch, Point spawnPosition, IPlayer link)
        {
            sprite = EnemySpriteFactory.Instance.CreateSpikeTrapSprite();
            this.spriteBatch = spriteBatch;
            this.link = link;
            position = new Point(spawnPosition.X, spawnPosition.Y);
            safeToDespawn = false;
        }

        public void Update()
        {
            sprite.Update();
            LinkPosition = link.GetRectangle();
            TrapPosition = sprite.GetPositionRectangle();
            if (!returning)
            {
                CheckOverlap();
            }
            else if (going)
            {
                if (currentDirection == Constants.Direction.Left)
                {
                    GoingLeft();
                }
                else if (currentDirection == Constants.Direction.Right)
                {
                    GoingRight();
                }
                else if (currentDirection == Constants.Direction.Up)
                {
                    GoingUp();
                }
                else
                {
                    GoingDown();
                }
            }
            else
            {
                if (currentDirection == Constants.Direction.Left)
                {
                    ReturningRight();
                }
                else if (currentDirection == Constants.Direction.Right)
                {
                    ReturningLeft();
                }
                else if (currentDirection == Constants.Direction.Up)
                {
                    ReturningDown();
                }
                else
                {
                    ReturningUp();
                }
            }
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }
        private void CheckOverlap()
        {
            if ((LinkPosition.Top <= TrapPosition.Bottom || LinkPosition.Bottom >= TrapPosition.Top) && LinkPosition.Left >= TrapPosition.Right)
            {
                currentDirection = Constants.Direction.Right;
                going = true;

            }
            else if ((LinkPosition.Top <= TrapPosition.Bottom || LinkPosition.Bottom >= TrapPosition.Top) && LinkPosition.Right <= TrapPosition.Left)
            {
                currentDirection = Constants.Direction.Left;
                going = true;

            }
            else if (LinkPosition.Bottom <= TrapPosition.Top && (LinkPosition.Left <= TrapPosition.Right || LinkPosition.Right >= TrapPosition.Left))
            {
                currentDirection = Constants.Direction.Up;
                going = true;

            }
            else if (LinkPosition.Top >= TrapPosition.Bottom && (LinkPosition.Right <= TrapPosition.Left || LinkPosition.Left <= TrapPosition.Right))
            {
                currentDirection = Constants.Direction.Down;
                going = true;
            }
        }
        private void GoingRight()
        {
            position.X += goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistance)
            {
                returning = true;
                going = false;
            }

        }
        private void ReturningLeft()
        {
            position.X -= returningVelocity;
            currentDist -= returningVelocity;
            if (currentDist <= 0)
            {
                returning = false;
            }
        }
        private void ReturningRight()
        {
            position.X += returningVelocity;
            currentDist -= returningVelocity;
            if (currentDist <= 0)
            {
                returning = false;
            }
        }
        private void ReturningUp()
        {
            position.Y -= returningVelocity;
            currentDist -= returningVelocity;
            if (currentDist <= 0)
            {
                returning = false;
            }
        }
        private void ReturningDown()
        {
            position.Y += returningVelocity;
            currentDist -= returningVelocity;
            if (currentDist <= 0)
            {
                returning = false;
            }
        }
        private void GoingLeft()
        {
            position.X -= goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistance)
            {
                returning = true;
                going = false;
            }
        }
        private void GoingUp()
        {
            position.Y -= goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistance)
            {
                returning = true;
                going = false;
            }
        }
        private void GoingDown()
        {
            position.Y += goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistance)
            {
                returning = true;
                going = false;
            }
        }
        public void ResetPosition()
        {
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
        }
        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }
        public void SetPosition(Point position)
        {
            this.position = position;
        }
        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }
        public Point GetPosition()
        {
            return position;
        }
        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }

        public void TakeDamage(double damage)
        {
            // spike trap is invincible
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
    }
}
