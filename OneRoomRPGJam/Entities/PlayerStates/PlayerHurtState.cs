using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OneRoomRPGJam.Entities;
using OneRoomRPGJam.Entities.PlayerStates;

namespace OneRoomRPGJam
{
	public class PlayerHurtState : PlayerState
	{
		public PlayerHurtState(Player player) : base(player)
		{
		}

		public override void Init()
		{
			throw new NotImplementedException();
		}

		public override void OnEnter()
		{
			//Change animation to hurt. 
			throw new NotImplementedException();
		}

		public override void OnExit()
		{
			throw new NotImplementedException();
		}

		public override void Render(SpriteBatch spriteBatch)
		{
			throw new NotImplementedException();
		}

		public override void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
			//Knock player back 
			//Go to idle state after knockback is finished. 
			//Make player invulnerable to 1.5 seconds after being hit. 
		}
	}
}
