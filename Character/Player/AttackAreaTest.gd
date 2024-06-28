extends Area2D

var attack_damage = 2
var knockback_force = 100.0

func _on_hitbox_area_entered(area):
	if area.has_method("damage"):
		print("ATTACK!")
		var attack = Attack.new()
		attack.attack_damage = attack_damage
		attack.knockback_force = knockback_force
		attack.attack_position = global_position
		area.damage(attack)

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _physics_process(delta):
	pass

func _on_timer_timeout():
	var areas = get_overlapping_areas()
	for x in areas:
		_on_hitbox_area_entered(x)
