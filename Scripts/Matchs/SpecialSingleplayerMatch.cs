using Godot;
using System;
using System.Diagnostics;

public partial class SpecialSingleplayerMatch : Match
{
    public new void OnMatchInterfaceReplayButtonPressed()
    {
        ReplaySpecialSinglePlayerMatch();
    }
    
    public void ReplaySpecialSinglePlayerMatch()
    {
        Trace.WriteLine("Replace match specialsinglematch");
        ReplayMatch();
        ResetBricks();
    }
}
