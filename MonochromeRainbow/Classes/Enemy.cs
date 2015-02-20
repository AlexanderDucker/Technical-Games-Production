using System;
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
		private Vector2			centerPosition;
		private float			radius;
		private float			health;
		private bool			hasSwapped, isAlive;
		private Vector2 		position;
		//Accessors.
		public Vector2 CenterPosition{ get{return centerPosition;}}
		public float Radius { get{return radius;} }
		public float Health { get{return health;} set{health = value;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public SpriteUV EnemySprite{get {return enemy;} }
		
		public Enemy ()
		{
			health = 1.0f;
			hasSwapped = false;
			isAlive = true;
			radius = enemy.Quad.Point10.X/2;
			centerPosition = enemy.Position + enemy.Quad.Center;
		}
		
		public void SetTexture(TextureInfo texture)
		{
			eTexture = texture;
			enemy = new SpriteUV(texture);
			enemy.Quad.S = texture.TextureSizef;
		}
		
		public void Dispose()
		{
			eTexture.Dispose ();
		}
		
		public void Update()
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

