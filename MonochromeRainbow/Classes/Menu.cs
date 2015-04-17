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
	public class Menu
	{
		SpriteUV backgrounds;
		public GamePadData gamepadData;
		bool startGame = false;
		public int menuNum = 0;
		public TextureLoading tex;
		public Menu (TextureLoading textures, Scene gameScene)
		{
			tex = textures;
			backgrounds = new SpriteUV(tex.MenuBGs[0]);
			backgrounds.Quad.S = tex.MenuBGs[0].TextureSizef;
			gameScene.AddChild (backgrounds);
		}
		
		public void UpdateMenus()
		{
			
			gamepadData = GamePad.GetData (0);
			if(menuNum == 0)
			{
				if(backgrounds.TextureInfo != tex.MenuBGs[0])
				{
					backgrounds.TextureInfo = tex.MenuBGs[0];	
				}
				if ((gamepadData.Buttons & GamePadButtons.Cross) != 0)
				{
					startGame = true;	
				}
				if((gamepadData.Buttons & GamePadButtons.Circle) !=0)
				{
					menuNum = 1;
				}
				
			}
			
			if(menuNum==1)
			{
				if( backgrounds.TextureInfo != tex.MenuBGs[1])
				{
					backgrounds.TextureInfo = tex.MenuBGs[1];	
				}
				if((gamepadData.Buttons & GamePadButtons.Circle) !=0)
				{
					menuNum = 0;	
				}
			}
			
			
		}
		
		public bool GetStart()
		{
			return startGame;	
		}
		
	}
}

