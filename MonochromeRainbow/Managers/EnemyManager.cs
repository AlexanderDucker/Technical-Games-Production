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
	public class EnemyManager
	{
		public List<Weapon> weaponList = new List<Weapon>();
		public List<Enemy> enemies = new List<Enemy>();
		public Vector2[] spawnpoints;
		public int enemyCount;
		public TextureLoading textures;
		public Scene scene;
		int spawnpnt = 0;
		private static GamePadData		gamePadData;

		
		public EnemyManager (Scene gameScene, TextureLoading textureManager)
		{
			SetSpawnPoints ();
			scene = gameScene;
			textures = textureManager;
			enemyCount = 20;
		}
		
		public void Update(Vector2 playerPos, bool playerMoving)
		{
			if(enemies.Count < enemyCount)
			{	
				//if there are not 20 enemies in the list - works for respawning.
				//loops through four spawnpoints and creates an enemy at each one
				CreateNewEnemy (spawnpnt, playerPos);
				spawnpnt++;
			}
			
			//resets the spawn counter
			if(spawnpnt >3)
				spawnpnt = 0; 
			
			for(int i = 0; i < enemies.Count; i++)
			{
				enemies[i].Update(playerPos);	
				enemies[i].RunAI (playerPos);
				enemies[i].Shoot (playerPos, scene, playerMoving, weaponList);
			}
			//TEMPORARY STUFF
			gamePadData = GamePad.GetData(0);
			 if (((gamePadData.Buttons & GamePadButtons.Circle) != 0))
			{
				enemies[0].Health = 0.0f;
		    }	
			//TEMPORARY STUFF
			
			if(weaponList.Count > 0)
			{
				foreach(Weapon w in weaponList)
				{
					w.Update();
				}
			}
		}
		
		public void CreateNewEnemy(int spawnpt, Vector2 playerPos)
		{
			Random rand = new Random(Guid.NewGuid().GetHashCode());
			float speed = (float)rand.Next(10, 20);
			speed /= 10;
			float bulletSpeed = (float)rand.Next(100, 200);
			bulletSpeed /= 10;
			int fireRate = rand.Next(300, 500);
			Enemy enemy = new Enemy();
			enemy.SetTexture (textures.EnemyTex, spawnpoints[spawnpt]);
			enemy.InitData (playerPos, speed, fireRate, bulletSpeed);
			scene.AddChild (enemy.enemy);	
			enemies.Add (enemy);
		}
		
		public void SetSpawnPoints()
		{
			spawnpoints = new Vector2[4];
			spawnpoints[0] = new Vector2(0,0);
			spawnpoints[1] = new Vector2(0,520);
			spawnpoints[2] = new Vector2(940,520);
			spawnpoints[3] = new Vector2(940, 0);
		}
	}
}

