﻿using LegendOfZelda.Link;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomFactory
    {
        private readonly List<Room> roomsList;
        private const int startingRoomNumber = 2;
        private const string roomDataDirectory = "Content\\RoomData\\";

        public RoomFactory(SpriteBatch spriteBatch, List<IPlayer> playerList) {
            roomsList = new List<Room>();
            InitRoomsList(spriteBatch, playerList);
            ConnectRooms();
        }

        public Room GetStartingRoom()
        {
            return roomsList[startingRoomNumber];
        }

        private void InitRoomsList(SpriteBatch spriteBatch, List<IPlayer> playerList)
        {
            roomsList.Add(null); // room files start at 1
            for(int i = 1; i <= RoomConstants.NumberRooms; i++)
            {
                roomsList.Add(new Room(spriteBatch, roomDataDirectory + "Room" + i + ".csv", playerList));
            }
        }

        private void ConnectRooms()
        {
            // Row 1
            roomsList[1].ConnectRoom(roomsList[2], Constants.Direction.Right); // connect 1-2
            roomsList[2].ConnectRoom(roomsList[3], Constants.Direction.Right); // connect 2-3

            // Row 2 - skip because there's only one in row, no left to right connections

            // Row 1 <-> Row 2
            roomsList[2].ConnectRoom(roomsList[4], Constants.Direction.Up); // connect 2-4

            // Row 3
            roomsList[5].ConnectRoom(roomsList[6], Constants.Direction.Right); // connect 5-6
            roomsList[6].ConnectRoom(roomsList[7], Constants.Direction.Right); // connect 6-7

            // Row 2 <-> Row 3
            roomsList[4].ConnectRoom(roomsList[6], Constants.Direction.Up); // connect 4-6

            // Row 4
            roomsList[8].ConnectRoom(roomsList[9], Constants.Direction.Right); // connect 8-9
            roomsList[9].ConnectRoom(roomsList[10], Constants.Direction.Right); // connect 9-10
            roomsList[10].ConnectRoom(roomsList[11], Constants.Direction.Right); // connect 10-11
            roomsList[11].ConnectRoom(roomsList[12], Constants.Direction.Right); // connect 11-12

            // Row 3 <-> 4
            roomsList[5].ConnectRoom(roomsList[9], Constants.Direction.Up); // connect 5-9
            roomsList[6].ConnectRoom(roomsList[10], Constants.Direction.Up); // connect 6-10
            roomsList[7].ConnectRoom(roomsList[11], Constants.Direction.Up); // connect 7-11

            // Row 5
            roomsList[14].ConnectRoom(roomsList[15], Constants.Direction.Right); // connect 14-15

            // Row 4 <-> 5
            roomsList[10].ConnectRoom(roomsList[13], Constants.Direction.Up); // connect 10-13
            roomsList[12].ConnectRoom(roomsList[14], Constants.Direction.Up); // connect 12-14

            // Row 6
            roomsList[16].ConnectRoom(roomsList[17], Constants.Direction.Right); // connect 16-17

            // Row 5 <-> 6
            roomsList[15].ConnectRoom(roomsList[17], Constants.Direction.Up); // connect 15-17
        }
    }
}
