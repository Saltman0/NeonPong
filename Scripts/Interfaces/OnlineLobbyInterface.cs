using Godot;
using System;

public partial class OnlineLobbyInterface : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	[Rpc(MultiplayerApi.RpcMode.AnyPeer, CallLocal = true, TransferMode = MultiplayerPeer.TransferModeEnum.Unreliable)]
	public void OnStartGameButtonPressed()
	{
		GD.Print("OnStartGameButtonPressed");
		Rpc(nameof(StartGame));
	}

	[Rpc(MultiplayerApi.RpcMode.AnyPeer, CallLocal = true, TransferMode = MultiplayerPeer.TransferModeEnum.Unreliable)]
	public void StartGame()
	{
		GD.Print("start game");
		PackedScene multiplayerGameScene = ResourceLoader.Load<PackedScene>("res://Scenes/Matchs/ClassicMultiplayerMatch.tscn");
		GetTree().Root.AddChild(multiplayerGameScene.Instantiate());
		this.Hide();
	}
}
