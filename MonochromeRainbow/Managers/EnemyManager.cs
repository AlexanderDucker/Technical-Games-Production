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
		public List<EnemyBase> enemies = new List<EnemyBase>();
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
				Console.WriteLine (weaponList.Count);
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
			
			Random rnd = new Random();
			int enemytype = rnd.Next (3);
			if(enemytype == 0)
			{
				EnemyBase enemy = new EnemyChaser();
				enemy.SetTexture (textures.EnemyChaserTex, spawnpoints[spawnpt], scene);
				enemies.Add (enemy);
			}
			else if( enemytype ==1)
			{
				EnemyBase enemy = new EnemyTank();
				enemy.SetTexture (textures.EnemyTankTex, spawnpoints[spawnpt], scene);
				enemies.Add (enemy);
			}
			
			else
				CreateNewEnemy (spawnpt, playerPos);
			
		}
		
		public void DecideEnemyType()
		{
				
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

