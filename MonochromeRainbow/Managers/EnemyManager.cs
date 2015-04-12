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
		public List<Vector2>  enemyPositions = new List<Vector2>();
		public Vector2[] spawnpoints;
		public int enemyCount;
		public TextureLoading textures;
		public CharacterSwitching cSwitch;
		public Scene scene;
		int spawnpnt = 0;
		private static GamePadData		gamePadData;

		
		public EnemyManager (Scene gameScene, TextureLoading textureManager)
		{
			SetSpawnPoints ();
			scene = gameScene;
			textures = textureManager;
			enemyCount = 20;
			cSwitch = new CharacterSwitching();
		}
		
		public void Update(Player player)
		{
			if(enemies.Count < enemyCount)
			{	
				//if there are not 20 enemies in the list - works for respawning.
				//loops through four spawnpoints and creates an enemy at each one
				CreateNewEnemy (spawnpnt, player.CenterPosition);
				spawnpnt++;	          
			}
			
			//resets the spawn counter
			if(spawnpnt >3)
				spawnpnt = 0; 
			
			for(int i = 0; i < enemies.Count; i++)
			{
				enemies[i].Update(player.CenterPosition);
				if (enemies[i].IsAlive)
				{
					enemies[i].RunAI (player.CenterPosition, enemyPositions);
					enemies[i].Shoot (player.CenterPosition, scene, !player.movingDirection.IsZero(), weaponList);
				}
				else
				{
					cSwitch.CheckDistance(enemies[i], player);
				}
				Console.Write(i + " " + enemies[i].health + " " + enemies[i].IsAlive + ", ");
				//Console.WriteLine (weaponList.Count);
			}
			Console.WriteLine();
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

			Random rnd = new Random();
			int enemytype = rnd.Next (3);
			if(enemytype == 0)
			{
				EnemyBase enemy = new EnemyChaser();
				enemy.SetTexture (textures.EnemyChaserTex, textures.DeadEnemyTex, spawnpoints[spawnpt], scene);
				enemy.InitData(new Vector2(0,0), 2.0f, 400.0f, 20.0f);
				enemies.Add (enemy);
			}
			else if( enemytype ==1)
			{
				EnemyBase enemy = new EnemyTank();
				enemy.SetTexture (textures.EnemyTankTex, textures.DeadEnemyTex, spawnpoints[spawnpt], scene);
				enemy.InitData(new Vector2(0,0), 0.1f, 2000.0f, 30.0f);
				enemies.Add (enemy);
			}
			else if(enemytype == 2)
			{
				EnemyBase enemy = new EnemyEvasive();
				enemy.SetTexture (textures.EnemyEvasiveTex, textures.DeadEnemyTex, spawnpoints[spawnpt], scene);
				enemy.InitData(new Vector2(0,0), 3.0f, 1500.0f, 40.0f);
				enemies.Add (enemy);
			}
			
		}
		
		public void DecideEnemyType()
		{
				
		}
		
		public void SetSpawnPoints()
		{
			spawnpoints = new Vector2[4];
			spawnpoints[0] = new Vector2(0,0);
			spawnpoints[1] = new Vector2(0,496);
			spawnpoints[2] = new Vector2(912,496);
			spawnpoints[3] = new Vector2(912, 0);
		}
	}
}

