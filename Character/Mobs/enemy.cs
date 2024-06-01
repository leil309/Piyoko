using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	[ExportCategory("Movement")]
	[Export]
	public int MaxSpeed { get; set; } = 30; //최대 속도
	[Export]
	public int Acceleration = 100; //가속 - 낮을수록 최대속도에 도달하기까지 오래걸림
	[Export]
	public int Friction { get; set; } = 0; //마찰 - 낮을수록 천천히 멈춤

	private CharacterBody2D Target;

	public override void _Ready()
	{
		Target = GetTree().GetFirstNodeInGroup("player") as CharacterBody2D;
	}

	public override void _PhysicsProcess(double delta)
	{
		float fDelta = (float)delta;
		_Movement(fDelta);
	}
	
	private void _Movement(float delta)
	{
		if (Target != null)
		{
			Velocity = Velocity.MoveToward(MaxSpeed * GlobalPosition.DirectionTo(Target.GlobalPosition), (Acceleration* (Acceleration/2)) * delta);
		}
		else
		{
			Velocity = Velocity.MoveToward(Vector2.Zero, (Friction* (Friction/2)) * delta);
		}
		MoveAndSlide();
	}
}
