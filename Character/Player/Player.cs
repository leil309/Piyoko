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

	private AnimationPlayer _animationPlayer;
	private AnimationTree _animationTree;
	private AnimationNodeStateMachinePlayback _stateMachine;

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("Smoothing2D/AnimationPlayer");
		_animationTree = GetNode<AnimationTree>("Smoothing2D/AnimationTree");
		_stateMachine = (AnimationNodeStateMachinePlayback)_animationTree.Get("parameters/playback");
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
			_stateMachine.Travel("Run");
			_animationTree.Set("parameters/Idle/blend_position", inputVector);
			_animationTree.Set("parameters/Run/blend_position", inputVector);
			Velocity = Velocity.MoveToward(MaxSpeed * inputVector, (Acceleration* (Acceleration/2)) * fDelta);
		}
		else
		{
			_stateMachine.Travel("Idle");
			Velocity = Velocity.MoveToward(Vector2.Zero, (Friction* (Friction/2)) * fDelta);
		}
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		
	}
}
