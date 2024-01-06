using Godot;
using System;

public partial class MultiplayerGameModeInterface : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnClassicModeButtonPressed()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Matchs/ClassicMultiplayerMatch.tscn"));
	}
	
	public void OnSpecialModeButtonPressed()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Matchs/SpecialMultiplayerMatch.tscn"));
	}
}
