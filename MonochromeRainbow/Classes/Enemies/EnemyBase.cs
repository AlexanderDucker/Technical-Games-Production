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
		public SpriteUV		enemy;
		public Bounds2      bounds;
		protected TextureInfo	eTexture; 
				protected TextureInfo[] eTextures;
		protected Vector2		facingDirection, centerPosition, playerPosition;
		public float			speed, health, radius, shootSpeed, fireRate;
		protected bool			hasSwapped, isAlive;
		protected Vector2 		position;
		public int			bulletTex;
		protected bool			runAway;
		protected Stopwatch s = new Stopwatch();
		

		//Accessors.
		public Vector2 CenterPosition{ get{return centerPosition;}}
		public float Radius { get{return radius;} }
		public float Health { get{return health;} set{health = value;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		
		public  EnemyBase ()
		{
			health = 100.0f;
			hasSwapped = false;
			isAlive = true;
			
			facingDirection = new Vector2(0,0);
			facingDirection = facingDirection.Normalize();		
			bulletTex = 1;
			runAway = false;
			
		}
		
		public virtual void InitData(Vector2 playerPos, float speed, float fireRate, float bulletSpeed)
		{
			radius = enemy.Quad.Point10.X/2;
			centerPosition = enemy.Position + enemy.Quad.Center;
			position = enemy.Position;
			facingDirection = playerPos - enemy.Position;
			facingDirection = facingDirection.Normalize();		
			this.speed = speed;		
			this.fireRate = fireRate;
			shootSpeed = bulletSpeed;
			s.Start();
		}
		
		public virtual void Update(Vector2 playerpos)
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
		
		public virtual void SetTexture(TextureInfo texture, Vector2 pos, Scene scene)
		{
			
			eTexture = texture;
			enemy = new SpriteUV(eTexture);
			enemy.Quad.S = new Vector2(48,48);
			enemy.Position = pos;
			scene.AddChild(enemy);
		}
		
				public virtual void ChangeTexture(TextureInfo aliveTex, TextureInfo deadTex, Vector2 pos)
		{
			eTextures = new TextureInfo[2];
			eTextures[0] = aliveTex;
			eTextures[1] = deadTex;
			eTexture = eTextures[0];
			enemy = new SpriteUV(eTexture);
			enemy.Quad.S = eTexture.TextureSizef;
			enemy.Position = pos;
		}
		
		public virtual TextureInfo GetTexture(int tex)
		{
			return eTextures[tex];
		}
		
		public virtual void Shoot(Vector2 playerPos, Scene scene, bool playerMoving, List<Weapon> weaponList)
		{
			if (!runAway)
			{
				Vector2 dir = playerPos - centerPosition;
				float distanceSqrd = Square(dir.X) + Square(dir.Y);
				double distance = System.Math.Sqrt(distanceSqrd);
				
				if(s.ElapsedMilliseconds > fireRate)
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
		
		public virtual void Dispose()
		{
			eTexture.Dispose ();
		}
		
		public virtual void RunAI(Vector2 playerPos, List<Vector2> enemyPositions)
		{
		
		}
		
		public static float Square(float a){return a*a;}
	}
}

