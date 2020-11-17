﻿using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class SecretRoom : Room
    {
        public SecretRoom(List<IPlayer> playerList)
        {
            AllObjects = new SpawnableManager(playerList);

            roomDictionary = new Dictionary<Constants.Direction, IRoom>();
            roomDoors = new Dictionary<Constants.Direction, IDoor>();
            roomConnectionStrings = new Dictionary<Constants.Direction, string>();

            collisionManager = new CollisionManager(AllObjects);
            LocationOnMap = new Point(-1, -1);
            RoomType = 0;
            Visiting = false;
            SpawnWalls();
        }

        public override IRoom GetRoom(Constants.Direction direction)
        {
            if (direction == Constants.Direction.Stairs) UpdatePlayerPositions();
            return base.GetRoom(direction);
        }

        private void UpdatePlayerPositions()
        {
            foreach (IPlayer player in AllObjects.PlayerList) player.Position = LinkConstants.SecretRoomExitSpawnPosition;
        }

        private void SpawnWalls()
        {
            AllObjects.Spawn(new SecretRoomWall(RoomConstants.LeftWallRectangle));
            AllObjects.Spawn(new SecretRoomWall(RoomConstants.MiddleWallRectangle));
            AllObjects.Spawn(new SecretRoomWall(RoomConstants.RightWallRectangle));
            AllObjects.Spawn(new SecretRoomWall(RoomConstants.TopWallRectangle));

            AllObjects.Spawn(new RoomChangeTrigger(Constants.Direction.Stairs, RoomConstants.SecretRoomRoomChangeTrigger));
        }

    }
}
