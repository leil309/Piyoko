using Godot;
using System;

public partial class Game : Node2D
{
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("esc"))
		{
			GetTree().ChangeSceneToFile("res://main.tscn");
		}
	}
}
