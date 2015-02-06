using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Character
	{
		private SpriteUV		character;
		private TextureInfo		characterTextureInfo;
		private Resurrection	ring;
		private GamePadData		gamePadData;
		
		private float			health;
		private bool 			isPlayer;
		private bool 			isAlive;
		private bool			isActivated;
		
		public bool IsAlive{ get{return isAlive;} set{isAlive = value;} }
		public float Health{ get{return health;} set{health = value;} }
		
		public Character (Scene scene, Vector2 characterPos, bool isPlayer, TextureInfo texture)
		{
			characterTextureInfo = texture;
			character = new SpriteUV(texture);
			character.Scale = texture.TextureSizef;
			character.Position = characterPos;
			
			health = 1.0f;
			isAlive = true;
			isActivated = false;
			this.isPlayer = isPlayer;
			scene.AddChild(character);
		}
		
		public void Dispose()
		{
			characterTextureInfo.Dispose();
		}
		
		public void Update()
		{
        	//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			
			if(isPlayer && isAlive)
			{
				//Left movement.
	    		if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
	    		{
					character.Position = new Vector2(character.Position.X - 4.0f, character.Position.Y);
	    		}
			
				//Right movement.
	    		if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
	    		{
					character.Position = new Vector2(character.Position.X + 4.0f, character.Position.Y);
	    		}
				
				//Up movement.
	    		if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
	    		{
					character.Position = new Vector2(character.Position.X, character.Position.Y + 4.0f);
	    		}
				
				//Down movement.
	    		if ((gamePadData.Buttons & GamePadButtons.Down) != 0)
	    		{
					character.Position = new Vector2(character.Position.X, character.Position.Y - 4.0f);
	    		}
			}
			
			if(health <= 0.0f && !isPlayer && !isActivated)
			{
				isAlive = false;		
				Death();
				isActivated = true;
			}
			
			else if(health <= 0.0f && isPlayer)
			{
				isAlive = false;
			}
		}
		
		public void Death()
		{
			Scene scene = Director.Instance.CurrentScene;
			ring = new Resurrection(scene, character.Position);
		}
	}
}

