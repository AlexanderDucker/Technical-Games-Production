using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class TextureLoading
	{

		private TextureInfo[] 	playerTex;
		private TextureInfo 	deadPlayerTex;
		private TextureInfo[] 	walkPlayerTex;
		private TextureInfo 	enemyTex;
		private TextureInfo 	deadEnemyTex;
		//private TextureInfo 	weaponTex;
		

	
		public TextureInfo[] 	 PlayerTex			{ get{return playerTex;} }
		public TextureInfo   DeadPlayerTex		{ get{return deadPlayerTex;} }
		public TextureInfo[] WalkPlayerTex		{ get{return walkPlayerTex;} }
		public TextureInfo   EnemyTex	  		{ get{return enemyTex;} }
		public TextureInfo   DeadEnemyTex 		{ get{return deadEnemyTex;} }
		//public TextureInfo   WeaponTex{ get{return weaponTex;} }
		
		//public TextureLoading textures;
		//textures = textureManager;
		//enemy.SetTexture (textures.EnemyTex, spawnpoints[spawnpt], scene);
		
		public TextureLoading ()
		{
			playerTex = new TextureInfo[4];
			playerTex[0] = new TextureInfo("Application/textures/Necromancer_Four.png");
			playerTex[1] = new TextureInfo("Application/textures/Necromancer_Two.png");
			playerTex[2] = new TextureInfo("Application/textures/Necromancer_Three.png");
			playerTex[3] = new TextureInfo("Application/textures/Necromancer_one.png");
			deadPlayerTex = new TextureInfo("Application/textures/Character_one_dead.png");
			walkPlayerTex = new TextureInfo[2];
			walkPlayerTex[0] = new TextureInfo("Application/textures/Character_one_walk_one.png");
			walkPlayerTex[1] = new TextureInfo("Application/textures/Character_one_walk_two.png");
			enemyTex = new TextureInfo("Application/Textures/Character_three.png");
			deadEnemyTex = new TextureInfo("Application/Textures/Character_three_dead.png");
			//weaponTex = new TextureInfo("Application/textures/player/blue.png");
		}
		
		
		
	}
}

