﻿using LegendOfZelda.Interface;
namespace LegendOfZelda.Sprint2
{
    class QuitGameCommand : ICommand
    {
        private Game1 myGame;
        public QuitGameCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }
}
