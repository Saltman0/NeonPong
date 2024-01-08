using Godot;
using System;

public partial class MainMenuInterface : Control
{
	private Label _titleLabel;
	private GridContainer _mainMenuContainer;
	private SingleplayerGameModeInterface _singleplayerGameModeInterface;
	private MultiplayerGameModeInterface _multiplayerGameModeInterface;
	private OnlineGameModeInterface _onlineGameModeInterface;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_titleLabel = GetNode<Label>("TitleLabel");
		_mainMenuContainer = GetNode<GridContainer>("MainMenuContainer");
		_singleplayerGameModeInterface = GetNode<SingleplayerGameModeInterface>("SingleplayerGameModeInterface");
		_multiplayerGameModeInterface = GetNode<MultiplayerGameModeInterface>("MultiplayerGameModeInterface");
		_onlineGameModeInterface = GetNode<OnlineGameModeInterface>("OnlineGameModeInterface");
	}

	public void OnSinglePlayerButtonPressed()
	{
		_mainMenuContainer.Visible = false;
		_singleplayerGameModeInterface.Visible = true;
	}
	
	public void OnMultiplayerButtonPressed()
	{
		_mainMenuContainer.Visible = false;
		_multiplayerGameModeInterface.Visible = true;
	}
	
	public void OnOnlineButtonPressed()
	{
		_mainMenuContainer.Visible = false;
		_onlineGameModeInterface.Visible = true;
	}
	
	public void OnReturnToDesktopButtonPressed()
	{
		GetTree().Quit();
	}

	public void OnSingleplayerGameModeInterfaceReturnToMainMenu()
	{
		_mainMenuContainer.Visible = true;
		_singleplayerGameModeInterface.Visible = false;
	}

	public void OnMultiplayerGameModeInterfaceReturnToMainMenu()
	{
		_mainMenuContainer.Visible = true;
		_multiplayerGameModeInterface.Visible = false;
	}

	public void OnOnlineGameModeInterfaceReturnToMainMenu()
	{
		_mainMenuContainer.Visible = true;
		_onlineGameModeInterface.Visible = false;
	}
}
