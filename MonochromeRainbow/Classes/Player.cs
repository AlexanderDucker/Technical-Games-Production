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
		private SpriteUV		player;
		private TextureInfo		playerTextureInfo;
		private GamePadData		gamePadData;
		
		private Vector2			centerPosition;
		private float			health;
		private bool 			isAlive;
		private float			radius;
		
		public Vector2 CenterPosition{ get{return centerPosition;} }
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public float Health{ get{return health;} set{health = value;} }
		public float Radius { get{return radius;} }
		public SpriteUV PlayerSprite{get {return player;} }
		
		
		public Player (Scene scene, Vector2 playerPos)
		{
			playerTextureInfo = new TextureInfo("/Application/textures/player/blue.png");
			player = new SpriteUV(playerTextureInfo);	
			player.Quad.S = playerTextureInfo.TextureSizef;
			player.Position = playerPos;
			centerPosition = player.Position + player.Quad.Center;
			radius = player.Quad.Point10.X / 2;
			health = 1.0f;
			isAlive = true;
			scene.AddChild(player);
			
		}
		
		public void Dispose()
		{
			playerTextureInfo.Dispose();
		}
		
		public void Update()
		{
        	//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			
			centerPosition = player.Position + player.Quad.Center;
			
			if(isAlive)
			{
				//Left movement.
	    		if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
	    		{
					player.Position = new Vector2(player.Position.X - 4.0f, player.Position.Y);
	    		}
			
				//Right movement.
	    		if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
	    		{
					player.Position = new Vector2(player.Position.X + 4.0f, player.Position.Y);
	    		}
				
				//Up movement.
	    		if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
	    		{
					player.Position = new Vector2(player.Position.X, player.Position.Y + 4.0f);
	    		}
				
				//Down movement.
	    		if ((gamePadData.Buttons & GamePadButtons.Down) != 0)
	    		{
					player.Position = new Vector2(player.Position.X, player.Position.Y - 4.0f);
	    		}
			}
		}
	}
}

