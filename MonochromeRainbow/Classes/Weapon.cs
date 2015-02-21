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
			weaponOne = new TextureInfo("/Application/textures/bullet.png");
			weapon = new SpriteUV(weaponOne);
			weaponRec = new Vector2(32, 16);
			weapon.Quad.S = weaponRec;
			weapon.Position = position;
			this.facingDirection = facingDirection;
			scene.AddChild (weapon);
		}
		
		public void Update()
		{
			weapon.Position += facingDirection * shotSpeed;
			CheckCollision();
		}
		
		public void CheckCollision()
		{	
			if(weapon.Position.X > Director.Instance.GL.Context.GetViewport().Width + weapon.Quad.S.X)
			{
				scene.RemoveChild(weapon, true);
			}
			
			if(weapon.Position.X < -10.0f)
			{
				scene.RemoveChild(weapon, true);
			}
			
			if(weapon.Position.Y < -10.0f)
			{
				scene.RemoveChild(weapon, true);
			}
			
			if(weapon.Position.Y > Director.Instance.GL.Context.GetViewport().Height + weapon.Quad.S.X)
			{
				scene.RemoveChild(weapon, true);
			}
		}		
	}
}

