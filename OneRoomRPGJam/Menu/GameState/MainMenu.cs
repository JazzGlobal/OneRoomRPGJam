using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam
{	
	public class MainMenu : GameState
	{
		Button startGameButton;
		Button optionsButton;
		Button exitButton;

		public void Init(ContentManager content)
		{
			startGameButton = new Button(0, 0, content.Load<Texture2D>("startbutton"), "Start");
			optionsButton = new Button(0, 0, null, "Options");
			exitButton = new Button(0, 0, null, "Exit");

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
			startGameButton.Render(spriteBatch);
		}

		public void Update(GameTime gameTime)
		{
			Button.Update(startGameButton, gameTime, StartButtonClick);
			//Button.Update(optionsButton, gameTime, OptionButtonClick);
			//Button.Update(exitButton, gameTime, ExitButtonClick);

		}

		private void StartButtonClick()
		{
			Console.WriteLine("Start Pressed");
			//Change State to Play
		}

		private void OptionButtonClick()
		{
			//Change State to Options		
		}

		private void ExitButtonClick()
		{
			Game1.ExitGame();
		}
	}
}
