using Godot;
using System;


	
public partial class Camera2D : Godot.Camera2D
{
	[ExportCategory("Follow Character")]
	[Export]
	private NodePath _targetPath;
	
	private Node2D _target;
	public override void _Ready()
	{
		_target = GetNodeOrNull<Node2D>(_targetPath);
	}

	public override void _Process(double delta)
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_target != null)
		{
			GlobalPosition = _target.GlobalPosition;
		}
	}
}
