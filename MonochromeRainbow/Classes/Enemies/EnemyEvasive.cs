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
	public class EnemyEvasive
	{
		public SpriteUV			enemy;
		public TextureInfo		eTexture; 
		private Vector2			facingDirection, centerPosition;
		public float			speed, health, radius, shootSpeed, fireRate;
		private bool			hasSwapped, isAlive;
		private Vector2 		position;
		public int				bulletTex;
		//private bool			runAway;

		//Accessors.
		public Vector2 CenterPosition{ get{return centerPosition;}}
		public float Radius { get{return radius;} }
		public float Health { get{return health;} set{health = value;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public SpriteUV EnemySprite{get {return enemy;} }
		Stopwatch s = new Stopwatch();
		
		public EnemyEvasive ()
		{
			
		}
		
		public void InitData(Vector2 playerPos, float speed, int fireRate, float bulletSpeed)
		{
			health = 1.0f;
			hasSwapped = false;
			isAlive = true;
			radius = enemy.Quad.Point10.X/2;
			centerPosition = enemy.Position + enemy.Quad.Center;
			position = enemy.Position;
			facingDirection = playerPos - enemy.Position;
			facingDirection = facingDirection.Normalize();		
			this.speed = speed;
			health = 2.0f;
			isAlive = true;
			this.fireRate = fireRate;
			shootSpeed = bulletSpeed;
			bulletTex = 0;
			//runAway = false;
			s.Start();
		}
		
		public void SetTexture(TextureInfo texture, Vector2 pos)
		{
			eTexture = texture;
			enemy = new SpriteUV(eTexture);
			enemy.Quad.S = texture.TextureSizef;
			enemy.Position = pos;
		}
		
		public void Dispose()
		{
			eTexture.Dispose ();
		}
		
		public void Update(Vector2 playerpos)
		{
			centerPosition = enemy.Position + enemy.Quad.Center;
			radius = enemy.Quad.Point10.X/2;
				
			if(health <= 0.0f && !hasSwapped)
			{
				enemy.Position = enemy.Position - enemy.Quad.Center;
				radius = enemy.Quad.Point10.X / 2;
				hasSwapped = true;
				isAlive = false;
			}
		
			enemy.Position = position;
		}
		
	
	}
}

