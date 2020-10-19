using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    class BombExplodingProjectile : GenericProjectile
    {
        public BombExplodingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ItemOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            sprite = ProjectileSpriteFactory.Instance.CreateBombExplodingSprite();
        }

        public override void Update()
        {
            sprite.Update();
        }

        protected override void CheckItemIsExpired()
        {
            sprite.FinishedAnimation();
        }

        public override Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }

        public bool IsExploded()
        {
            return sprite.FinishedAnimation();
        }
        public override double DamageAmount()
        {
            return Constants.BombDamage;
        }
    }
}
