﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace LegendOfZelda.Rooms
{
    class CSVReader
    {
        ItemSpawner allObjects = new ItemSpawner();
        private SpriteBatch spriteBatch;
        private const int tileLength = 16;
        //String Abbreviations from CSV File
        string Block = "block";
        string BlueTile = "---";
        string BrickTile = "brick";
        string Fire = "fire";
        string GapTile = "black";
        string LadderTile = "lad";
        string Stairs = "stairs";
        string Statue = "stat";
        string BlueGrass = "bg";
        string Water = "water";

        public CSVReader(SpriteBatch spriteBatch, string fileName)
        {
            this.spriteBatch = spriteBatch;
            TextFieldParser parser = new TextFieldParser(fileName);
            parser.Delimiters = new string[] { "," }; //Delimiters are like separators in NextWordOrSeparator
            int j = 0;
            //Read each line of the file
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                for(int i = 0; i < fields.Length; i++)
                {
                    spawnFromString(fields[i], i, j);
                }
            }
        }

        private void spawnFromString(string spawnType, int gridX, int gridY)
        {
            Point position = new Point(gridX * tileLength, gridY * tileLength);
            IBlock blockType;

            switch (spawnType)
            {
                case Block:
                    break;
                case BlueTile:
                    break;
                case BrickTile:
                    blockType = new BrickTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case GapTile:
                    blockType = new GapTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case Fire:
                    blockType = new Fire(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case LadderTile:
                    blockType = new LadderTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case Stairs:
                    blockType = new Stairs(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case Statues:
                    blockType = new Statues(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case BlueGrass:
                    blockType = new BlueGrass(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case Water:
                    blockType = new Water(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                default:
                    break;

            }
        }

    }
}
