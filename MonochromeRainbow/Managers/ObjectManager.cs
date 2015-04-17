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
	public class ObjectManager
	{
		/*
		This class is for everything we add.
		It currently handles the EnemyManager, Player, the in progress Collisions and Mechanics.
		*/
		EnemyManager 	enemyManager;
		TextureLoading 	textureManager;
		Player player;
		CollisionManager collisions;
		MechanicManager mechanics;
		Tile level;
		Menu menu;
		public Scene scene;
		bool gameRunning = false;
		
		public ObjectManager (Scene gameScene)
		{
			textureManager = new TextureLoading();
			menu = new Menu(textureManager, gameScene);
			scene = gameScene;
		}
		
	
		
		public void StartGame(Scene gameScene)
		{
			level = new Tile(gameScene);
			textureManager = new TextureLoading();
			enemyManager = new EnemyManager(gameScene, textureManager);
			player = new Player(gameScene, new Vector2(100,100), textureManager);
			collisions = new CollisionManager();
			mechanics = new MechanicManager(gameScene);
		}
		
		public void UpdateObjects()
		{
			if(gameRunning)
			{
				if(player.inputManager.GetPaused () == false)
				{
					enemyManager.Update(player);	
					player.Update (scene);
					collisions.CheckCollisions(player, enemyManager.enemies, scene, enemyManager);
				}
				else
					player.inputManager.CheckPaused ();
				
			}
			else
			{
				menu.UpdateMenus ();
				if(menu.GetStart() == true)
				{
					gameRunning = true;	
					StartGame(scene);
				}
			}
		}
		
		
	}
}

