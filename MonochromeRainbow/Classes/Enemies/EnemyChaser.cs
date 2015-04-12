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
		public EnemyChaser() : base()
		{			
			runAway = false;
		}	
		
		public override void SetTexture(TextureInfo texture, Vector2 pos, Scene scene)
		{
			eTexture = texture;
			enemy = new SpriteUV(eTexture);
			enemy.Quad.S = new Vector2(48,48);
			position = pos;
			bulletTex = 1;
			enemy.Position = pos;
			scene.AddChild(enemy);
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
			
				
			}
		}
	}
}

