using Godot;
using System;

public partial class MainMenuInterface : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void OnSinglePlayerButtonPressed()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Interfaces/SingleplayerGameModeInterface.tscn"));
	}
	
	public void OnTwoPlayerButtonPressed()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Interfaces/MultiplayerGameModeInterface.tscn"));
	}

	public void OnReturnToDesktopButtonPressed()
	{
		GetTree().Quit();
	}
}
