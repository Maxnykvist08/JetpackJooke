using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Signal]
	public delegate void ColectCoinEventHandler();
	

    [Signal]
	public delegate void DeathEventHandler();

	AnimatedSprite2D animatable;

	Timer deathtimer;

	bool isdead = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	 animatable = GetNode<AnimatedSprite2D>("PlayerAnimation");
	 deathtimer = GetNode<Timer>("DeathTimer");
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
			isdead = true;
			animatable.Play("death");
			deathtimer.Start();
		}

	}

	public void OnAreaEnterd(Area2D area){
		
		if(area.Name == "DeathArea"){
			isdead = true;
			animatable.Play("death");
			deathtimer.Start();
		}
		if(area.Name == "CoinArea"){
			EmitSignal(SignalName.ColectCoin);
		}
	}

	public void DeathTimerTimeout()
	{
		EmitSignal(SignalName.Death);
	}
	public override void _PhysicsProcess(double delta){
		if(isdead == false){
		var mVelocity = Velocity;
		if (!IsOnFloor())
		{
			mVelocity += GetGravity() * (float)delta;
			
			animatable.Play("fly");
			
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
		if (IsOnFloor())
		{
			animatable.Play("default");
		}
		
		Velocity = mVelocity;
		MoveAndSlide();
		}
	}
}


