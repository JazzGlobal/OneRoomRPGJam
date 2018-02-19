using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam
{
	public class PlayerWalkingState : PlayerState
	{
		public PlayerWalkingState(Player player) : base (player)
		{
		}

		public override void Init()
		{
		}

		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}

		public override void Render(SpriteBatch spriteBatch)
		{
		}

		public override void Update(GameTime gameTime)
		{
			Console.WriteLine("Walking update");
		}
	}
}
