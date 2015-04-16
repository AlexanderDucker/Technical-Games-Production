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
	public class InputManager
	{
		private GamePadData		gamePadData;
		private  Vector2 		transform, facingDirection;
		private bool 			canFire = false;
		public int textures;
		
		public InputManager ()
		{
			transform= new Vector2(0,0);
			facingDirection= new Vector2(0,0);
		}
		
		public void CheckInput()
		{
			gamePadData = GamePad.GetData(0);
			
			//Left movement
		    	if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
		    	{
					textures = 1;

					transform.X = -1.0f;
					facingDirection.X = -1.0f;
					if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
		    		{
						facingDirection.Y = 1.0f;
						textures = 1;
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
				textures = 0;
			
					transform.X = 1.0f;
					facingDirection.X = 1.0f;
					if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
		    		{
						facingDirection.Y = 1.0f;
						textures = 1;
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
					transform.X = 0.0f;
				}
				//Up movement
			
		    	if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
		    	{
				textures = 2;
					transform.Y = 1.0f;
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
				textures = 3;
					transform.Y = -1.0f;
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
					transform.Y = 0.0f;
				}
				
			
			if((gamePadData.Buttons & GamePadButtons.Triangle) != 0)
			{
				canFire = true;	
			}
			else
			{
				canFire = false;	
			}
		}
		public int GetTexture()
		{
			return textures;				
		}
		
		public Vector2 GetTransform()
		{
			return transform;
		}
		
		public Vector2 GetFacingDirection()
		{
			return facingDirection;	
		}
		
		public bool GetCanFire()
		{
			return canFire;	
		}
	}
}

