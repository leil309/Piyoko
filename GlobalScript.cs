using System;
using Godot;

public partial class GlobalScript : Node
{
	private DisplayServer.WindowMode _previousWindowMode;
	
	public override void _Ready()
	{
		// 시작 시 현재 창 모드를 저장합니다.
		_previousWindowMode = DisplayServer.WindowGetMode();
	}
	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed("fullscreen_toggle"))
		{
			ToggleFullScreen();
		}
	}

	private void ToggleFullScreen()
	{
		var currentMode = DisplayServer.WindowGetMode();
		
		if (currentMode == DisplayServer.WindowMode.Fullscreen)
		{
			DisplayServer.WindowSetMode(_previousWindowMode);
			// 최대창모드에서 창을 드래그하여 위치변경하여 창모드로 전환후, 다시 전체화면 -> 창모드 전환시 테두리 사라지는 버그 방지
			DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, false, 0);
		}
		else
		{
			_previousWindowMode = currentMode;
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
		}
	}
}
