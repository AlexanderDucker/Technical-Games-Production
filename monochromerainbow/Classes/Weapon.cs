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
		private int damage;
		public Vector2 weaponRec, facingDirection;
		public bool hasCollided;
		Scene scene = Director.Instance.CurrentScene; 
		 
		
		public Weapon (Scene scene, int damages, float shotSpeeds, int texture, Vector2 position, Vector2 facingDirection)
		{
			this.damage = damages;
			this.shotSpeed = shotSpeeds;

			hasCollided = false;
			if (texture == 1)
			{
				weaponOne = new TextureInfo("/Application/textures/bullet.png");
			}
			else
			{
				weaponOne = new TextureInfo("/Application/textures/bullet2.png");
			}	
			weapon = new SpriteUV(weaponOne);
			weaponRec = new Vector2(16, 16);
			weapon.Quad.S = weaponRec;
			weapon.Position = position;
			this.facingDirection = facingDirection;
			scene.AddChild (weapon);
		}
		
		public void Update()
		{
			weapon.Position += facingDirection * shotSpeed;
		}
				
	}
}

