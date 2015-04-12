using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class TextureLoading
	{
		private TextureInfo 	playerTex;
		private TextureInfo 	deadPlayerTex;
		private TextureInfo[] 	walkPlayerTex;
		private TextureInfo[] 	enemyChaserTex;
		private TextureInfo 	deadEnemyTex;
		private TextureInfo[] 	enemyTankTex;
		private TextureInfo[]   enemyEvasiveTex;
		public int enemyTexSizeHW = 48;
		//private TextureInfo 	weaponTex;
		
		public TextureInfo   PlayerTex{ get{return playerTex;} }
		public TextureInfo   DeadPlayerTex{ get{return deadPlayerTex;} }
		public TextureInfo[] WalkPlayerTex{ get{return walkPlayerTex;} }
		public TextureInfo   EnemyChaserTex{ get{return enemyChaserTex[0];} }
		public TextureInfo   DeadEnemyTex{ get{return deadEnemyTex;} }
		public TextureInfo   EnemyTankTex{ get{return enemyTankTex[0];} }
		public TextureInfo	 EnemyEvasiveTex { get{return enemyEvasiveTex[0];}}
		//public TextureInfo   WeaponTex{ get{return weaponTex;} }
		
		public TextureLoading ()
		{
			playerTex = new TextureInfo("Application/textures/Character_one.png");
			deadPlayerTex = new TextureInfo("Application/textures/Character_one_dead.png");
			walkPlayerTex = new TextureInfo[2];
			walkPlayerTex[0] = new TextureInfo("Application/textures/Character_one_walk_one.png");
			walkPlayerTex[1] = new TextureInfo("Application/textures/Character_one_walk_two.png");
			
			
			deadEnemyTex = new TextureInfo("Application/Textures/Character_three_dead.png");
			LoadEnemyTextures ();
			
			//weaponTex = new TextureInfo("Application/textures/player/blue.png");
		}
		
		public void LoadEnemyTextures()
		{
			
			enemyChaserTex = new TextureInfo[8];
			enemyTankTex = new TextureInfo[8];
			enemyEvasiveTex = new TextureInfo[8];
			enemyChaserTex[0] = new TextureInfo(new Texture2D("Application/Textures/EnemyChaserWalking.png", false), new Vector2i(1,8), TRS.Quad0_1);
			enemyTankTex[0]= new TextureInfo("Application/Textures/EnemyTankWalking.png");
			enemyEvasiveTex[0] = new TextureInfo("Application/Textures/EnemyEvasiveWalking.png");
		}
		
		
		
	}
}

