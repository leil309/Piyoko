using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportCategory("Movement")]
	[Export]
	public int MaxSpeed { get; set; } = 75; //최대 속도
	[Export]
	public int Acceleration = 100; //가속 - 낮을수록 최대속도에 도달하기까지 오래걸림
	[Export]
	public int Friction { get; set; } = 100; //마찰 - 낮을수록 천천히 멈춤

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		float fDelta = (float)delta;
		Vector2 inputVector = Vector2.Zero;
		inputVector.X = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		inputVector.Y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
		inputVector = inputVector.Normalized();

		if (inputVector != Vector2.Zero)
		{
			Velocity = Velocity.MoveToward(MaxSpeed * inputVector, (Acceleration* (Acceleration/2)) * fDelta);
		}
		else
		{
			Velocity = Velocity.MoveToward(Vector2.Zero, (Friction* (Friction/2)) * fDelta);
		}
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		
	}
}