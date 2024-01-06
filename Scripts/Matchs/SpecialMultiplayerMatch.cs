using Godot;
using System;

public partial class SpecialMultiplayerMatch : Match
{
    public new void OnMatchInterfaceReplayButtonPressed()
    {
        ReplayMatch();
        ResetBricks();
    }
}
