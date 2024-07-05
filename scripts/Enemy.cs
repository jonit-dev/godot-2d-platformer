using Godot;
using System;

public partial class Enemy : Node2D
{
	bool isRightDirection = true;
	[Export] public float Speed = 100f; // Adjusted Speed

	public override void _Ready()
	{
		var killZone = GetNode<Area2D>("KillZone");
		killZone.Connect("body_entered", new Callable(this, nameof(OnKillZoneBodyEntered)));
	}

	public override void _Process(double delta)
	{
		Vector2 direction = isRightDirection ? Vector2.Right : Vector2.Left;
		Position += direction * Speed * (float)delta;
	}

	public void OnKillZoneBodyEntered(Node body)
	{
		GD.Print("Enemy: ", body.Name, " entered the kill zone");

		if (body.Name == "TileMap")
		{
			isRightDirection = !isRightDirection;
		}
	}
}
