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
	}
}

