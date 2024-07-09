using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;

	private AnimatedSprite2D animatedSprite;


	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}



	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");


		HandleSpriteFlip(direction);


		HandleAnimations(direction);



		HandleMovement(direction, ref velocity);


	}

	public void HandleSpriteFlip(Vector2 direction)
	{
		// Flip sprite based on horizontal movement (X axis)
		if (direction.X < 0)
		{
			animatedSprite.FlipH = true;
		}
		else if (direction.X > 0)
		{
			animatedSprite.FlipH = false;
		}
	}

	public void HandleAnimations(Vector2 direction)
	{

		// if its jumping...
		if (!IsOnFloor())
		{
			animatedSprite.Play("jump");
			return;
		}


		// Set the animation based on the direction.
		if (direction != Vector2.Zero)
		{
			animatedSprite.Play("run");
		}
		else
		{
			animatedSprite.Play("idle");
		}
	}

	public void HandleMovement(Vector2 direction, ref Vector2 velocity)
	{
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}




}
