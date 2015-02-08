using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Monster
	{
		private SpriteUV		enemy;
		private TextureInfo[]	textures; 
		private TextureInfo		enemyTextureInfo;
		private Vector2			centerPosition;
		private float			radius;
		private float			health;
		private bool			isSomething;
		
		//Accessors.
		public Vector2 CenterPosition{ get{return centerPosition;}}
		public float Radius { get{return radius;} }
		public float Health { get{return health;} set{health = value;} }
		public SpriteUV MonsterSprite{get {return enemy;} }
		
		public Monster (Scene gameScene, Vector2 enemyPos)
		{
			textures = new TextureInfo[2];
			textures[0] = new TextureInfo("/Application/textures/enemy/green.png");
			textures[1] = new TextureInfo("/Application/textures/enemy/enemyRing.png");
			
			enemyTextureInfo = new TextureInfo();
			enemyTextureInfo = textures[0];
			
			enemy = new SpriteUV(enemyTextureInfo);
			enemy.Quad.S = enemyTextureInfo.TextureSizef;
			enemy.Position = enemyPos;
			
			health = 1.0f;
			isSomething = false;
			
			radius = enemy.Quad.Point10.X / 2;
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
			
			if(health <= 0.0f && !isSomething)
			{
				enemyTextureInfo = textures[1];
				enemy.TextureInfo = enemyTextureInfo;
				enemy.Quad.S = enemyTextureInfo.TextureSizef;
				radius = enemy.Quad.Point10.X / 2;
				isSomething = true;
			}
		}
	}
}

