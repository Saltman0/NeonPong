using Godot;
using System;
using System.Diagnostics;

public partial class Ball : CharacterBody2D
{
	[Signal]
	public delegate void SendPositionEventHandler(int position);
	
	private int _speed = 500;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		KinematicCollision2D collisionObject = MoveAndCollide(Velocity * _speed * (float)delta);

		if (collisionObject != null)
		{
			Velocity = Velocity.Bounce(collisionObject.GetNormal()) * 1.02f;
		}
	}

	public void OnTimerTimeout()
	{
		EmitSignal(SignalName.SendPosition, Position);
	}
}
