﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneRoomRPGJam.Entities.EntityStates;
using OneRoomRPGJam.Entities.PlayerStates;
using OneRoomRPGJam.Graphics;

namespace OneRoomRPGJam.Entities
{
	public class Player : CollisionEntity
	{
		//TODO Create method that uses items 
		//TODO Create hitboxes for player
		//Create body box 
		//These boxes should not be the entire rectangle of the current sprite. 

		public KeyboardState keyboard;
		Random random = new Random();
		//int score;
		//int experience;
		//int maxHealth; 
		Vector2 Position;
		float angle;
		//string facingDirection;
		private const string LEFT = "LEFT";
		private const string RIGHT = "RIGHT";
		private StateMachine stateMachine;
		List<Animation> animationList;
		Animation currentAnimation;
		public Animation CurrentAnimation
		{
			get{return currentAnimation;}
			set{currentAnimation = value;}
		}
		public int X
		{
			get { return x;}
			set { x = value;}
		}
		public int Y
		{
			get { return y; }
			set { y = value; }
		}
		public int Speed
		{
			get { return speed; }
			set { speed = value; }
		}
		public enum States
		{
			IDLE, WALKING, ATTACKING, HURT
		}

		public override void Init()
		{
			LoadAnimations();
			LoadStates();
			InitializeVariables();
		}

		void LoadAnimations()
		{
			animationList = new List<Animation>();
			Texture2D knight = Content.Load<Texture2D>("player/knightidle");
			animationList.Add(new Animation(knight, new Rectangle(0, 0, 30, 32),
											30, 32, 6, 200f, 0, false));
			
			currentAnimation = animationList[0]; 
		}
		void LoadStates()
		{
			stateMachine = new StateMachine();

			stateMachine.AddState(new PlayerIdleState(this));
			stateMachine.AddState(new PlayerWalkingState(this)); 
			stateMachine.Init(); 
		}

		void InitializeVariables()
		{
			x = 300;
			y = 100;
			health = 100; 
			Position = new Vector2(x, y);
			speed = 2; 
		}
			                 

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
		{
			keyboard = Keyboard.GetState(); 

			stateMachine.Update(gameTime);

			UpdatePosition();
			if (currentAnimation.X != (int)Position.X || currentAnimation.Y != (int)Position.Y)
				{
					currentAnimation.X = (int)Position.X;
					currentAnimation.Y = (int)Position.Y;
				}


			currentAnimation.Update(gameTime); 
		}

		void UpdatePosition()
		{
			Position.X = x;
			Position.Y = y;
			
		}

		public enum Directions
		{
			UP, DOWN, LEFT, RIGHT
		}

		/// <summary>
		/// Move the specified direction.
		/// </summary>
		/// <returns>The move.</returns>
		/// <param name="direction">Direction.</param>
		public void Move(Directions direction)
		{
			if (direction == Directions.UP)
			{
				y -= speed; 
			}
			if (direction == Directions.LEFT)
			{
				x -= speed; 
			}
			if (direction == Directions.RIGHT)
			{
				x += speed; 
			}
			if (direction == Directions.DOWN)
			{
				y += speed;
			}
		}
		public void ChangeState(Player.States state)
		{
			if (state == Player.States.IDLE)
			{
				stateMachine.ChangeState(0);
			}
			else if (state == Player.States.WALKING)
			{
				stateMachine.ChangeState(1);
			}
		}
		public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			currentAnimation.Render(spriteBatch); 
		}

		/// <summary>
		/// Increases one player state at random by 1 point. 
		/// </summary>
		void LevelUp()
		{
			var v = random.Next(0, 3);
			if (v == 0)
			{
				health++; 
			}
			else if (v == 1)
			{
				attack++; 
			}
			else if (v == 2)
			{
				//If speed < certain amount..
				//then speed++;
				//else
				//then health++ 
			}
		}
	}
}