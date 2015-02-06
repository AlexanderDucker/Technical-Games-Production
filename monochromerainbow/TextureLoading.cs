using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class TextureLoading
	{
		public TextureInfo playerTex;
		public TextureInfo enemyTex;
		public TextureInfo weaponTex;
		public SpriteUV playerUV;
		public SpriteUV enemyUV;
		public SpriteUV weaponUV;
		
		public TextureLoading ()
		{
			PlayerTexLoad();
			EnemyTexLoad();
			WeaponTexLoad();
		}
		
		public void PlayerTexLoad()
		{
			playerTex = new TextureInfo("Application/textures/player/blue.png");
			
		}
		public TextureInfo getPlayerTex()
		{
			return playerTex;
		}
		
		public void EnemyTexLoad()
		{
			enemyTex = new TextureInfo("Application/textures/player/blue.png");
			
		}
		public TextureInfo getEnemyTex()
		{
			return enemyTex;	
		}
		
		public void WeaponTexLoad()
		{
			weaponTex = new TextureInfo("Application/textures/player/blue.png");
			
		}
		public TextureInfo getWeaponTex()
		{
			return weaponTex;	
		}
	}
}

