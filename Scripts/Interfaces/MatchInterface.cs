using Godot;
using System;

public partial class MatchInterface : Control
{
	[Signal]
	public delegate void ReplayButtonPressedEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public void OnReplayButtonPressed()
	{
		EmitSignal(SignalName.ReplayButtonPressed);
	}
	
	public void OnMainMenuButtonPressed()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Interfaces/MainMenuInterface.tscn"));
	}
}
