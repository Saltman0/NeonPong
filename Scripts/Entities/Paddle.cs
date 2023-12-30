using Godot;
using System;
using System.Diagnostics;

public partial class Paddle : CharacterBody2D
{
	[Export]
	private bool _isPlayer = true;

	private Vector2 _ballPosition;
	
	private const int Speed = 300;

	private Vector2 _velocity;

	public override void _Ready()
	{
		_velocity = Velocity;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_isPlayer)
		{
			HandlePlayerMovement();
		}
		else
		{
			HandleAIMovement();
		}

		Velocity = _velocity;
		
		MoveAndSlide();
	}

	public void HandlePlayerMovement()
	{
		_velocity = new Vector2(
			0, 
			Input.GetVector("move_left", "move_right", "move_top", "move_down").Y
		) * Speed;
		Velocity = _velocity;
	}
	
	public void HandleAIMovement()
	{
		_velocity.Y = (_ballPosition.Y > Position.Y ? 1 : -1) * Speed;
		Velocity = _velocity;
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
