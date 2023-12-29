using Godot;
using System;
using System.Diagnostics;

public partial class Match : Node
{
	private int _leftScore = 0;

	private int _rightScore = 0;

	private Ball _ball;

	private Marker2D _ballSpawn;

	private Timer _goalTimer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_ball = GetNode<Ball>("Ball");
		_ballSpawn = GetNode<Marker2D>("BallSpawn");
		_goalTimer = GetNode<Timer>("GoalTimer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public void OnLeftGoalBodyEntered(Node body)
	{
		UpdateRightScore(_rightScore + 1);
		
		Trace.WriteLine(_ball.Position);
		
		_goalTimer.Start();
	}
	
	public void OnRightGoalBodyEntered(Node body)
	{
		UpdateLeftScore(_leftScore + 1);
		
		Trace.WriteLine(_ball.Position);
		
		_goalTimer.Start();
	}

	public void OnGoalTimerTimeout()
	{
		_ball.Position = _ballSpawn.Position;
	}
	
	public void UpdateLeftScore(int leftScore)
	{
		_leftScore = leftScore;
		GetNode<Label>("MatchInterface/ScorePanel/LeftScore").Text = _leftScore.ToString();
	}

	public void UpdateRightScore(int rightScore)
	{
		_rightScore = rightScore;
		GetNode<Label>("MatchInterface/ScorePanel/RightScore").Text = _rightScore.ToString();
	}
}
