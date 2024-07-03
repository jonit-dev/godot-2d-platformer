using Godot;
using System;

public partial class Coin : Area2D
{

	private AudioStreamPlayer audioPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{



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
			// destroy itself
			QueueFree();
		}

	}

	public override void _Process(double delta)
	{
	}
}
