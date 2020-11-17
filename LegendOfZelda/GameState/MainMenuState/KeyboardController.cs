﻿using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenu
{
    internal class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> oldKbState;
        private List<Keys> repeatableKeys;
        private readonly ICommand exitGameCommand;
        private readonly ICommand startGameCommand;

        public KeyboardController(IGameState gameState)
        {
            oldKbState = new List<Keys>();

            exitGameCommand = new ExitGameCommand(gameState);
            startGameCommand = new StartGameCommand(gameState);

            InitRepeatableKeys();
            InitControllerMappings(gameState);
        }

        public void InitControllerMappings(IGameState gameState)
        {
            controllerMappings = new Dictionary<Keys, ICommand>
            {
                {Keys.Escape, exitGameCommand }
            };
        }

        public GameStateConstants.InputType GetInputType()
        {
            return GameStateConstants.InputType.Keyboard;
        }

        public OldInputState GetOldInputState()
        {
            return new OldInputState { oldKeyboardState = oldKbState };
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void SetOldInputState(OldInputState oldInputState)
        {
            oldKbState = oldInputState.oldKeyboardState;
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            bool changedKbState = false;

            foreach (Keys key in pressedKeys)
            {
                changedKbState = true;
                bool inOldKbState = oldKbState.Contains(key);
                if (inOldKbState) oldKbState.Remove(key);
                if (!repeatableKeys.Contains(key)) oldKbState.Add(key);
                if (controllerMappings.ContainsKey(key) && !inOldKbState)
                {
                    controllerMappings[key].Execute();
                }
                if (key != Keys.Escape) startGameCommand.Execute();
            }
            if (!changedKbState) oldKbState = new List<Keys>();
        }

        private void InitRepeatableKeys()
        {
            repeatableKeys = new List<Keys>()
            {
                // TODO: add repeatable keys here
            };
        }
    }
}
