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
	public class Enemy
	{
		public SpriteUV			enemy;
		public TextureInfo		eTexture; 
		private Vector2			facingDirection, centerPosition;
		public float			speed, health, radius, shootSpeed, fireRate;
		private bool			hasSwapped, isAlive;
		private Vector2 		position;
		public int				bulletTex;
		private bool			runAway;
		public 	List<Weapon>    weaponList = new List<Weapon>();

		//Accessors.
		public Vector2 CenterPosition{ get{return centerPosition;}}
		public float Radius { get{return radius;} }
		public float Health { get{return health;} set{health = value;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public SpriteUV EnemySprite{get {return enemy;} }
		Stopwatch s = new Stopwatch();
		
		public Enemy ()
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
			runAway = false;
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
		
		public void RunAI(Vector2 playerPos)
		{
			facingDirection = playerPos - enemy.Position;
			facingDirection = facingDirection.Normalize();
			
			Vector2 dir = playerPos - centerPosition;
			float distanceSqrd = Square(dir.X) + Square(dir.Y);
			double distance = System.Math.Sqrt(distanceSqrd);
			
			if (distance >= 150.0f)
			{
				position += facingDirection * speed;
			}
			else if (distance < 100.0f)
			{
				position -= facingDirection * speed;
				runAway = true;
			}
			if (runAway)
			{
				if(distance >= 150.0f)
				{
					runAway = false;	
				}
			}
		}
		public void Shoot(Vector2 playerPos, Scene scene, bool playerMoving)
		{
			if (!runAway)
			{
				Vector2 dir = playerPos - centerPosition;
				float distanceSqrd = Square(dir.X) + Square(dir.Y);
				double distance = System.Math.Sqrt(distanceSqrd);
				
				if(s.ElapsedMilliseconds > 0)
				{
					int missFactor;
					Random rand = new Random(Guid.NewGuid().GetHashCode());
					if (playerMoving)
					{
						if (distance < 50.0f)
						{
							missFactor = rand.Next(-20,20);
						}
						else
						{
							missFactor = rand.Next(-50,50);
						}
					}
					else
					{
						if (distance < 50.0f)
						{
							missFactor = rand.Next(-50,50);
						}
						else
						{
							missFactor = rand.Next(-100,100);
						}
					}
					Vector2 newVec;
					newVec.X = -facingDirection.Y;
					newVec.Y = facingDirection.X;
					newVec *= missFactor;
					newVec = playerPos + (newVec - centerPosition);
					newVec = newVec.Normalize();
					Weapon weaponOne = new Weapon(scene, 10, shootSpeed, bulletTex, centerPosition, newVec);
					weaponList.Add(weaponOne);
					s.Reset();
					s.Start();
				}
			}
		}
		private float Square(float a){return a*a;}
	}
}

