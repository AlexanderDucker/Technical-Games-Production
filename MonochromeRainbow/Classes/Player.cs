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
		private GamePadData		gamePadData;
		private SpriteUV		player;
		public Bounds2			bounds;
		private TextureInfo		playerTextureInfo;
		public TextureInfo[]	textures;
		public Vector2			movingDirection, facingDirection, centerPosition;
		public bool 			isAlive, abilityStarted, hasSwapped, canSwap;
		public float			speed, radius, shootSpeed, fireRate;
		public int				bulletTex, health;
		public int				tempTexCounter;
		public Vector2 			pos;
		public TextureLoading spriteTextures;
		public InputManager 	inputManager;
		public Vector2 CenterPosition{ get{return centerPosition;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public int Health{ get{return health;} set{health = value;} }
		public float Radius { get{return radius;} }
		public SpriteUV PlayerSprite{get {return player;} }
		public List<Weapon> weaponList = new List<Weapon>();
		Stopwatch s = new Stopwatch();
		Stopwatch abilityTimer = new Stopwatch();

		public Player (Scene scene, Vector2 playerPos, TextureLoading textureManager)
		{
			pos = playerPos;
			inputManager = new InputManager();
			spriteTextures = textureManager;
			
			textures = new TextureInfo[4];
			textures[0] = textureManager.PlayerTex[tempTexCounter];
			
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
			bulletTex = 2;
			
			facingDirection = new Vector2(1.0f,0.0f);
			
			s.Start();
			abilityStarted = false;
			
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
			tempTexCounter = inputManager.GetTexture();
			if(isAlive)
			{
				//Movement
				gamePadData = GamePad.GetData(0);
				movingDirection = inputManager.GetTransform ();
				facingDirection = inputManager.GetFacingDirection();
				if (!(movingDirection.IsZero()))
				{
					Vector2 newDir = movingDirection.Normalize();
					player.Position = new Vector2(player.Position.X + (newDir.X * speed),player.Position.Y + (newDir.Y * speed));
				}
				//Movement^
				if((gamePadData.Buttons & GamePadButtons.Select) != 0)
				{
					if(!abilityStarted)
					{
						abilityStarted = true;
						abilityTimer.Start();
						if(facingDirection.Y == 1.0f)
							player.Position = new Vector2(player.Position.X,player.Position.Y + 1000.0f);
						else if(facingDirection.Y == -1.0f)
							player.Position = new Vector2(player.Position.X,player.Position.Y - 100.0f);
						else if(facingDirection.X == 1.0f)
							player.Position = new Vector2(player.Position.X + 100.0f,player.Position.Y);
						else if(facingDirection.X == -1.0f)
							player.Position = new Vector2(player.Position.X + -100.0f,player.Position.Y);
					}
					if(abilityTimer.ElapsedMilliseconds > 3000)
					{
						abilityStarted = false;
						abilityTimer.Reset();
					}
				}	
				
				wallCollision();

				if(inputManager.GetCanFire())
				{
					if(s.ElapsedMilliseconds > 250)
					{
						Weapon weaponOne = new Weapon(scene, 10, 10.0f, bulletTex, centerPosition, facingDirection);
						weaponList.Add(weaponOne);
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
				player.TextureInfo = spriteTextures.PlayerTex[tempTexCounter];
				pos = player.Position;
			}
		}
		
		void wallCollision()
		{
			
			//Check if player has hit the wall.
			
			if (player.Position.X > Director.Instance.GL.Context.GetViewport().Width - player.Quad.X.X -50)
			{
				pos.X = (Director.Instance.GL.Context.GetViewport().Width - PlayerSprite.TextureInfo.TextureSizei.X - 50) ;
				player.Position= pos;
			}
			if (player.Position.Y > Director.Instance.GL.Context.GetViewport().Height - player.Quad.Y.Y - 50)
			{
				pos.Y = (Director.Instance.GL.Context.GetViewport().Height - PlayerSprite.TextureInfo.TextureSizei.Y - 50);
				player.Position=pos;
			}
			if (player.Position.X < 50.0f)
			{					
				pos.X = 50.0f;
				player.Position = pos;
			}
			if (player.Position.Y < 50.0f)
			{					
				pos.Y = 50.0f;
				player.Position = pos;
			}
		}
	}
}

