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
		private TextureInfo		playerTextureInfo;
		private TextureInfo[]	textures;
		private GamePadData		gamePadData;
		public Vector2			movingDirection;
		public Vector2			facingDirection;
		public float			speed;
		public Vector2			centerPosition;
		private float			health;
		private bool 			isAlive;
		private float			radius;

		
		public Vector2 CenterPosition{ get{return centerPosition;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public float Health{ get{return health;} set{health = value;} }
		public float Radius { get{return radius;} }
		public SpriteUV PlayerSprite{get {return player;} }
		List<Weapon> weaponList = new List<Weapon>();
		Stopwatch s = new Stopwatch();


		
		public Player (Scene scene, Vector2 playerPos)
		{
			playerTextureInfo = new TextureInfo();
			textures = new TextureInfo[2];
			textures[0] = new TextureInfo("/Application/Textures/Character_one.png");
			textures[1] = new TextureInfo("/Application/Textures/Character_one_dead.png");
			playerTextureInfo = textures[0];
			player = new SpriteUV(playerTextureInfo);	
			player.Quad.S = playerTextureInfo.TextureSizef;
			player.Position = playerPos;
			centerPosition = player.Position + player.Quad.Center;
			radius = player.Quad.Point10.X/2;
			speed = 2.0f;
			health = 1.0f;
			isAlive = true;
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
        	//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			
			centerPosition = player.Position + player.Quad.Center;
			
			if(isAlive)
			{
				//Left movement
		    	if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
		    	{
					movingDirection.X = -1.0f;
					facingDirection.X = -1.0f;
					if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
		    		{
						facingDirection.Y = 1.0f;
					}
					else if ((gamePadData.Buttons & GamePadButtons.Down) != 0)
		    		{
						facingDirection.Y = -1.0f;
					}
		    		else
					{
						facingDirection.Y = 0.0f;
					}					
		    	}
				//Right movement
		    	else if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
		    	{
					movingDirection.X = 1.0f;
					facingDirection.X = 1.0f;
					if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
		    		{
						facingDirection.Y = 1.0f;
					}
					else if ((gamePadData.Buttons & GamePadButtons.Down) != 0)
		    		{
						facingDirection.Y = -1.0f;
					}
		    		else
					{
						facingDirection.Y = 0.0f;
					}
		    	}
				else
				{
					movingDirection.X = 0.0f;
				}
				//Up movement
		    	if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
		    	{
					movingDirection.Y = 1.0f;
					facingDirection.Y = 1.0f;
					if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
		    		{
						facingDirection.X = -1.0f;
					}
					else if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
		    		{
						facingDirection.X = 1.0f;
					}
		    		else
					{
						facingDirection.X = 0.0f;
					}
		    	}
				//Down movement
		    	else if ((gamePadData.Buttons & GamePadButtons.Down) != 0)
		    	{
					movingDirection.Y = -1.0f;
					facingDirection.Y = -1.0f;
					if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
		    		{
						facingDirection.X = -1.0f;
					}
					else if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
		    		{
						facingDirection.X = 1.0f;
					}
		    		else
					{
						facingDirection.X = 0.0f;
					}
		    	}
				else
				{
					movingDirection.Y = 0.0f;
				}
				if (!(movingDirection.IsZero()))
				{
					Vector2 newDir = movingDirection.Normalize();
					player.Position = new Vector2(player.Position.X + (newDir.X * speed),player.Position.Y + (newDir.Y * speed));
				}
								//Check if player has hit the wall.
				if (player.Position.X > Director.Instance.GL.Context.GetViewport().Width - player.Quad.S.X)
				{
					player.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width - player.Quad.S.X,player.Position.Y);
				}
				else if (player.Position.X < 0.0f)
				{					
					player.Position = new Vector2(0.0f, player.Position.Y);
				}
				else if (player.Position.Y < 0.0f)
				{					
					player.Position = new Vector2(player.Position.X, 0.0f);
				}
				if((gamePadData.Buttons & GamePadButtons.Triangle) != 0)
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
					foreach(Weapon w in weaponList)
					{
						w.Update();
					}
				
			}
		}
	}
}

