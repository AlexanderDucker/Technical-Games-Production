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
	public class EnemyChaser : EnemyBase
	{
	
		//Accessors.
		public SpriteUV			enemy;
		public TextureInfo		eTexture;
		public Stopwatch s = new Stopwatch();
		public EnemyChaser() :base()
		{
			
			runAway = false;
			s.Start();
		}
		
		
		public override void SetTexture(TextureInfo texture, Vector2 pos)
		{
			eTexture = texture;
			enemy = new SpriteUV(eTexture);
			enemy.Quad.S = texture.TextureSizef;
			position = pos;
			bulletTex = 1;
			enemy.Position = pos;
		}
		
			public override void Dispose()
		{
			eTexture.Dispose ();
		}
		
		
		public override void Update(Vector2 playerpos)
		{
			playerPosition = playerpos;
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
		
		
	
		public override void Shoot(Vector2 playerPos, Scene scene, bool playerMoving, List<Weapon> weaponList)
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
		
		public override void RunAI(Vector2 playerPos)
		{
			if(playerPos.X > enemy.Position.X)
				position.X += 1.0f;
			if(playerPos.Y > enemy.Position.Y)
				position.Y += 1.0f;
			if(playerPos.X < enemy.Position.X)
				position -= 1.0f;
			if(playerPos.Y < enemy.Position.Y)
				position.Y -= 1.0f;
		}
		
		public override float Square(float a){return a*a;}
	}
}

