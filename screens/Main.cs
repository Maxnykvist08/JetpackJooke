using Godot;
using System;

public partial class Main : Node2D
{
	public void LoadGame()
	{
		 if (!FileAccess.FileExists("user://savegame.save"))
    {
        return; // Error! We don't have a save to load.
    }

	using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);
	Bestscore =Convert.ToInt32(saveFile.GetLine());
	saveFile.Close();
	}
	[Export] 
	 PackedScene gamePackedScene{get;set;}
	
	public Button start;
	public Button exitgame;
	public CanvasLayer menu;

	Label bestscore;
	int Bestscore;

	Label scorelable;
	Label totelcoin;

	int totelcionint = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		LoadGame();
		start = GetNode<Button>("menu/Start");
		exitgame = GetNode<Button>("menu/Exitgame");
		menu = GetNode<CanvasLayer>("menu");
		bestscore = GetNode<Label>("menu/best score");
		scorelable = GetNode<Label>("menu/score");
		totelcoin = GetNode<Label>("menu/total coin");
		bestscore.Text = Bestscore.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnButtonPressed()
	{
		
	menu.Visible = false;
	var game = gamePackedScene.Instantiate<Game>();
	game.UppdateScore += OnGameUppdateScore;
	AddChild(game);

	}

	public void OnGameUppdateScore(int score, int coinscoleced)
	{

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

	public void ExitgamePressed()
	{
		SaveGame();
		GetTree().Quit();

	}

	public void SaveGame()
	{
		using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write);

		saveFile.StoreLine(Bestscore.ToString());
		saveFile.Close();
	}
}
