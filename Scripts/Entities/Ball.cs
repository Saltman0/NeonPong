using Godot;
using System;
using System.Diagnostics;

public partial class Ball : RigidBody2D
{
	private int _speed = 500;

	private Vector2 _linearVelocity;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ApplyCentralImpulse(new Vector2(1, 1));
		_linearVelocity = LinearVelocity;
		/*Random rnd = new Random();
		int month  = rnd.Next(1, 13);  // creates a number between 1 and 12
		LinearVelocity = new Vector2(rnd.Next(0, 100), rnd.Next(1, 13)) * _speed;*/
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		/*Trace.WriteLine(_linearVelocity);*/
	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
	}

	public void OnBodyEntered(Node paddle)
	{
		ApplyCentralImpulse(new Vector2(2, 2));
		Trace.WriteLine(_linearVelocity);
	}
}
