using Godot;
using System;

public partial class kill_zone : Area2D
{

  // add reference to node Timer

  private Timer timer;

  public override void _Ready()
  {


    timer = GetNode<Timer>("Timer");

    timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));

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
      GD.Print("Game over!");


      DeathEffect(body);

      timer.Start();


    }

  }

  private void DeathEffect(Node body)
  {
    Engine.TimeScale = 0.5; // slow down the game as a visual effect
    body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree(); // remove the collision shape of the player

  }

  private void OnTimerTimeout()
  {

    Engine.TimeScale = 1; // reset the time scale

    // reload scene
    GetTree().ReloadCurrentScene();
  }



}
