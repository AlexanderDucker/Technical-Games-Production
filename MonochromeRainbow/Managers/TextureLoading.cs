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
		//private TextureInfo[] 	walkPlayerTex;
		private TextureInfo[] 	enemyChaserTex;
		private TextureInfo 	deadEnemyTex;
		private TextureInfo[] 	enemyTankTex;
		private TextureInfo[]   enemyEvasiveTex;
		private TextureInfo[]   backgrounds;
		public int enemyTexSizeHW = 48;
		//private TextureInfo 	weaponTex;
		
		public TextureInfo[]   PlayerTex{ get{return playerTex;} }
		public TextureInfo   DeadPlayerTex{ get{return deadPlayerTex;} }
		//public TextureInfo[] WalkPlayerTex{ get{return walkPlayerTex;} }
		public TextureInfo[]   EnemyChaserTex{ get{return enemyChaserTex;} }
		public TextureInfo   DeadEnemyTex{ get{return deadEnemyTex;} }
		public TextureInfo[]   EnemyTankTex{ get{return enemyTankTex;} }
		public TextureInfo[]	 EnemyEvasiveTex { get{return enemyEvasiveTex;}}
		public TextureInfo[] MenuBGs {get{return backgrounds;}}
		//public TextureInfo   WeaponTex{ get{return weaponTex;} }
		
		public TextureLoading ()
		{
			playerTex = new TextureInfo[4];
			playerTex[0] = new TextureInfo("Application/textures/Necromancer_Three.png");
			playerTex[1] = new TextureInfo("Application/textures/Necromancer_Two.png");
			playerTex[2] = new TextureInfo("Application/textures/Necromancer_Four.png");
			playerTex[3] = new TextureInfo("Application/textures/Necromancer_One.png");
			deadPlayerTex = new TextureInfo("Application/textures/Character_One_dead.png");
			//walkPlayerTex = new TextureInfo[2];
			//walkPlayerTex[0] = new TextureInfo("Application/textures/Character_one_walk_one.png");
			//walkPlayerTex[1] = new TextureInfo("Application/textures/Character_one_walk_two.png");
			backgrounds = new TextureInfo [3];
			backgrounds[0] = new TextureInfo("Application/textures/TitleScreen.png"); 
			backgrounds[1] = new TextureInfo ("Application/textures/Instructions.png");
			
			deadEnemyTex = new TextureInfo("Application/Textures/Character_three_dead.png");
			LoadEnemyTextures ();
			
			//weaponTex = new TextureInfo("Application/textures/player/blue.png");
		}
		
		public void LoadEnemyTextures()
		{
			
			enemyChaserTex = new TextureInfo[4];
			enemyChaserTex[0] = new TextureInfo("Application/Textures/ChaserOne.png");
			enemyChaserTex[1] = new TextureInfo("Application/Textures/ChaserTwo.png");
			enemyChaserTex[2] = new TextureInfo("Application/Textures/ChaserThree.png");
			enemyChaserTex[3] = new TextureInfo("Application/Textures/ChaserFour.png");
			
			enemyTankTex = new TextureInfo[4];
			enemyTankTex[0]= new TextureInfo("Application/Textures/TankOne.png");
			enemyTankTex[1]= new TextureInfo("Application/Textures/TankTwo.png");
			enemyTankTex[2]= new TextureInfo("Application/Textures/TankThree.png");
			enemyTankTex[3]= new TextureInfo("Application/Textures/TankFour.png");
			
			enemyEvasiveTex = new TextureInfo[4];
			enemyEvasiveTex[0] = new TextureInfo("Application/Textures/EvasiveOne.png");
			enemyEvasiveTex[1] = new TextureInfo("Application/Textures/EvasiveTwo.png");
			enemyEvasiveTex[2] = new TextureInfo("Application/Textures/EvasiveThree.png");
			enemyEvasiveTex[3] = new TextureInfo("Application/Textures/EvasiveFour.png");
			
		}
		
		
		
	}
}

