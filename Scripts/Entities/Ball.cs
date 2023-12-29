using Godot;
using System;
using System.Diagnostics;

public partial class Ball : RigidBody2D
{
	private int _speed = 500;

	/*private Vector2 _linearVelocity;*/
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Initialize LinearVelocity
		LinearVelocity = new Vector2(_speed, 500);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public void OnBodyEntered(Node body)
	{
		/*if (body is Paddle)
		{
			_linearVelocity.X *= -1;
			LinearVelocity = _linearVelocity;
			Trace.WriteLine(LinearVelocity);
		}*/
		
		/*Trace.WriteLine(LinearVelocity.X);

		_linearVelocity.X *= -1;

		LinearVelocity = _linearVelocity;

		Trace.WriteLine(LinearVelocity);*/
		/*area.direction = Vector2(_ball_dir, randf() * 2 - 1).normalized();*/
	}
}
