using Godot;
using System;
using System.Diagnostics;

public partial class SpecialSingleplayerMatch : Match
{
    public new void OnMatchInterfaceReplayButtonPressed()
    {
        ReplayMatch();
        ResetBricks();
    }
}
