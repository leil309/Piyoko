extends CharacterBody2D

@export_category("Movement")
@export var max_speed = 75
@export var acceleration = 100
@export var friction = 100

var target: CharacterBody2D
var navigation_agent: NavigationAgent2D

func _ready():
	target = get_tree().get_first_node_in_group("player")
	navigation_agent = get_node("NavigationAgent2D")
	navigation_agent.max_speed = max_speed

func _physics_process(delta):
	_movement(delta)

func _movement(delta):
	var dir: Vector2 = to_local(navigation_agent.get_next_path_position()).normalized()
	if navigation_agent.is_navigation_finished():
		velocity = velocity.move_toward(Vector2.ZERO, friction * (friction/2) * delta)
	else:
		navigation_agent.velocity = velocity.move_toward(max_speed * dir, acceleration * (acceleration/2) * delta)

func _make_path():
	navigation_agent.target_position = target.global_position
	navigation_agent.get_next_path_position()

func _on_timer_timeout():
	_make_path()

func _on_navigation_agent_2d_velocity_computed(safe_velocity):
	if safe_velocity != Vector2.ZERO:
		velocity = safe_velocity
	move_and_slide()
