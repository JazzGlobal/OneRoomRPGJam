using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneRoomRPGJam.Entities;

namespace OneRoomRPGJam
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		GameStateManager GSM;
		private static bool exit = false;
		private static GraphicsDevice gd;
		Player p;
		Slime s;
		Room r;
		Outline test;
		Controller c; 
		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 640;
			graphics.PreferredBackBufferHeight = 480;
			Content.RootDirectory = "Content";
			GSM = new GameStateManager(Content);
			IsMouseVisible = true;
			p = new Player();
			s = new Slime(new Color(200, 50, 200));
			r = new Room();
			c = new Controller(); 
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			gd = graphics.GraphicsDevice;
			Entity.SetContentManager(Content);
			GSM.AddGameState(new MainMenu());
			GSM.Init();
			//p.Init();
			s.Init();
			r.Init();
			c.Init(); 
			base.Initialize();
			test = new Outline(Color.Green, p.getBounds());

		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
#if !__IOS__ && !__TVOS__
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
#endif

			r.Update(gameTime); 
			//p.Update(gameTime); 
			GSM.Update(gameTime);
			s.Update(gameTime);
			c.Update(gameTime); 
			test.Update(gameTime, p.HitBox);
			if (exit)
			{
				Exit(); 
			}
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			r.Render(spriteBatch); 
			//p.Render(spriteBatch);
			s.Render(spriteBatch);
			c.Render(spriteBatch); 
			test.Render(spriteBatch);
			//GSM.Render(spriteBatch);
			spriteBatch.End(); 
			base.Draw(gameTime);
		}
		public static void ExitGame()
		{
			exit = true; 
		}
		public static GraphicsDevice GetGraphicsDevice() 
		{
			return gd; 
		}
	}
}
