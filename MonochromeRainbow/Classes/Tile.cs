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
		private TextureInfo		 spriteInfo;
		private List<SpriteTile> tiles;
		private Vector2i[]		 tileIndex;
		//Generates level from a sprite sheet.
		public Tile (Scene scene)
		{
			tiles = new List<SpriteTile>();
			tileIndex = ReadFile("/Application/Sprite_Index.txt");
			spriteInfo 	   = new TextureInfo(new Texture2D("/Application/Textures/spritesheet.png", false),
			                                 new Vector2i(3,1), TRS.Quad0_1);
			
			for(int i = 0; i < tileIndex.Length; i++)
			{
				tiles.Add(new SpriteTile(spriteInfo));
				tiles[i].TileIndex2D = new Vector2i(tileIndex[i].X, tileIndex[i].Y);
				
				tiles[i].Quad.S  = spriteInfo.TileSizeInPixelsf;
				scene.AddChild(tiles[i]);
			}
			
			tiles[0].Position = new Vector2(0,0);
			tiles[1].Position = new Vector2(320,0);
			tiles[2].Position = new Vector2(640,0);
		}
		
		public static Vector2i[] ReadFile(string path)
		{
			Vector2i[] spriteIndexArray;
			
			Console.WriteLine(File.Exists(path)? "File exists." : "File does not exist.");
			var reader = new StreamReader(File.OpenRead(path));
			{
				int length = int.Parse(reader.ReadLine());
				spriteIndexArray = new Vector2i[length];
				
				for(int i = 0; i < length; i++)
				{
					var values = reader.ReadLine().Split(',');
					spriteIndexArray[i] = new Vector2i(int.Parse(values[0]), int.Parse(values[1])); 
				}
			}
			
			return spriteIndexArray;
		}
		
		public void Update()
		{
			
		}
	}
}

