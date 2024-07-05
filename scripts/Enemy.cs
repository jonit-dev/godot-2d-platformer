using Godot;
using System;

public partial class Enemy : Node2D
{
	bool isRightDirection = true;
	[Export] public float Speed = 20f; // Adjusted Speed
	RayCast2D rayCastRight;
	RayCast2D rayCastLeft;

	AnimatedSprite2D animatedSprite2D;

	public override void _Ready()
	{

		rayCastRight = GetNode<RayCast2D>("RayCastRight");
		rayCastLeft = GetNode<RayCast2D>("RayCastLeft");

		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

	}

	public override void _Process(double delta)
	{
		// check collision

		if (rayCastRight.IsColliding())
		{
			isRightDirection = false;
			animatedSprite2D.FlipH = true;

		}
		else if (rayCastLeft.IsColliding())
		{
			isRightDirection = true;
			animatedSprite2D.FlipH = true;
		}




		// move
		Vector2 direction = isRightDirection ? Vector2.Right : Vector2.Left;
		Position += direction * Speed * (float)delta;
	}


}
