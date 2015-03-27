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
	public class TheGame
	{
		private static Sce.PlayStation.HighLevel.GameEngine2D.Scene 	gameScene;
		private static Sce.PlayStation.HighLevel.UI.Scene 				uiScene;
		
		private ObjectManager objectManager;
		
		//public TheGame(){ hasSwapped = false; canSwap = true; firstSwap = true;}
		
		public void LoadLevel()
		{
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			gameScene.Camera.SetViewFromViewport();
			objectManager = new ObjectManager(gameScene);
			
			UISystem.SetScene(uiScene);
			//Run the scene.
			Director.Instance.RunWithScene(gameScene, true);
		}
		
		public void Update()
		{
			//Get gamepad input.
		
			objectManager.UpdateObjects ();
		}
				
	}
}

