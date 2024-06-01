using Godot;

public partial class arm : Node2D
{
	private CharacterBody2D player;
	public override void _Ready()
	{
		player = GetParent<CharacterBody2D>();
	}

	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 pnt = GetGlobalMousePosition();
		if (player.GlobalPosition.X < GlobalPosition.X)
		{
			Scale = new Vector2(-1, 1);
		}
		LookAt(new Vector2(pnt.X, pnt.Y));
	}
}
