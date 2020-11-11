﻿using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class MinimapManager
    {
        private RoomGameState roomGameState;
        private ISprite minimapSprite;
        private bool displayMinimap;
        private ISprite linkMinimapSquare;
        private ISprite triforceMinimapSquare;
        private Point triforceRoomLocation = new Point(5, 4);
        private bool hasCompass;

        public MinimapManager(RoomGameState roomGameState)
        {
            this.roomGameState = roomGameState;
            minimapSprite = HUDSpriteFactory.Instance.CreateMiniMapSprite();
            linkMinimapSquare = HUDSpriteFactory.Instance.CreateLinkMinimapSquareSprite();
            triforceMinimapSquare = HUDSpriteFactory.Instance.CreateTriforceMinimapSquareSprite();
            displayMinimap = false;
            hasCompass = false;
        }

        public void Draw(Point hudPosition)
        {
            if (displayMinimap)
            {
                minimapSprite.Draw(roomGameState.Game.SpriteBatch, hudPosition + HUDConstants.MinimapLocation, Constants.DrawLayer.HUD);
                if (hasCompass)
                    triforceMinimapSquare.Draw(roomGameState.Game.SpriteBatch, hudPosition + HUDConstants.MinimapSquarePositions[triforceRoomLocation], Constants.DrawLayer.HUD);
                linkMinimapSquare.Draw(roomGameState.Game.SpriteBatch, hudPosition + HUDConstants.MinimapSquarePositions[roomGameState.CurrentRoom.LocationOnMap], Constants.DrawLayer.HUD);
            }

        }

        public void Update()
        {
            if (!displayMinimap && roomGameState.PlayerList[0].GetQuantityInInventory(LinkConstants.ItemType.Map) != 0)
                displayMinimap = true;
            if (!hasCompass && roomGameState.PlayerList[0].GetQuantityInInventory(LinkConstants.ItemType.Compass) != 0)
                hasCompass = true;
            if (displayMinimap)
            {
                linkMinimapSquare.Update();
                triforceMinimapSquare.Update();
            }
        }
    }
}
