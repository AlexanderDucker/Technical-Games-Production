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
	public class Player
	{
		private SpriteUV		player;
		public Bounds2			bounds;
		private TextureInfo		playerTextureInfo;
		private TextureInfo[]	textures;
		public Vector2			movingDirection, facingDirection, centerPosition;
		private bool 			isAlive;
		public float			speed, radius, shootSpeed, fireRate;
		public int				bulletTex, health;
		
		public InputManager 	inputManager;
		public Vector2 CenterPosition{ get{return centerPosition;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public int Health{ get{return health;} set{health = value;} }
		public float Radius { get{return radius;} }
		public SpriteUV PlayerSprite{get {return player;} }
		public List<Weapon> weaponList = new List<Weapon>();
		Stopwatch s = new Stopwatch();

		public Player (Scene scene, Vector2 playerPos)
		{
			inputManager = new InputManager();
			textures = new TextureInfo[2];
			textures[0] = new TextureInfo("/Application/Textures/Character_one.png");
			textures[1] = new TextureInfo("/Application/Textures/Character_one_dead.png");
			
			playerTextureInfo = new TextureInfo();
			playerTextureInfo = textures[0];
			
			player = new SpriteUV(playerTextureInfo);	
			player.Quad.S = playerTextureInfo.TextureSizef;
			
			player.Position = playerPos;
			centerPosition = player.Position + player.Quad.Center;
			radius = player.Quad.Point10.X/2;
			
			speed = 2.0f;
			health = 100;
			isAlive = true;
			fireRate = 200;
			shootSpeed = 10.0f;
			bulletTex = 1;
			
			facingDirection = new Vector2(1.0f,0.0f);
			
			s.Start();
			
			scene.AddChild(player);
		}
		
		public void Dispose()
		{
			playerTextureInfo.Dispose();
		}
		
		public Vector2 getPlayerPos()
		{
			return player.Position;
		}
		
		public void Update(Scene scene)
		{
        	inputManager.CheckInput ();
			centerPosition = player.Position + player.Quad.Center;
			
			if(isAlive)
			{
				//Movement
				movingDirection = inputManager.GetTransform ();
				facingDirection = inputManager.GetFacingDirection();
				if (!(movingDirection.IsZero()))
				{
					Vector2 newDir = movingDirection.Normalize();
					player.Position = new Vector2(player.Position.X + (newDir.X * speed),player.Position.Y + (newDir.Y * speed));
				}
				//Movement^
				
				
				wallCollision();
				
				
				
				if(inputManager.GetCanFire())
				{
					if(s.ElapsedMilliseconds > 500)
					{
						Weapon weaponOne = new Weapon(scene, 10, 10.0f, 1, centerPosition, facingDirection);
						weaponList.Add(weaponOne);
						Console.WriteLine(weaponList.Count);
						s.Reset();
						s.Start();
					}
				}
				
				if(weaponList.Count > 0)
				{
					foreach(Weapon w in weaponList)
					{
						w.Update();
					}
				}
			}
		}
		
		void wallCollision()
		{
			//Check if player has hit the wall.
			if (player.Position.X > Director.Instance.GL.Context.GetViewport().Width - player.Quad.S.X)
			{
				player.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width - player.Quad.S.X,player.Position.Y);
			}
			if (player.Position.Y > Director.Instance.GL.Context.GetViewport().Height - player.Quad.S.Y)
			{
				player.Position = new Vector2(player.Position.X,Director.Instance.GL.Context.GetViewport().Height - (player.Quad.S.X/2));
			}
			if (player.Position.X < 0.0f)
			{					
				player.Position = new Vector2(0.0f, player.Position.Y);
			}
			if (player.Position.Y < 0.0f)
			{					
				player.Position = new Vector2(player.Position.X, 0.0f);
			}
		}
	}
}

