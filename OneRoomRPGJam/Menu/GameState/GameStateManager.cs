using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam
{
	//TODO: Create Play state for character and collision testing. 
	public class GameStateManager
	{
		List<GameState> StateList;
		int currentGameState;
		private static ContentManager Content; 
		public GameStateManager(ContentManager content)
		{
			StateList = new List<GameState>();
			Content = content; 
		}

		/// <summary>
		/// Initializes GameState classes that exist within the 'StateList'. 
		/// </summary>
		public void Init()
		{
			foreach (GameState gs in StateList)
			{
				gs.Init(Content); 
			}
		}

		/// <summary>
		/// Updates the current GameState.
		/// </summary>
		public void Update(GameTime gameTime)
		{
			StateList[currentGameState].Update(gameTime); 
		}

		/// <summary>
		/// Renders the current GameState. 
		/// </summary>
		public void Render(SpriteBatch spriteBatch)
		{
			StateList[currentGameState].Render(spriteBatch); 
		}

		/// <summary>
		/// Adds new GameState to 'StateList'.
		/// </summary>
		/// <param name="gs">Gs.</param>
		public void AddGameState(GameState gs)
		{
			if (!StateList.Contains(gs))
			{
				StateList.Add(gs);
			}
			else
			{
				Console.WriteLine("Could not add GameState. Already exists."); 
			}
		}

		/// <summary>
		/// Changes the state of the game.
		/// </summary>
		/// <param name="index">Index.</param>
		public void ChangeGameState(int index)
		{
			StateList[currentGameState].onExit();
			currentGameState = index;
			StateList[currentGameState].onEnter(); 
		}
	}
}
