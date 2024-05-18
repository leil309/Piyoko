using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public int Speed { get; set; } = 300;

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Vector2.Zero;
		velocity.X = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		velocity.Y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}
		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		
	}
}
