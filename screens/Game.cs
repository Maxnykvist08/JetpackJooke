using Godot;
using System;

public partial class Game : Node2D
{
	Marker2D spwanpoint;
	CharacterBody2D Player;
	Label coinlabel;
	Label scorelable;
	Vector2 playerpos;
	[Export] 
	 PackedScene stlaserPackedScene{get;set;}

	 [Export] 
	 PackedScene[] coinsPacedScenes;

	 [Export]
	 PackedScene rocketPackedScene{get;set;}

	 
    [Signal]
	public delegate void UppdateScoreEventHandler(int score, int coins);

	 public int coinscoleced = 0;
	 public int score= 0;
	 public int X =0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spwanpoint = GetNode<Marker2D>("EnemySpwanMarker");
		Player = GetNode<CharacterBody2D>("Player");
		coinlabel = GetNode<Label>("CanvasLayer/coins");
		scorelable = GetNode<Label>("CanvasLayer/score");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	 playerpos = Player.Position;
	
	}

	public void OnPlayerDeath(){


		 QueueFree();
		 EmitSignal(SignalName.UppdateScore, score, coinscoleced);

	}

	public void OnSpwanerTimeOut(){
		var stlaser = stlaserPackedScene.Instantiate<StatikLaser>();
		var coins = coinsPacedScenes[GD.RandRange(0,coinsPacedScenes.Length-1)].Instantiate<Node2D>();
		var rocket = rocketPackedScene.Instantiate<Rocket>();

		score++;
		scorelable.Text = "Score " + score.ToString();

		Vector2 mposition = spwanpoint.Position;
		Random rand = new Random();
		int chouse = rand.Next(4);
		switch (chouse)
		{
			case <1:
			int offset = (rand.Next(20)-10)*20;
			mposition.Y += offset;
			stlaser.Position = mposition;

			float rotation = (float)((rand.Next(90))*180/Math.PI);
			stlaser.Rotation = rotation;

			AddChild(stlaser);
		break;
			case 2:
			offset = (rand.Next(20)-10)*20;
			mposition.Y += offset;
			coins.Position = mposition;
			AddChild(coins);
		break;
			case 3:

				mposition.Y = playerpos.Y;
				rocket.Position = mposition;
				AddChild(rocket);
			break;


			default:
		 offset = (rand.Next(20)-10)*20;
		mposition.Y += offset;
		stlaser.Position = mposition;

		rotation = (float)((rand.Next(90))*180/Math.PI);
		stlaser.Rotation = rotation;

		AddChild(stlaser);
		break;
		}
		
	}

	public void OnCoinColect(){

		coinscoleced++;
		coinlabel.Text = "Coins " + coinscoleced.ToString();
		
	}
	
}
