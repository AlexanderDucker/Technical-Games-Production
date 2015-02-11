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
		private const int ENEMY_COUNT = 2;
		
		private static Sce.PlayStation.HighLevel.GameEngine2D.Scene 	gameScene;
		private static Sce.PlayStation.HighLevel.UI.Scene 				uiScene;
		private static GamePadData		gamePadData;
		private Player				player;
		private Enemy[] 			enemies;
		private bool 				hasSwapped;
		
		public TheGame(){ hasSwapped = false; }
		
		public void LoadLevel()
		{
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			gameScene.Camera.SetViewFromViewport();
			
			player = new Player(gameScene, new Vector2(100,100));
			
			enemies = new Enemy[ENEMY_COUNT];
			enemies[0] = new Enemy(gameScene, new Vector2(400,400));
			enemies[1] = new Enemy(gameScene, new Vector2(500,300));
			
			UISystem.SetScene(uiScene);
			//Run the scene.
			Director.Instance.RunWithScene(gameScene, true);
		}
		
		public void Update()
		{
			//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			
			player.Update();
			
			foreach(Enemy e in enemies)
			{
				e.Update();
				if(e.Health <= 0.0f)
				{
					CheckDistance(e);
				}
			}
			//Suicide. Key press d.
		    if (((gamePadData.Buttons & GamePadButtons.Circle) != 0))
			{
				enemies[0].Health = 0.0f;
				Console.WriteLine("button clicked");
		    }	
		}
				
		public void CheckDistance(Enemy e)
		{
			Vector2 dir = (player.CenterPosition) - (e.CenterPosition);
			float distanceSqrd = Square(dir.X) + Square(dir.Y);
			
			Console.WriteLine(distanceSqrd);
			
			if(distanceSqrd <= Square(e.Radius) + Square(player.Radius))
			{
				Console.WriteLine("collision");
				//Swap sprites & positions. press a.
				if (((gamePadData.Buttons & GamePadButtons.Square) != 0))
				{
					hasSwapped = true;
				}
				if (((gamePadData.Buttons & GamePadButtons.Square) == 0))
				{
					hasSwapped = false;
				}
			}
			
			if(hasSwapped)
			{
				TextureInfo temp = player.PlayerSprite.TextureInfo;
				player.PlayerSprite.TextureInfo = e.EnemySprite.TextureInfo;
				player.PlayerSprite.Quad.S = player.PlayerSprite.TextureInfo.TextureSizef;
				e.EnemySprite.TextureInfo = temp;
				e.EnemySprite.Quad.S = e.EnemySprite.TextureInfo.TextureSizef;
				Vector2 tempPos = e.EnemySprite.Position;
				e.EnemySprite.Position = player.PlayerSprite.Position;
				player.PlayerSprite.Position = tempPos;
				hasSwapped = false;
			}
		}
		
		private float Square(float a)
		{
			return a*a;
		}
	}
}

