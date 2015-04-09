using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace MonochromeRainbow
{
	public class TextureSwitching
	{
		//private bool 				hasSwapped, canSwap, firstSwap;
		public TextureSwitching ()
		{
			
		}
		
		public void CheckTextureSwitch()
		{
			//		public void CheckDistance(Enemy e)
//		{
//			Vector2 dir = (player.CenterPosition) - (e.CenterPosition);
//			float distanceSqrd = Square(dir.X) + Square(dir.Y);
//			
//			Console.WriteLine(distanceSqrd);
//			
//			if(distanceSqrd <= Square(e.Radius) + Square(player.Radius))
//			{
//				Console.WriteLine("collision");
//				//Swap sprites & positions. press a.
//				if (((gamePadData.Buttons & GamePadButtons.Square) != 0))
//				{
//					if(canSwap)
//					{
//						hasSwapped = true;
//						canSwap = false;
//					}
//				}
//				if (((gamePadData.Buttons & GamePadButtons.Square) == 0))
//				{
//					hasSwapped = false;
//					canSwap = true;
//				}
//			}
//			
//			if(hasSwapped)
//			{
//				if(firstSwap)
//				{
//					player.PlayerSprite.TextureInfo = tl.EnemyTex;
//					player.PlayerSprite.Quad.S = player.PlayerSprite.TextureInfo.TextureSizef;
//					e.EnemySprite.TextureInfo = tl.DeadPlayerTex;
//					e.EnemySprite.Quad.S = e.EnemySprite.TextureInfo.TextureSizef;
//					Vector2 tempPos = e.EnemySprite.Position;
//					e.EnemySprite.Position = player.PlayerSprite.Position;
//					player.PlayerSprite.Position = tempPos;
//					hasSwapped = false;
//					firstSwap = false;
//				}
//				else
//				{
//					player.PlayerSprite.TextureInfo = tl.PlayerTex;
//					player.PlayerSprite.Quad.S = player.PlayerSprite.TextureInfo.TextureSizef;
//					e.EnemySprite.TextureInfo = tl.DeadEnemyTex;
//					e.EnemySprite.Quad.S = e.EnemySprite.TextureInfo.TextureSizef;
//					Vector2 tempPos = e.EnemySprite.Position;
//					e.EnemySprite.Position = player.PlayerSprite.Position;
//					player.PlayerSprite.Position = tempPos;
//					hasSwapped = false;
//					firstSwap = true;
//				}
//				
//			}
//		}
		
		//private float Square(float a){return a*a;}
		}
	}
}

