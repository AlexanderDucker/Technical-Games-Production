using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace MonochromeRainbow
{
	public class Weapon
	{
		public SpriteUV	weapon;
		private TextureInfo	weaponOne;
		public float shotSpeed;
		public Vector2 bulletPosition;
		public Bounds2		bounds;
		private bool north, south, east, west;
		private int damage;
		public Vector2 weaponRec;
		 
		
		public Weapon (Scene scene, int damages, float shotSpeeds, int texture)
		{
			this.damage = damages;
			this.shotSpeed = shotSpeeds;

				weaponOne = new TextureInfo("/Application/textures/bullet.png");
				weapon = new SpriteUV(weaponOne);
				weaponRec = new Vector2(32, 16);
				weapon.Quad.S = weaponRec;
				weapon.Position = new Vector2(0,0);
			scene.AddChild (weapon);
			
		}
		
		public void Update()
		{
			if(north)
				bulletPosition.Y += shotSpeed;	
			if(south)
				bulletPosition.Y -= shotSpeed;
			if(east)
				bulletPosition.X += shotSpeed;
			if(west)
				bulletPosition.X -= shotSpeed;
		}
		
		
	}
}

