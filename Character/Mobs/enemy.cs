using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	[ExportCategory("Movement")]
	[Export]
	public int MaxSpeed { get; set; } = 75; //최대 속도
	[Export]
	public int Acceleration = 100; //가속 - 낮을수록 최대속도에 도달하기까지 오래걸림
	[Export]
	public int Friction { get; set; } = 100; //마찰 - 낮을수록 천천히 멈춤

	private Vector2 _avoidVelocity;
	private Vector2 _velocity = Vector2.Zero;

	private CharacterBody2D _target;
	private NavigationAgent2D _navigationAgent2D;
	
	public override void _Ready()
	{
		_target = GetTree().GetFirstNodeInGroup("player") as CharacterBody2D;
		_navigationAgent2D = GetNode<NavigationAgent2D>("NavigationAgent2D");
		_navigationAgent2D.MaxSpeed = MaxSpeed;
	}

	public override void _PhysicsProcess(double delta)
	{
		_Movement((float)delta);
	}
	
	private void _Movement(float delta)
	{
		Vector2 dir = ToLocal(_navigationAgent2D.GetNextPathPosition()).Normalized();
		if (_navigationAgent2D.IsNavigationFinished())
		{
			Velocity = Velocity.MoveToward(Vector2.Zero, Friction * (Friction/2f) * delta);
		}
		else
		{
			_navigationAgent2D.Velocity = Velocity.MoveToward(MaxSpeed * dir, Acceleration * (Acceleration/2f) * delta);
		}
		
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
	
	private void _on_navigation_agent_2d_velocity_computed(Vector2 safeVelocity)
	{
		if (safeVelocity != Vector2.Zero)
		{
			Velocity = safeVelocity;
		}
		MoveAndSlide();
	}
}
