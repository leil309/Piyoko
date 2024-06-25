extends Node2D

var player: CharacterBody2D

func _ready():
	player = get_parent()

func _process(delta):
	pass

func _physics_process(delta):
	var pnt: Vector2 = get_global_mouse_position()
	
	if player.global_position.x < global_position.x:
		scale = Vector2(-1, 1)
	look_at(Vector2(pnt.x, pnt.y))
