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
		
		//Generates level from a sprite sheet.
		public Tile (Scene scene)
		{
			tileIndex = ReadFile("/Application/Sprite_Index.txt");
			tiles = new SpriteTile[12,7];
			//0-5 width, 0-1 height.
			spriteInfo = new TextureInfo(new Texture2D("/Application/Textures/Spritesheet_Minecraft.png", false),
			                             new Vector2i(6,2), TRS.Quad0_1);
			
			for(int i = 0; i < 12; i++)
			{
				for(int c = 0; c < 7; c++)
				{
					tiles[i,c] = new SpriteTile(spriteInfo);
					tiles[i,c].TileIndex2D = new Vector2i(tileIndex[i,c].X,
					                                      tileIndex[i,c].Y);
					tiles[i,c].Quad.S  = new Vector2(80,80);
					tiles[i,c].Position = new Vector2(i * 80, c * 80);
					scene.AddChild(tiles[i,c]);
				}
			}
		}
		
		public static Vector2i[,] ReadFile(string path)
		{
			Vector2i[] spriteIndexArray;
			
			Console.WriteLine(File.Exists(path)? "File exists." : "File does not exist.");
			var reader = new StreamReader(File.OpenRead(path));
			
			var values = reader.ReadLine().Split(',');
			Vector2i length = new Vector2i(int.Parse(values[0]), int.Parse(values[1]));
			spriteIndexArray = new Vector2i[length.X*length.Y];
			
			for(int i = 0; i < spriteIndexArray.Length; i++)
			{
				values = reader.ReadLine().Split(',');
				spriteIndexArray[i] = new Vector2i(int.Parse(values[0]), int.Parse(values[1])); 
			}
			
			return ConvertTo2DArray(length, spriteIndexArray);
		}
		
		public static Vector2i[,] ConvertTo2DArray(Vector2i indicies, Vector2i[] array)
		{
			Vector2i[,]spriteIndexArray2D = new Vector2i[indicies.X, indicies.Y];
			
			for(int i = 0; i < indicies.X; i++)
			{
				for(int c = 0; c < indicies.Y; c++)
				{
					spriteIndexArray2D[i,c] = array[c * indicies.Y + i];
				}
			}
			
			return spriteIndexArray2D;
		}
		
		public void Update()
		{
			
		}
	}
}

