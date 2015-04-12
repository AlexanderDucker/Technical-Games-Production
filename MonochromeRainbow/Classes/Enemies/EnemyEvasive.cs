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
	public class EnemyEvasive : EnemyBase
	{
		public EnemyEvasive() : base()
		{
		
		}
		
		public override void RunAI(Vector2 playerPos, List<Vector2> enemyPositions)
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
			
			}
			
			List<Vector2>enemyPosWithoutOwn = new List<Vector2>();
			for(int i = 0; i < enemyPositions.Count; i++)
			{
				if(enemyPositions[i] != position)
				{
					enemyPosWithoutOwn.Add (enemyPositions[i]);
				}
			}
			
			for(int i = 0; i < enemyPosWithoutOwn.Count; i++)
			{
				if(position.X - enemyPosWithoutOwn[i].X < 20 && position.Y - enemyPosWithoutOwn[i].Y <20)
				{
					position.X +=speed;
					position.Y +=speed;
				}
			
			if(position.X < 0)
			{
				position.X = 0;	
			}
			if(position.X > 960)
			{
				position.X = 960;	
			}
			if(position.Y < 0)
			{
				position.Y = 0;	
			}
			if(position.Y > 544)
			{
				position.Y = 544;	
			}
			
			if(position.X > playerPos.X)
			{
				if(position.X - playerPos.X <300.0f)
				{
					position.X +=speed;	
				}
			}
			else
			{
				if(position.X + playerPos.X >300f)
				{
					position.X -=speed;	
				}
			}
			
			if(position.Y < playerPos.X)
			{
				if(position.Y - playerPos.Y > 250f)
				{
					position.Y += speed;	
				}
			}
			else
			{
				if(position.Y - playerPos.Y < 250f)
				{
					position.Y -= speed;	
				}
			}
		
		}
		
		}
	}
}

