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
		private Monster[] 			enemies;
		
		public TheGame(){}
		
		public void LoadLevel()
		{
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			gameScene.Camera.SetViewFromViewport();
			
			player = new Player(gameScene, new Vector2(100,100));
			
			enemies = new Monster[ENEMY_COUNT];
			enemies[0] = new Monster(gameScene, new Vector2(400,400));
			enemies[1] = new Monster(gameScene, new Vector2(500,300));
			
			UISystem.SetScene(uiScene);
			//Run the scene.
			Director.Instance.RunWithScene(gameScene, true);
		}
		
		public void Update()
		{
			//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			
			player.Update();
			
			foreach(Monster m in enemies)
			{
				m.Update();
				if(m.Health <= 0.0f)
				{
					CheckDistance(m);
				}
			}
			//Suicide. Key press d.
		    if (((gamePadData.Buttons & GamePadButtons.Circle) != 0))
			{
				enemies[0].Health = 0.0f;
				Console.WriteLine("button clicked");
		    }	
		}
				
		public void CheckDistance(Monster m)
		{
			Vector2 dir = (m.CenterPosition) - (player.CenterPosition);
			float distanceSqrd = Square(dir.X) + Square(dir.Y);
			
			Console.WriteLine(distanceSqrd);
			
			if(distanceSqrd <= Square(m.Radius) + Square(player.Radius))
			{
				Console.WriteLine("collision");
				//swap sprites. press s.
				if (((gamePadData.Buttons & GamePadButtons.Square) != 0))
				{
					TextureInfo temp = player.PlayerSprite.TextureInfo;
					player.PlayerSprite.TextureInfo = m.MonsterSprite.TextureInfo;
					player.PlayerSprite.Quad.S = player.PlayerSprite.TextureInfo.TextureSizef;
					m.MonsterSprite.TextureInfo = temp;
					m.MonsterSprite.Quad.S = m.MonsterSprite.TextureInfo.TextureSizef;
		    	}	
			}
		}
		
		private float Square(float a)
		{
			return a*a;
		}
	}
}

