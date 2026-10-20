using Godot;
using System;

public partial class StatikLaser : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		var mposition = Position;
		mposition.X += -200 * (float)delta;

		Position =mposition;
	}
}
