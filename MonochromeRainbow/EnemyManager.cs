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
		public List<Enemy> enemies = new List<Enemy>();
		public Vector2[] spawnpoints;
		public int enemyCount;
		public Enemy enemy;
		public TextureLoading textures;
		public Scene scene;
		public EnemyManager (Scene gameScene)
		{
			scene = gameScene;
			
		}
		
		public void InitEnemies()
		{
			enemyCount = 20;
			SetSpawnPoints ();
		}
		
		public void Update()
		{
			if(enemies.Count < enemyCount)
			{
				SpawnNewEnemy ();	
				
			}//if there are not 20 enemies on screen, add one to the list.
			//no enemies are auto spawned on game load, spawning happens after game is loaded.
			
			
			for(int i = 0; i < enemies.Count; i++)
			{
				enemy.Update ();	
			}
		}
		
		public void SpawnNewEnemy()
		{
			Random rnd = new Random();
			int rand = rnd.Next (4);
			enemies.Add (enemy);
			PassInTextures (textures);
			enemy.EnemySprite.Position = spawnpoints[rand];
			scene.AddChild (enemies[enemies.Count].enemy);
			
		}
		
		public void SetSpawnPoints()
		{
			spawnpoints = new Vector2[4];
			spawnpoints[0] = new Vector2(0,0);
			spawnpoints[1] = new Vector2(0,520);
			spawnpoints[2] = new Vector2(940,520);
			spawnpoints[3] = new Vector2(940, 0);
		}
		
		public void PassInTextures(TextureLoading textures)
		{
			int enemyNum = enemies.Count;
			enemies[enemyNum].SetTexture (textures.EnemyTex);
		}
	}
}

