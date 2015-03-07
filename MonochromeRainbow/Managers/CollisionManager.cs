using System;
using System.Diagnostics;
using System.Collections.Generic;


using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class CollisionManager
	{
		public List<Enemy> enemies1 = new List<Enemy>();
		public Player p1;
		
		public CollisionManager ()
		{
		}
		
		public void CheckCollisions(Player player, List<Enemy> enemies, Scene scene)
		{
			p1 = player;
			enemies1 = enemies;

			//Loops through each weapon list of each enemy for collision with player
			for(int i = 0; i < enemies.Count; i++)
			{
				for(int y = 0; y < enemies[i].weaponList.Count; y++)
				{
					enemies[i].weaponList[y].weapon.GetContentWorldBounds(ref enemies[i].weaponList[y].bounds);
					p1.PlayerSprite.GetContentWorldBounds(ref player.bounds);
					if(enemies[i].weaponList[y].bounds.Overlaps(p1.bounds))
					{
						if(p1.health > 0)
						{
							//Currently reduces player health by fixed amount and prints to console window
						    p1.health -= 1;
							Console.WriteLine(p1.health);
						}
						
						scene.RemoveChild(enemies[i].weaponList[y].weapon, true);
			
					}
				//Checks for projectile collisions with side of screen	
					if(enemies[i].weaponList[y].weapon.Position.X > Director.Instance.GL.Context.GetViewport().Width + enemies[i].weaponList[y].weapon.Quad.S.X)
					{
						scene.RemoveChild(enemies[i].weaponList[y].weapon, true);
					}
					
					if(enemies[i].weaponList[y].weapon.Position.X < -10.0f)
					{
						scene.RemoveChild(enemies[i].weaponList[y].weapon, true);
					}
					
					if(enemies[i].weaponList[y].weapon.Position.Y < -10.0f)
					{
						scene.RemoveChild(enemies[i].weaponList[y].weapon, true);
					}
					
					if(enemies[i].weaponList[y].weapon.Position.Y > Director.Instance.GL.Context.GetViewport().Height + enemies[i].weaponList[y].weapon.Quad.S.X)
					{
						scene.RemoveChild(enemies[i].weaponList[y].weapon, true);
					}
				//End of projectile collision with screen check
				}
			}
			
		}
	}
}

