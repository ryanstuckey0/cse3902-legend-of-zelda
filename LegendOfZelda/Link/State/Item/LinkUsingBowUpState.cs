using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.Item;
using LegendOfZelda.Link.State.NotMoving;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkUsingBowUpState : ILinkState
    {
        private LinkPlayer link;
        private bool damaged;
        private DateTime healthyDateTime;

        public LinkUsingBowUpState(LinkPlayer link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkUsingBowUpState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(LinkPlayer link)
        {
            this.link = link;
            this.link.SpawnItem(new ArrowFlyingItem(link, Constants.Direction.Up));
        }

        public void Update()
        {
            StopMoving(); // because after we spawn the boomerang return to non-moving state
        }

        public void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.GetPosition(), damaged);
        }

        public void MoveDown()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveLeft()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveRight()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveUp()
        {
            // Cannot interupt state, do nothing
        }

        public void BeDamaged(int damage)
        {
            if (!damaged)
            {
                damaged = true;
                this.link.SubtractHealth(damage);
                healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
            }
        }

        public void BeHealthy()
        {
            damaged = false;
        }

        public void StopMoving()
        {
            link.SetState(new LinkStandingStillUpState(link, damaged, healthyDateTime));
        }

        public void UseSword()
        {
            // Cannot interupt state, do nothing
        }
        public void UseBow()
        {
            // Already using bow, do nothing
        }

        public void PickUpItem()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpSword()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpHeartContainer()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpTriforce()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpBow()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpBoomerang()
        {
            // Cannot interupt state, do nothing
        }

        public void UseBomb()
        {
            // Cannot interupt state, do nothing
        }

        public void UseBoomerang()
        {
            // Cannot interupt state, do nothing
        }

        public void UseSwordBeam()
        {
            // Cannot interupt state, do nothing
        }
    }
}
