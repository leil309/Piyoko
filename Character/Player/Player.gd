extends CharacterBody2D

@export_category("Movement")
@export var max_speed = 125
@export var acceleration = 100
@export var friction = 100

var animation_player: AnimationPlayer
var animation_tree: AnimationTree
var state_machine: AnimationNodeStateMachinePlayback

var arm: PackedScene = load("res://Character/Player/arm.tscn")

func _ready():
	var inst_arm = arm.instantiate()
	var inst_arm2 = arm.instantiate()
	inst_arm.position = Vector2(-15, -4)
	add_child(inst_arm)
	inst_arm2.position = Vector2(15, -4)
	add_child(inst_arm2)
	
	animation_player = get_node("Body/AnimationPlayer")
	animation_tree = get_node("Body/AnimationTree")
	state_machine = animation_tree.get("parameters/playback")

func _physics_process(delta):
	_movement(delta)

func _movement(delta):
	var input_vector: Vector2 = Vector2.ZERO
	input_vector.x = Input.get_action_strength("move_right") - Input.get_action_strength("move_left")
	input_vector.y = Input.get_action_strength("move_down") - Input.get_action_strength("move_up")
	input_vector = input_vector.normalized()
	
	if input_vector != Vector2.ZERO:
		state_machine.travel("Run")
		animation_tree.set("parameters/Idle/blend_position", input_vector)
		animation_tree.set("parameters/Run/blend_position", input_vector)
		velocity = velocity.move_toward(max_speed * input_vector, acceleration * (acceleration/2) * delta)
	else:
		state_machine.travel("Idle")
		velocity = velocity.move_toward(Vector2.ZERO, friction * (friction/2) * delta)
	move_and_slide()
