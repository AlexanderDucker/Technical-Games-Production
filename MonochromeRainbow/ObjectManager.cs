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
		EnemyManager 	enemyManager;
		TextureLoading 	textureManager;
		public ObjectManager (Scene gameScene)
		{
			enemyManager = new EnemyManager(gameScene);
			enemyManager.InitEnemies ();
			textureManager = new TextureLoading();
		}
		
		public void UpdateObjects()
		{
			enemyManager.Update ();	
		}
	}
}

