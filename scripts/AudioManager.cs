using Godot;
using System;
using System.Collections.Generic;
using System.IO;

public partial class AudioManager : Node2D
{
	private Dictionary<string, AudioStream> soundLibrary = new Dictionary<string, AudioStream>();
	public static AudioManager singleton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		singleton = this;
		LoadSounds();
		// Ensure the AudioManager is not deleted when changing scenes
		SetProcess(true);

		// Play the background music
		PlaySound("time-for-adventure", true);
	}

	public void LoadSounds()
	{
		// music
		soundLibrary.Add("time-for-adventure", GD.Load<AudioStream>("res://assets/music/time_for_adventure.mp3"));
		// sound effects
		soundLibrary.Add("coin_collect", GD.Load<AudioStream>("res://assets/sounds/coin.wav"));
	}

	public void PlaySound(string soundName, bool isLoop = false)
	{
		if (soundLibrary.ContainsKey(soundName))
		{
			var player = new AudioStreamPlayer();
			AddChild(player);
			player.Stream = soundLibrary[soundName];
			player.Play();

			if (isLoop)
			{
				// Connect the finished signal to a method that replays the sound
				player.Connect("finished", new Callable(this, nameof(ReplaySound)));
			}
			else
			{
				// Connect to a method that cleans up after the sound is finished
				player.Connect("finished", new Callable(player, "queue_free"));
			}
		}
		else
		{
			throw new FileNotFoundException("Sound file not found.");
		}
	}

	private void ReplaySound()
	{
		// Cast 'this' as AudioStreamPlayer and replay
		AudioStreamPlayer player = (AudioStreamPlayer)Owner;
		player.Play();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
