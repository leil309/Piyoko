using Godot;
using System;

public partial class Main : Control
{
	public override void _Ready()
	{
		GetNode<Button>("ButtonLayoutContainer/HBoxContainer/StartButton").GrabFocus();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	
	private void _on_start_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/game.tscn");
	}
	
	private void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
	
	private void _on_start_button_mouse_entered()
	{
		GetNode<Button>("ButtonLayoutContainer/HBoxContainer/StartButton").GrabFocus();
	}
	
	private void _on_options_button_mouse_entered()
	{
		GetNode<Button>("ButtonLayoutContainer/HBoxContainer/OptionsButton").GrabFocus();
	}
	
	private void _on_quit_button_mouse_entered()
	{
		GetNode<Button>("ButtonLayoutContainer/HBoxContainer/QuitButton").GrabFocus();
	}
}
