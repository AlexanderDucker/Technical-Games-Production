//implementing scenes
//if count = 1,2 or 3
//why ~main

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
	public class AppMain
	{
		private static bool quitGame = false;
		public static Sce.PlayStation.HighLevel.GameEngine2D.Scene 		gameScene;
		private static Sce.PlayStation.HighLevel.UI.Scene 				uiScene;
		
		public static GamePadData		gamePadData;
	
		public static Player player;
		
			
		public static void Main (string[] args)
		{					
			
			Initialize();
			
			//Game loop
			while (!quitGame) 
			{
				Update();
				
				Director.Instance.Update();
				Director.Instance.Render();
				UISystem.Render();
				
				Director.Instance.GL.Context.SwapBuffers();
				Director.Instance.PostSwap();
			}
			Director.Terminate();
		}

		public static void Initialize ()
		{
			//Set up director and UISystem.
			Director.Initialize ();
			UISystem.Initialize(Director.Instance.GL.Context);
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			gameScene.Camera.SetViewFromViewport();
			
			
			LoadLevel();
			
			UISystem.SetScene(uiScene);
			//Run the scene.
			Director.Instance.RunWithScene(gameScene, true);
		}
		
		public static void Update()
		{
			player.Update (gameScene);
		}
		
		
		
		public static void LoadLevel()
		{	
			player = new Player(gameScene, new Vector2(500,100));
		}	
	}
}