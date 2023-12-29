using Godot;
using System;
using System.Diagnostics;

public partial class Ball : CharacterBody2D
{
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
			float speedMultiplier = 1.00f;
			if (collisionObject.GetCollider() is Paddle)
			{
				speedMultiplier = 1.02f;
			}
			
			Velocity = Velocity.Bounce(collisionObject.GetNormal()) * speedMultiplier;
		}
	}

	public void ResetBall(Vector2 position, int direction)
	{
		Position = position;
		Velocity = new Vector2(direction, 0);
	}
}
