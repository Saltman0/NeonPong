using Godot;
using System;

public partial class Match : Node
{
	private int _leftScore = 0;

	private int _rightScore = 0;

	private PackedScene _ball;

	private Marker2D _ballSpawn;

	private Timer _goalTimer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_ball = GD.Load<PackedScene>("res://Scenes/Entities/Ball.tscn");
		_ballSpawn = GetNode<Marker2D>("BallSpawn");
		_goalTimer = GetNode<Timer>("GoalTimer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnLeftGoalBodyEntered(Node body)
	{
		UpdateRightScore(_rightScore + 1);
		
		body.QueueFree();
		
		_goalTimer.Start();
	}
	
	public void OnRightGoalBodyEntered(Node body)
	{
		UpdateLeftScore(_leftScore + 1);
		
		body.QueueFree();
		
		_goalTimer.Start();
	}

	public void OnGoalTimerTimeout()
	{
		Ball newBall = (Ball)_ball.Instantiate();

		newBall.Position = _ballSpawn.Position;
		
		AddChild(newBall);
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
