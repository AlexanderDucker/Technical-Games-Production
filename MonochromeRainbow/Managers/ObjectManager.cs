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
		Scene scene;
		
		public ObjectManager (Scene gameScene)
		{
			textureManager = new TextureLoading();
			enemyManager = new EnemyManager(gameScene, textureManager);
			player = new Player(gameScene, new Vector2(100,100));
			collisions = new CollisionManager();
			mechanics = new MechanicManager(gameScene);
			scene = gameScene;
		}
		
		public void UpdateObjects()
		{
			enemyManager.Update(player.centerPosition, !player.movingDirection.IsZero());	
			player.Update (scene);
			collisions.CheckCollisions(player.getPlayerPos(), enemyManager.enemies);
		}
		
		
	}
}

