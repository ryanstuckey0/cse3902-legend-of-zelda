using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    class SwordAttackingProjectile : GenericProjectile
    {
        public SwordAttackingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.Direction direction, Constants.ItemOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            Velocity = Vector2.Zero;
            switch (direction)
            {
                case Constants.Direction.Down:
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackingDownSprite();
                    break;
                case Constants.Direction.Up:
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackingUpSprite();
                    break;
                case Constants.Direction.Right:
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackingRightSprite();
                    break;
                case Constants.Direction.Left:
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackingLeftSprite();
                    break;
            }
        }

        public override void Update()
        {
            Mover.Update();
            CheckItemIsExpired();
        }
        public override void Draw()
        {
            sprite.Draw(spriteBatch, Position);
        }

        protected void CheckItemIsExpired()
        {
            itemIsExpired = sprite.FinishedAnimation();
        }

        public override double DamageAmount()
        {
            return Constants.ArrowDamage;
        }
    }
}
