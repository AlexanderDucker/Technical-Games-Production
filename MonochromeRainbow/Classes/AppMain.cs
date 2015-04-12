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
		private static TheGame theGame;
		
		public static void Main (string[] args)
		{					
			Initialize();
			//Game loop.
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
			theGame = new TheGame();
			//Set up director and UISystem.
			Director.Initialize ();
			UISystem.Initialize(Director.Instance.GL.Context);
			
			theGame.LoadLevel();
		}
		
		public static void Update()
		{
			theGame.Update();
		}
	}
}