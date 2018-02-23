using System;
using OneRoomRPGJam.Entities;
using OneRoomRPGJam.Entities.EntityStates;

namespace OneRoomRPGJam.Entities.PlayerStates
{
	public abstract class PlayerState : State
	{
		protected Player player; 

		public PlayerState(Player player)
		{
			this.player = player; 
		}
	}
}
