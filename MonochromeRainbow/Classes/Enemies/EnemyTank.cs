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
	public class EnemyTank : EnemyBase
	{
		public EnemyTank (): base()
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
				runAway = true;
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
				
			
				
			}
			
			
			if (enemy.Position.X > Director.Instance.GL.Context.GetViewport().Width - enemy.Quad.X.X -50)
			{
				position.X = (Director.Instance.GL.Context.GetViewport().Width - enemy.TextureInfo.TextureSizei.X - 50) ;
				enemy.Position= position;
			}
			if (enemy.Position.Y > Director.Instance.GL.Context.GetViewport().Height - enemy.Quad.Y.Y - 50)
			{
				position.Y = (Director.Instance.GL.Context.GetViewport().Height - enemy.TextureInfo.TextureSizei.Y - 50);
				enemy.Position=position;
			}
			if (enemy.Position.X < 50.0f)
			{					
				position.X = 50.0f;
				enemy.Position = position;
			}
			if (enemy.Position.Y < 50.0f)
			{					
				position.Y = 50.0f;
				enemy.Position = position;
			}
			
			
			
		}
	}
}

