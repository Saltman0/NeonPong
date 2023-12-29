using Godot;
using System;
using System.Diagnostics;

public partial class Paddle : CharacterBody2D
{
	[Export]
	private bool _isPlayer = true;

	private Vector2 _ballPosition;
	
	private const int Speed = 300;

	public override void _PhysicsProcess(double delta)
	{
		if (_isPlayer)
		{
			Velocity = new Vector2(
				0, 
				Input.GetVector("move_left", "move_right", "move_top", "move_down").Y
			) * Speed;
		}
		else
		{
			
		}
		
		MoveAndSlide();
	}

	public bool IsPlayer
	{
		get => _isPlayer;
		set => _isPlayer = value;
	}

	public Vector2 BallPosition
	{
		get => _ballPosition;
		set => _ballPosition = value;
	}
}
