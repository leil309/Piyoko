extends Camera2D

@export_category("Follow Character")
@export var target_path: NodePath

var target

# Called when the node enters the scene tree for the first time.
func _ready():
	target = get_node(target_path)
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _physics_process(delta):
	if target != null:
		global_position = target.global_position
