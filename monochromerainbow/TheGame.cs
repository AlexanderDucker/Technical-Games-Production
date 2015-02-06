using System;
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
		private static GamePadData		gamePadData;
		private Character player;
		private Character enemy;
		private TextureLoading textures;
		//private Texture2D enemyTex; //for memory reasons, don't want to have to lead it every time.
		
		public TheGame()
		{
			
		}
		
		public void LoadLevel()
		{
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			textures = new TextureLoading();
			textures.PlayerTexLoad();
			textures.EnemyTexLoad();
			textures.WeaponTexLoad();
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			gameScene.Camera.SetViewFromViewport();
			
			player = new Character(gameScene, new Vector2(100,100), true, textures.getPlayerTex());
			enemy = new Character(gameScene, new Vector2(500,300), false, textures.getEnemyTex());
			
			UISystem.SetScene(uiScene);
			//Run the scene.
			Director.Instance.RunWithScene(gameScene, true);
		}
		
		public void GenerateEnemies() //better to keep this stuff seperate for now.
		{
			
		}
		
		public void Update()
		{
			//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			
			player.Update ();
			enemy.Update();
			
			//Suicide.
	    	if ((gamePadData.Buttons & GamePadButtons.Circle) != 0)
			{
				System.Console.WriteLine("Dead");
				enemy.Health = 0.0f;
	    	}
		}
	}
}

