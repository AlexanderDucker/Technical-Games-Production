using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Resurrection
	{
		private SpriteUV		ring;
		private TextureInfo		ringTextureInfo; 
		
		public Resurrection (Scene gameScene, Vector2 ringPos)
		{
			ringTextureInfo = new TextureInfo("/Application/textures/ring.png");
			ring = new SpriteUV(ringTextureInfo);
			ring.Position = ringPos;
			ring.Scale = ringTextureInfo.TextureSizef;
			System.Console.WriteLine("resurrection");
			gameScene.AddChild(ring);
		}
		
		public void Dispose()
		{
			ringTextureInfo.Dispose();
		}
		
		public void Update()
		{
			
		}
	}
}

