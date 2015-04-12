using System;
using System.Collections.Generic;
using System.IO;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Tile
	{
		private TextureInfo   spriteInfo;
		private SpriteTile[,] tiles;
		private Vector2i[,]	  tileIndex;
		private SpriteUV background;
		private TextureInfo backgroundInfo;
		
		//Generates level from a sprite sheet.
		public Tile (Scene scene)
		{
			backgroundInfo = new TextureInfo("/Application/Textures/grass.png");
			background = new SpriteUV(backgroundInfo);
			background.Quad.S = backgroundInfo.TextureSizef;
			scene.AddChild(background);
			
			tileIndex = ReadFile("/Application/Sprite_Index.txt");
			tiles = new SpriteTile[24,14];
			//0-4 width, 0-4 height.
			spriteInfo = new TextureInfo(new Texture2D("/Application/Textures/graveyard spritesheet.png", false),
			                             new Vector2i(6,6), TRS.Quad0_1);
			Vector2 size = new Vector2(40, 39);
			for(int i = 0; i < 24; i++)
			{
				for(int c = 0; c < 14; c++)
				{
					tiles[i,c] = new SpriteTile(spriteInfo);
					tiles[i,c].TileIndex2D = new Vector2i(tileIndex[i,c].X,
					                                      tileIndex[i,c].Y);
					tiles[i,c].Quad.S = size;
					tiles[i,c].Position = new Vector2(i * 40, c * 39);
					scene.AddChild(tiles[i,c]);
				}
			}
		}
		
		public static Vector2i[,] ReadFile(string path)
		{
			Vector2i[,] spriteIndexArray = new Vector2i[24,14];
			string[] values;
			
			Console.WriteLine(File.Exists(path)? "File exists." : "File does not exist.");
			var reader = new StreamReader(File.OpenRead(path));
			
			for(int i = 13; i >= 0; i--)
			{
				values = reader.ReadLine().Split('|');				
				for(int c = 23; c >= 0; c--)
				{
					var index = values[c].Split(',');
					spriteIndexArray[c, i] = new Vector2i(int.Parse(index[0]), int.Parse(index[1])); 
				}
			}
			
			return spriteIndexArray;
		}
	}
}

