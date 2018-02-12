using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam
{
	public class MainMenu : GameState
	{
		public MainMenu()
		{
			
		}

		public void Init()
		{
			Console.WriteLine("Main Menu has been initialized");
		}

		public void onEnter()
		{
			Console.WriteLine("Main Menu has entered");
		}

		public void onExit()
		{
			Console.WriteLine("Main Menu has exited"); 
		}

		public void Render(SpriteBatch spriteBatch)
		{
			Console.WriteLine("Rendering Main Menu");
		}

		public void Update(GameTime gameTime)
		{
			Console.WriteLine("Updating Main Menu"); 
		}
	}
}
