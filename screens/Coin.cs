using Godot;
using System;

public partial class Coin : Node2D
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnCoinEnterd(Node2D body){
		if (body.Name == "Player"){
			QueueFree();
		}
		
		
	}

	public override void _PhysicsProcess(double delta)
	{
		var mposition = Position;
		mposition.X += -200 * (float)delta;

		Position =mposition;
	}
}
