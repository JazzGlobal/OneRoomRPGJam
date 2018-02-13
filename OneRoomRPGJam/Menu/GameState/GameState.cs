using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam
{
	public interface GameState
	{
		void Init(ContentManager content);
		void Update(GameTime gameTime);
		void Render(SpriteBatch spriteBatch);
		void onEnter();
		void onExit(); 
	}
}
