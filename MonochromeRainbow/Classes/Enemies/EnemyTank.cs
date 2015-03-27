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
		
		public override void RunAI(Vector2 playerPos)
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
	}
}

