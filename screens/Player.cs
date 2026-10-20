using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Signal]
	public delegate void ColectCoinEventHandler();
	

    [Signal]
	public delegate void DeathEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	//var animated_sprite_2d = GetChild("PlayerAnimation");
	}
	private int X = 1;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnBodyEnterd(Node2D body)
	{
		
		if(body is StatikLaser)
		{
			
			EmitSignal(SignalName.Death);
		}

	}

	public void OnAreaEnterd(Area2D area){
		
		if(area.Name == "DeathArea"){
			EmitSignal(SignalName.Death);
		}
		if(area.Name == "CoinArea"){
			EmitSignal(SignalName.ColectCoin);
		}
	}

	public override void _PhysicsProcess(double delta){
		var mVelocity = Velocity;
		if (!IsOnFloor())
		{
			mVelocity += GetGravity() * (float)delta;
			
			//animated_sprite_2d.play("fly")
			
		}
		if(Input.IsActionPressed("Fly") ){
			X++;
			if(X>=15){
				X = 15;
			}
			mVelocity.Y=-1 *(float)Math.Exp(0.5*X) - 6;
			if(mVelocity.Y <= -400){
				mVelocity.Y = -400;
			}
			//GD.Print(mVelocity.Y);
		}else
		{
			X = 0;
		}
		
		Velocity = mVelocity;
		MoveAndSlide();
	}
}


