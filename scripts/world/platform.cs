using Godot;
using System;

public partial class platform : AnimatableBody2D
{
	[Export] public float Speed { get; set; } = 20;
	[Export] public float LeftLimit { get; set; } = -50f;
	[Export] public float RightLimit { get; set; } = 50f;

	private bool movingRight;
	private Vector2 initialPosition;

	public override void _Ready()
	{
		initialPosition = Position;

		// random x between 0 and 1
		int randomN = new Random().Next(0, 2);


		movingRight = randomN == 0 ? true : false; // randomize starting direction



	}

	public override void _PhysicsProcess(double delta)
	{
		float deltaTime = (float)delta;

		// Update position directly based on speed and direction
		if (movingRight)
		{
			Position += new Vector2(Speed * deltaTime, 0);
			if (Position.X >= initialPosition.X + RightLimit)
			{
				Position = new Vector2(initialPosition.X + RightLimit, Position.Y);
				movingRight = false;
			}
		}
		else
		{
			Position -= new Vector2(Speed * deltaTime, 0);
			if (Position.X <= initialPosition.X + LeftLimit)
			{
				Position = new Vector2(initialPosition.X + LeftLimit, Position.Y);
				movingRight = true;
			}
		}
	}
}
