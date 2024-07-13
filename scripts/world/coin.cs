using Godot;
using System;

public partial class Coin : Area2D
{

	private ScoreManager _scoreManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		_scoreManager = GetNode<ScoreManager>("%ScoreManager");


		// Connect the 'body_entered' signal to the 'OnBodyEntered' method using a Callable
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	// Method to handle the event when a body enters the area
	private void OnBodyEntered(Node body)
	{
		// Implement what should happen when a body enters this area
		GD.Print("A body entered: ", body.Name);

		if (body.Name == "Player")
		{

			// Increase the score
			_scoreManager.AddScore(1);

			int currentScore = _scoreManager.GetScore();

			GD.Print("Current Score: ", currentScore);

			AudioManager.singleton.PlaySound("coin_collect");
			// destroy itself
			QueueFree();
		}

	}

	public override void _Process(double delta)
	{
	}
}
