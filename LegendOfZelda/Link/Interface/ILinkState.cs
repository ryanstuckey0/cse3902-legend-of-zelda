using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Interface
{
    interface ILinkState
    {
        void Update();
        void Draw();
        void Move(Constants.Direction direction);
        void BeDamaged(double damage);
        void BeHealthy(double healAmount);
        void StopMoving();
        void PickUpItem(LinkConstants.LinkInventory itemType);
        void UseSword();
    }
}
