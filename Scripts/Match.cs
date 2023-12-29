using Godot;
using System;
using System.Diagnostics;

public partial class Match : Node
{
	private int _startBallDirection = -1;
	
	private int _leftScore = 0;

	private int _rightScore = 0;

	private int _scoreToReach = 3;

	private Ball _ball;

	private Marker2D _ballSpawn;

	private Timer _goalTimer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		_ball = GetNode<Ball>("Ball");
		_ballSpawn = GetNode<Marker2D>("BallSpawn");
		_goalTimer = GetNode<Timer>("GoalTimer");
		
		_ball.ResetBall(_ballSpawn.Position, _startBallDirection);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public void OnLeftGoalBodyEntered(Ball ball)
	{
		_startBallDirection = -1;
		
		_rightScore += 1;
		
		UpdateRightScoreCounter();
		
		if (_rightScore == _scoreToReach)
		{
			GetNode<Label>("MatchInterface/EndOfMatchLabel").Visible = true;
			GetNode<Label>("MatchInterface/EndOfMatchLabel").Text = "Right paddle won !";
		}
		else
		{
			_goalTimer.Start();
		}
	}
	
	public void OnRightGoalBodyEntered(Ball ball)
	{
		_startBallDirection = 1;

		_leftScore += 1;
		
		UpdateLeftScoreCounter();

		if (_leftScore == _scoreToReach)
		{
			GetNode<Label>("MatchInterface/EndOfMatchLabel").Visible = true;
			GetNode<Label>("MatchInterface/EndOfMatchLabel").Text = "Left paddle won !";
		}
		else
		{
			_goalTimer.Start();
		}
	}

	public void OnGoalTimerTimeout()
	{
		_ball.ResetBall(_ballSpawn.Position, _startBallDirection);
	}
	
	public void UpdateLeftScoreCounter()
	{
		GetNode<Label>("MatchInterface/ScorePanel/LeftScoreCounter").Text = _leftScore.ToString();
	}

	public void UpdateRightScoreCounter()
	{
		GetNode<Label>("MatchInterface/ScorePanel/RightScoreCounter").Text = _rightScore.ToString();
	}
}
