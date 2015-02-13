using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Player
	{
		private TextureInfo		textureInfo;
		private TextureInfo[]	textures;
		private GamePadData		gamePadData;
		
		public bool 			canBeHit;
		public int				health;
		public Timer			timer;
		public float			previousTime; 
		public float			currentTime;
		public float			elapsedTime;
		public float			coolTime;
		public float			shootCoolTime;
		public int 				ammo;
		public Vector2			facingDirection;
		public bool				startOn;
		public Bounds2 			bounds;
		public Vector2			playerPos; 
		public SpriteTile		player;
		public Vector2 			playerRec;
		public bool 			isPressed;
		public Vector2i[]		tileIndex;
		public bool				canShoot;
		public bool 			isAlive;
		public float 			speed;
		
		public Player (Scene scene, Vector2 playerPosition)
		{
			SetSpriteArray();
			
			textureInfo = new TextureInfo();
			textureInfo = textures[3];
			
			timer = new Timer();
			previousTime = (float)timer.Milliseconds();
			
			player = new SpriteTile(textureInfo);
			playerRec = new Vector2(32,64);
			player.Quad.S = playerRec;
			playerPos = playerPosition;
			speed = 2.0f;
			isAlive = true;
			bounds = new Bounds2();
			health = 10;
			ammo = 50;
			canShoot = true;
			
			scene.AddChild(player);
		}
		
		public void SetSpriteArray()
		{
			textures = new TextureInfo[6];
			textures[0]		= new TextureInfo("/Application/textures/player/sprites/standingLeft.png");
			textures[1]		= new TextureInfo("/Application/textures/player/sprites/standingRight.png");
			textures[2]		= new TextureInfo("/Application/textures/player/sprites/coffeeLeft.png");
			textures[3]		= new TextureInfo("/Application/textures/player/sprites/coffeeRight.png");	
			textures[4]		= new TextureInfo("/Application/textures/player/sprites/jumpingLeft.png");
			textures[5]		= new TextureInfo("/Application/textures/player/sprites/jumpingRight.png");
		}
		
		public void Update(Scene gameScene)
		{
        	//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			currentTime = (float)timer.Milliseconds();
			elapsedTime = currentTime - previousTime;
			previousTime = currentTime;
			coolTime+= elapsedTime;
			shootCoolTime += elapsedTime;
			if (!canBeHit)
				{
					if (coolTime >= 2000)
					{
						coolTime = 0.0f;
						canBeHit= true;
					}
				}
			if (!canShoot)
			{
				if (shootCoolTime >= 300)
				{
					shootCoolTime = 0.0f;
					canShoot = true;
				}
			}
				
			if(health < 0)
			{
				health = 0;	
			}
			
			//Left movement
        	if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
        	{
				facingDirection.X = -1.0f;
        	}
			//Right movement
        	else if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
        	{
				facingDirection.X = 1.0f;
        	}
			else
			{
				facingDirection.X = 0.0f;	
			}
			//Up movement
        	if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
        	{
				facingDirection.Y = 1.0f;
        	}
			//Down movement
        	else if ((gamePadData.Buttons & GamePadButtons.Down) != 0)
        	{
				facingDirection.Y = -1.0f;
        	}
			else
			{
				facingDirection.Y = 0.0f;	
			}
			if (!facingDirection.IsZero())
			{
				Vector2 newDir = facingDirection.Normalize();
				playerPos += newDir * speed;
			}
						

			
			if(health == 0)	
			{
				isAlive = false;
			}
			
			player.Position = playerPos;
			player.Draw();
		}
	}
}
















