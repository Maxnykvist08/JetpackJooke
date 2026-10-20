using Godot;
using System;

public partial class Main : Node2D
{

	[Export] 
	 PackedScene gamePackedScene{get;set;}
	
	public Button button;
	public CanvasLayer menu;

	Label bestscore;
	int Bestscore= 0;

	Label scorelable;
	Label totelcoin;

	int totelcionint = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		button = GetNode<Button>("menu/Button");
		menu = GetNode<CanvasLayer>("menu");
		bestscore = GetNode<Label>("menu/best score");
		scorelable = GetNode<Label>("menu/score");
		totelcoin = GetNode<Label>("menu/total coin");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnButtonPressed()
	{
		GD.Print("fabfaefebf");
	menu.Visible = false;
	var game = gamePackedScene.Instantiate<Game>();
	game.UppdateScore += OnGameUppdateScore;
	AddChild(game);

	}

	public void OnGameUppdateScore(int score, int coinscoleced)
	{
    GD.Print("fabfaefebf");
		if(score > Bestscore)
		{
			Bestscore = score;
		bestscore.Text = score.ToString();	
		}
		scorelable.Text = score.ToString();
		totelcionint += coinscoleced;
		totelcoin.Text = totelcionint.ToString();

		menu.Visible = true;
	}
}
