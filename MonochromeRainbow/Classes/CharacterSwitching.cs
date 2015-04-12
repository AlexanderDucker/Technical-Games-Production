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
	public class CharacterSwitching
	{
				private GamePadData		gamePadData;
		//private bool 				hasSwapped, canSwap, firstSwap;
		public CharacterSwitching ()
		{
			
		}
		

		public void CheckDistance(EnemyBase e, Player p)
		{
						gamePadData = GamePad.GetData(0);
			Vector2 dir = (p.CenterPosition) - (e.CenterPosition);
			float distanceSqrd = Square(dir.X) + Square(dir.Y);

			Console.WriteLine(distanceSqrd);
			
			if(distanceSqrd <= Square(e.Radius) + Square(p.Radius))
			{
				Console.WriteLine("collision");
				//Swap sprites & positions. press a.
				if (((gamePadData.Buttons & GamePadButtons.Square) != 0))
				{
					if(p.canSwap)
					{
						p.hasSwapped = true;
						p.canSwap = false;
						Console.WriteLine("erjngtlkejrngt");
					}
				}
				if (((gamePadData.Buttons & GamePadButtons.Square) == 0))
				{
					p.hasSwapped = false;
					p.canSwap = true;
				}
			}
			
			if(p.hasSwapped)
			{
				EnemyEvasive tempEnemy = new EnemyEvasive();
				//tempEnemy.changeTexture(0, player.textures[0]);
				//tempEnemy.changeTexture(1, player.textures[1]);
				tempEnemy.ChangeTexture(p.textures[0], p.textures[1], p.centerPosition);
				tempEnemy.speed = p.speed;
				tempEnemy.fireRate = p.fireRate;
				tempEnemy.shootSpeed = p.shootSpeed;
				tempEnemy.bulletTex = p.bulletTex;
				
				p.textures[0] = e.GetTexture(0);
				p.textures[1] = e.GetTexture(1);
				p.PlayerSprite.TextureInfo = p.textures[0];
				p.speed = e.speed;
				p.fireRate = e.fireRate;
				p.shootSpeed = e.shootSpeed;
				p.bulletTex = e.bulletTex;
				
				//e.changeTexture(0, tempEnemy.GetTexture(0));
				//e.changeTexture(1, tempEnemy.GetTexture(1));
				//e.EnemySprite.TextureInfo = e.GetTexture(1);
				e.ChangeTexture(tempEnemy.GetTexture(0), tempEnemy.GetTexture(1), tempEnemy.CenterPosition);
				e.speed = tempEnemy.speed;
				e.fireRate = tempEnemy.fireRate;
				e.shootSpeed = tempEnemy.shootSpeed;
				e.bulletTex = tempEnemy.bulletTex;
				
				p.hasSwapped = false;
			}
			
			}
		
		
		private float Square(float a){return a*a;}
		}
	}


