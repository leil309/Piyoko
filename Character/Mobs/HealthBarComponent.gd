extends ProgressBar

@export var health_component: HealthComponent

# Called when the node enters the scene tree for the first time.
func _ready():
	max_value = health_component.MAX_HEALTH
	value = health_component.health

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	visible = value < max_value
	value = health_component.health
