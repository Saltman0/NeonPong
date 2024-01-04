using System.Diagnostics;
using Godot;

public partial class Paddle : CharacterBody2D
{
	[Export]
	private int _playerNumber = 0;
	
	[Export]
	private int _speed = 400;

	private Vector2 _ballPosition;

	private Vector2 _velocity;

	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_playerNumber > 0)
		{
			_velocity = new Vector2(
				0, 
				Input.GetVector(
					"move_left" + _playerNumber, 
					"move_right" + _playerNumber, 
					"move_top" + _playerNumber, 
					"move_down" + _playerNumber
				).Y
			) * _speed;
		}
		else
		{
			if (_ballPosition.Y < Position.Y)
			{
				_velocity.Y = -1 * _speed;
			}
			else if (_ballPosition.Y > Position.Y)
			{
				_velocity.Y = 1 * _speed;
			}
			else
			{
				_velocity.Y = 0 * _speed;
			}
		}

		Velocity = _velocity;
		
		MoveAndSlide();
	}

	public void OnDetectBallTimerTimeout()
	{
		_ballPosition = ((Ball)GetTree().GetFirstNodeInGroup("Balls")).Position;
	}
	
	public Vector2 BallPosition
	{
		get => _ballPosition;
		set => _ballPosition = value;
	}
}
