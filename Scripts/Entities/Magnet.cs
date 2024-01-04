using Godot;
using System;
using System.Diagnostics;

public partial class Magnet : StaticBody2D
{
	[Export]
	private int _force = 300;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnMagnetGravityAreaBodyEntered(Ball ball)
	{
		Trace.WriteLine(Position - ball.Position);
		ball.Velocity = (Position - ball.Position).Normalized(); // TODO A VERIFIER
		Trace.WriteLine(ball.Velocity);
	}
}
