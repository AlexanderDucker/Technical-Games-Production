using System;
using System.Diagnostics;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class EnemyBase
	{
		protected Vector2		facingDirection, centerPosition, playerPosition;
		protected float		speed, health, radius, shootSpeed, fireRate;
		protected bool			hasSwapped, isAlive;
		protected Vector2 		position;
		protected int			bulletTex;
		protected bool			runAway;
		

		//Accessors.
		public Vector2 CenterPosition{ get{return centerPosition;}}
		public float Radius { get{return radius;} }
		public float Health { get{return health;} set{health = value;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		
		
		
		public  EnemyBase ()
		{
			health = 1.0f;
			hasSwapped = false;
			isAlive = true;
			
			facingDirection = new Vector2(0,0);
			facingDirection = facingDirection.Normalize();		
			speed = 0;
		    fireRate =0;
			shootSpeed = 0;
			bulletTex = 1;
			runAway = false;
			
		}
		
		public virtual void Update(Vector2 playerpos)
		{
			
		}
		public virtual void SetTexture(TextureInfo texture, Vector2 pos)
		{
		}
		
		public virtual void TestMethod2()
		{
			
		}
		
		public virtual void Shoot(Vector2 playerPos, Scene scene, bool playerMoving, List<Weapon> weaponList)
		{
			
		}
		public virtual void Dispose()
		{
			
		}
		
		public virtual void RunAI(Vector2 playerPos)
		{
			
		}
		
		
		public virtual float Square(float a){return a*a;}
	}
}

