using Godot;
using System;

public partial class SpecialMultiplayerMatch : Match
{
    public void ReplayMatch()
    {
        base.ReplayMatch();
        ResetBricks();
    }
}
