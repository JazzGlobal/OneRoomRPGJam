using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam
{
	public abstract class State
	{
		public abstract void Init(); 
		public abstract void Update(GameTime gameTime);
		public abstract void Render(SpriteBatch spriteBatch);
		public abstract void OnEnter();
		public abstract void OnExit(); 
}
}
