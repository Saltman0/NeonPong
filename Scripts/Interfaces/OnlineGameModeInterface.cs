using Godot;
using System;
using System.Diagnostics;

public partial class OnlineGameModeInterface : Control
{
	[Signal]
	public delegate void ReturnToMainMenuEventHandler();
	
	[Export]
	private string _ipAdress = "127.0.0.1";
	
	[Export] 
	private int _port = 8910;
	
	private ENetMultiplayerPeer _peer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Multiplayer.PeerConnected += PeerConnected;
		Multiplayer.PeerDisconnected += PeerDisconnected;
		Multiplayer.ConnectionFailed += ConnectionFailed;
		Multiplayer.ConnectedToServer += ConnectedToServer;
		
		_peer = new ENetMultiplayerPeer();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void PeerConnected(long id)
	{
		GD.Print("Peer connected " + id);
	}
	
	private void PeerDisconnected(long id)
	{
		GD.Print("Peer disconnected " + id);
	}
	
	private void ConnectionFailed()
	{
		GD.Print("Connection failed");
	}
	
	private void ConnectedToServer()
	{
		GD.Print("Connected");
	}

	public void OnHostButtonPressed()
	{ 
		_peer = new ENetMultiplayerPeer();
		
		Error error = _peer.CreateServer(8910, 2);
		if (error != Error.Ok)
		{
			GD.Print(error.ToString());
		}
		
		_peer.Host.Compress(ENetConnection.CompressionMode.RangeCoder);

		Multiplayer.MultiplayerPeer = _peer;
		
		GD.Print("Host success");
		
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Interfaces/OnlineLobbyInterface.tscn"));
	}
	
	public void OnJoinButtonPressed()
	{
		_peer = new ENetMultiplayerPeer();
		_peer.CreateClient("127.0.0.1", 8910);
		
		_peer.Host.Compress(ENetConnection.CompressionMode.RangeCoder);
		
		Multiplayer.MultiplayerPeer = _peer;
		
		GD.Print("Join Game");
		// ID Code value
		/*GetNode<LineEdit>("OnlineGameModeContainer/JoinContainer/IdCodeEdit").Text;*/
	}
	
	public void OnReturnButtonPressed()
	{
		EmitSignal(SignalName.ReturnToMainMenu);
	}

	public void OnStartButtonPressed()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Matchs/ClassicMultiplayerMatch.tscn"));
	}
}
