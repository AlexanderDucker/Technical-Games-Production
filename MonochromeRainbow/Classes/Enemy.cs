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
		private SpriteUV		enemy;
		private TextureInfo[]	textures; 
		private TextureInfo		enemyTextureInfo;
		private Vector2			centerPosition;
		private float			radius;
		private float			health;
		private bool			hasSwapped, isAlive;
		
		//Accessors.
		public Vector2 CenterPosition{ get{return centerPosition;}}
		public float Radius { get{return radius;} }
		public float Health { get{return health;} set{health = value;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public SpriteUV EnemySprite{get {return enemy;} }
		
		public Enemy (Scene gameScene, Vector2 enemyPos)
		{
			textures = new TextureInfo[2];
			textures[0] = new TextureInfo("/Application/Textures/Character_three.png");
			textures[1] = new TextureInfo("/Application/Textures/Character_three_dead.png");
			
			enemyTextureInfo = new TextureInfo();
			enemyTextureInfo = textures[0];
			
			enemy = new SpriteUV(enemyTextureInfo);
			enemy.Quad.S = enemyTextureInfo.TextureSizef;
			enemy.Position = enemyPos;
			
			health = 1.0f;
			hasSwapped = false;
			isAlive = true;
			
			radius = enemy.Quad.Point10.X/2;
			centerPosition = enemy.Position + enemy.Quad.Center;
			
			gameScene.AddChild(enemy);
		}
		
		public void Dispose()
		{
			foreach(TextureInfo t in textures)
			{
				t.Dispose();
			}
		}
		
		public void Update()
		{
			centerPosition = enemy.Position + enemy.Quad.Center;
			radius = enemy.Quad.Point10.X/2;
			
			if(health <= 0.0f && !hasSwapped)
			{
				enemy.Position = enemy.Position - enemy.Quad.Center;
				enemyTextureInfo = textures[1];
				enemy.TextureInfo = enemyTextureInfo;
				enemy.Quad.S = enemyTextureInfo.TextureSizef;
				radius = enemy.Quad.Point10.X / 2;
				hasSwapped = true;
				isAlive = false;
			}
		}
	}
}

