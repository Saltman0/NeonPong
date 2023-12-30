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

	private Paddle _leftPaddle;
	
	private Paddle _rightPaddle;

	private Timer _goalTimer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_ball = GetNode<Ball>("Ball");

		_leftPaddle = GetNode<Paddle>("LeftPaddle");
		_rightPaddle = GetNode<Paddle>("RightPaddle");
		
		_goalTimer = GetNode<Timer>("GoalTimer");
		
		_ball.Velocity = new Vector2(_startBallDirection, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public void OnLeftGoalBodyEntered(Ball ball)
	{
		_startBallDirection = -1;
		RightScore += 1;
		
		if (RightScore == _scoreToReach)
		{
			ToggleMatchAnnouncement(true, "Right paddle won the game !");
			ToggleMatchButtonsContainer(true);
		}
		else
		{
			ToggleMatchAnnouncement(true, "Goal from right paddle !");
			_goalTimer.Start();
		}
	}
	
	public void OnRightGoalBodyEntered(Ball ball)
	{
		_startBallDirection = 1;
		LeftScore += 1;

		if (LeftScore == _scoreToReach)
		{
			ToggleMatchAnnouncement(true, "Left paddle won the game !");
			ToggleMatchButtonsContainer(true);
		}
		else
		{
			ToggleMatchAnnouncement(true, "Goal from left paddle !");
			_goalTimer.Start();
		}
	}

	public void OnGoalTimerTimeout()
	{
		ToggleMatchAnnouncement(false);
		ResetPaddlePositions();
		ResetBall();
	}

	public void OnMatchInterfaceReplayButtonPressed()
	{
		ReplayMatch();
	}

	public void ReplayMatch()
	{
		ToggleMatchAnnouncement(false);
		ToggleMatchButtonsContainer(false);
		ResetBall();
		ResetPaddlePositions();
		ResetScores();
	}

	public void ResetBall()
	{
		_ball.Position = GetNode<Marker2D>("Markers/BallSpawnMarker").Position;
		_ball.Velocity = new Vector2(_startBallDirection, 0);
	}

	public void ResetPaddlePositions()
	{
		_leftPaddle.Position = new Vector2(_leftPaddle.Position.X, GetNode<Marker2D>("Markers/LeftPaddleMarker").Position.Y);
		_rightPaddle.Position = new Vector2(_rightPaddle.Position.X, GetNode<Marker2D>("Markers/RightPaddleMarker").Position.Y);
	}

	public void ResetScores()
	{
		LeftScore = 0;
		RightScore = 0;
	}

	public int LeftScore
	{
		get => _leftScore;
		set
		{
			_leftScore = value; 
			GetNode<Label>("MatchInterface/ScorePanel/LeftScoreCounter").Text = _leftScore.ToString();
		}
	}

	public int RightScore
	{
		get => _rightScore;
		set { _rightScore = value; GetNode<Label>("MatchInterface/ScorePanel/RightScoreCounter").Text = _rightScore.ToString(); }
}

	public void OnBallSendPosition(Vector2 position)
	{
		_rightPaddle.BallPosition = position;
	}

	public void ToggleMatchAnnouncement(bool visible, string text = null)
	{
		Label announcement = GetNode<Label>("MatchInterface/MatchMenu/Announcement");
		announcement.Visible = visible;
		announcement.Text = text;
	}
	
	public void ToggleMatchButtonsContainer(bool visible)
	{
		GetNode<GridContainer>("MatchInterface/MatchMenu/MatchButtonsContainer").Visible = visible;
	}
}
