using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	[ExportCategory("Movement")]
	[Export]
	public int MaxSpeed { get; set; } = 100; //최대 속도
	[Export]
	public int Acceleration = 100; //가속 - 낮을수록 최대속도에 도달하기까지 오래걸림
	[Export]
	public int Friction { get; set; } = 10; //마찰 - 낮을수록 천천히 멈춤
	
	private CharacterBody2D _target;
	private NavigationAgent2D _navigationAgent2D;
	
	public override void _Ready()
	{
		_target = GetTree().GetFirstNodeInGroup("player") as CharacterBody2D;
		_navigationAgent2D = GetNode<NavigationAgent2D>("NavigationAgent2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		_Movement((float)delta);
	}
	
	private void _Movement(float delta)
	{
		Vector2 dir = ToLocal(_navigationAgent2D.GetNextPathPosition()).Normalized();
		Velocity = Velocity.MoveToward(MaxSpeed * dir, (Acceleration* (Acceleration/2)) * delta);
		MoveAndSlide();
	}

	private void _MakePath()
	{
		_navigationAgent2D.TargetPosition = _target.GlobalPosition;
		_navigationAgent2D.GetNextPathPosition();
	}
	
	private void _on_timer_timeout()
	{
		_MakePath();
	}
	
	private void _on_navigation_agent_2d_velocity_computed(Vector2 safe_velocity)
	{
		Velocity = safe_velocity;
	}
}
