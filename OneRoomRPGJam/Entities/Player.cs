using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneRoomRPGJam.Entities.EntityStates;
using OneRoomRPGJam.Entities.PlayerStates;
using OneRoomRPGJam.Graphics;
using OneRoomRPGJam.System;

namespace OneRoomRPGJam.Entities
{
	public class Player : CollisionEntity
	{
		//TODO Fix bug where hitbox doesnt flip to match sprite
		//Create body box 
		//These boxes should not be the entire rectangle of the current sprite. 

		List<PickUp> inventory; 
		public KeyboardState keyboard;
		Random random = new Random();
		//int score;
		//int experience;
		//int maxHealth; 
		Vector2 Position;
		float angle;
		public static string LEFT = "LEFT";
		public static string RIGHT = "RIGHT";

		public string FacingDirection = RIGHT; 

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

		public Player() : base()
		{
			CollisionHandler.OnPlayerCollisionWithEnemy += OnCollisionWithEnemy;
			CollisionHandler.OnPlayerCollisionWithPickUp += OnCollisionWithPickUp; 
		}

		void LoadAnimations()
		{
			animationList = new List<Animation>();
			Texture2D knight = Content.Load<Texture2D>("player/knightidle");
			Texture2D knightwalk = Content.Load<Texture2D>("player/knightwalk");
			Texture2D knightattack = Content.Load<Texture2D>("player/knightattack");

			//Idle Right

			animationList.Add(new Animation(knight, new Rectangle(0, 0, 30, 32),
											30, 32, 6, 200f, 0, false));
			//Idle Left
			animationList.Add(new Animation(knight, new Rectangle(0, 0, 30, 32),
											30, 32, 6, 200f, 0, true));

			//Walk Right
			animationList.Add(new Animation(knightwalk, new Rectangle(0, 0, 31, 32),
											31, 32, 6, 100f, 0, false));

			//Walk Left
			animationList.Add(new Animation(knightwalk, new Rectangle(0, 0, 31, 32),
											31, 32, 6, 100f, 0, true));

			//Attack Right
			animationList.Add(new Animation(knightattack, new Rectangle(0, 0, 38, 32),
										38, 32, 6, 50f, 0, false));

			//Attack Left
			animationList.Add(new PlayerAnimation(knightattack, new Rectangle(0, 0, 38, 32),
										38, 32, 6, 50f, 0, true,8));
			currentAnimation = animationList[0]; 
		}

		void LoadStates()
		{
			stateMachine = new StateMachine();

			stateMachine.AddState(new PlayerIdleState(this));
			stateMachine.AddState(new PlayerWalkingState(this));
			stateMachine.AddState(new PlayerAttackingState(this));
			stateMachine.Init(); 
		}

		void InitializeVariables()
		{
			x = 300;
			y = 100;
			health = 100; 
			Position = new Vector2(x, y);
			speed = 2;
			inventory = new List<PickUp>(); 
		}
			                 
		public override void Update(GameTime gameTime)
		{
			keyboard = Keyboard.GetState();
			PrintInformation();
			stateMachine.Update(gameTime);
			SetHitBox();
			UpdatePosition();
			UpdateDimmensions();
			if (currentAnimation.X != (int)Position.X || currentAnimation.Y != (int)Position.Y)
				{
					currentAnimation.X = (int)Position.X;
					currentAnimation.Y = (int)Position.Y;
				}
			currentAnimation.Update(gameTime); 
		}

		void UpdateDimmensions()
		{
			width = currentAnimation.sourceRect.Width;
			height = currentAnimation.sourceRect.Height; 
		}
		void SetHitBox()
		{
			hitbox = new Rectangle(getBounds().X + 5,getBounds().Y,getBounds().Width,getBounds().Height);
			if (FacingDirection == LEFT)
			{
			}
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
			else if (state == States.ATTACKING)
			{
				stateMachine.ChangeState(2);
			}
		}

		public void ChangeAnimation(int index)
		{
			currentAnimation = animationList[index];
		}

		public override void Render(SpriteBatch spriteBatch)
		{
			currentAnimation.Render(spriteBatch); 
		}

		public override void OnCollisionWithWall()
		{
			//Dont let player move through wall. 
			if (x <= Room.LEFT)
			{
				x = Room.LEFT + 2;
			}
			if (x + width >= Room.RIGHT)
			{
				x = (Room.RIGHT - width) - 1;
			}
			if (y <= Room.TOP)
			{
				y = Room.TOP + 2; 
			}
			if (y + height >= Room.BOTTOM)
			{
				y = (Room.BOTTOM - height) - 1; 
			}
		}

		public void OnCollisionWithEnemy()
		{
			//Knock player back
		}

		public void OnCollisionWithPickUp(CollisionEntity item)
		{
			if (inventory.Count < 4)
			{
				inventory.Add((PickUp) item);
			}
			//else do nothing
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

		void PrintInformation()
		{
			Console.Write("X: " + x + "\n" + 
			              "Y: " + y + "\n" + 
			             "Width: " + width + "\n" + 
			             "Height: " + height + "\n");
		}

		class PlayerAnimation : Animation 
		{
			int adjust; 
			public PlayerAnimation(Texture2D pSpriteSheet, Rectangle pDestRectangle,
								   int pFrameWidth, int pFrameHeight,
			                       int pTotalFrames, float pDelay, int row, bool flip,int adjust) : base(pSpriteSheet, pDestRectangle, 
			                                                                                  pFrameWidth, pFrameHeight,  pTotalFrames, 
			                                                                                  pDelay, row, flip)
			{
				this.adjust = adjust;
			}
			public override void Render(SpriteBatch sb)
			{
				sb.Draw(spriteSheet, new Rectangle(X - adjust, Y, destRect.Width, destRect.Height), 
				        sourceRect, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
			}
		}
	}
}
