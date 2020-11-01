﻿using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.GameLogic
{
    interface IGameState
    {
        ISpawnableManager SpawnableManager { get; }
        void Update();
        void Draw();
        void SwitchToRoomState();
        IPlayer GetPlayer(int playerNumber);
    }
}
