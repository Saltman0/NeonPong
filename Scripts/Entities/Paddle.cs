using Godot;
using System;
using System.Diagnostics;

public partial class Paddle : CharacterBody2D
{
	private const int Speed = 300;
	
	private Vector2 _velocity;

	public override void _PhysicsProcess(double delta)
	{
		Velocity = new Vector2(
			0, 
			Input.GetVector("move_left", "move_right", "move_top", "move_down").Y
		) * Speed;
		
		MoveAndSlide();
	}
}
