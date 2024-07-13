using Godot;
using System;

public partial class ScoreManager : Node
{

	private int _score = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddScore(int score)
	{
		_score += score;
	}

	public int GetScore()
	{
		return _score;
	}

	public void ResetScore()
	{
		_score = 0;
	}

}
