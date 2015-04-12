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
		public List<EnemyBase> enemies1 = new List<EnemyBase>();
		public List<Weapon> tempWeaponList = new List<Weapon>();
		public List<Weapon> playerTempList = new List<Weapon>();

		public Player p1;
		
		public CollisionManager ()
		{
		}
		
		public void CheckCollisions(Player player, List<EnemyBase> enemies, Scene scene, EnemyManager manager)
		{
			p1 = player;
			enemies1 = enemies;

			//Loops through each weapon list of each enemy for collision with player
			for(int i = 0; i < manager.weaponList.Count; i++)
			{
					manager.weaponList[i].weapon.GetContentWorldBounds(ref manager.weaponList[i].bounds);
					p1.PlayerSprite.GetContentWorldBounds(ref player.bounds);
				    tempWeaponList = manager.weaponList;
					if(manager.weaponList[i].bounds.Overlaps(p1.bounds))
					{
						if(p1.health > 0)
						{
							//Currently reduces player health by fixed amount and prints to console window
						    p1.health -= 1;
							//Console.WriteLine(p1.health);
						}
					else if(p1.health <=0)
						p1.IsAlive = true;
						
						scene.RemoveChild(manager.weaponList[i].weapon, true);
						tempWeaponList.Remove(manager.weaponList[i]);
						break;
					}
				//Checks for projectile collisions with side of screen	
					if(manager.weaponList[i].weapon.Position.X > Director.Instance.GL.Context.GetViewport().Width + manager.weaponList[i].weapon.Quad.S.X)
					{
						scene.RemoveChild(manager.weaponList[i].weapon, true);
						tempWeaponList.Remove(manager.weaponList[i]);
						break;
					}
					
					if(manager.weaponList[i].weapon.Position.X < -10.0f)
					{
						scene.RemoveChild(manager.weaponList[i].weapon, true);
						tempWeaponList.Remove(manager.weaponList[i]);
						break;
					}
					
					if(manager.weaponList[i].weapon.Position.Y < -10.0f)
					{
						scene.RemoveChild(manager.weaponList[i].weapon, true);
						tempWeaponList.Remove(manager.weaponList[i]);
						break;
					}
					
					if(manager.weaponList[i].weapon.Position.Y > Director.Instance.GL.Context.GetViewport().Height + manager.weaponList[i].weapon.Quad.S.Y)
					{
						scene.RemoveChild(manager.weaponList[i].weapon, true);
						tempWeaponList.Remove(manager.weaponList[i]);
						break;
					}
				//End of projectile collision with screen check
				
				manager.weaponList = tempWeaponList;
			}
			
					for(int i = 0; i < player.weaponList.Count - 1; i++)
					{
						player.weaponList[i].weapon.GetContentWorldBounds(ref player.weaponList[i].bounds);
						playerTempList = player.weaponList;
						for(int y = 0; y < manager.enemies.Count - 1; y++)
						{
							manager.enemies[i].enemy.GetContentWorldBounds(ref manager.enemies[i].bounds);
							if(player.weaponList[i].bounds.Overlaps(manager.enemies[i].bounds))
							{
								manager.enemies[i].health -= 1.0f;
								scene.RemoveChild(player.weaponList[i].weapon, true);
								playerTempList.Remove(player.weaponList[i]);
							}
						}
				
				//Checks for projectile collisions with side of screen	
				if(player.weaponList[i].weapon.Position.X > Director.Instance.GL.Context.GetViewport().Width + player.weaponList[i].weapon.Quad.S.X)
				{
					scene.RemoveChild(player.weaponList[i].weapon, true);
					playerTempList.Remove(player.weaponList[i]);
				}
				
				if(player.weaponList[i].weapon.Position.X < -10.0f)
				{
					scene.RemoveChild(player.weaponList[i].weapon, true);
					playerTempList.Remove(player.weaponList[i]);
				}
				
				if(player.weaponList[i].weapon.Position.Y < -10.0f)
				{
					scene.RemoveChild(player.weaponList[i].weapon, true);
					playerTempList.Remove(player.weaponList[i]);
				}
				
				if(player.weaponList[i].weapon.Position.Y > Director.Instance.GL.Context.GetViewport().Height + player.weaponList[i].weapon.Quad.S.X)
				{
					scene.RemoveChild(player.weaponList[i].weapon, true);
					playerTempList.Remove(player.weaponList[i]);
				}
				//End of projectile collision with screen check
				
				player.weaponList = playerTempList;
			}
			
		}
	}
}

