using UnityEngine;
using System.Collections;

public class Bolt : MovingObject
{
	public static Bolt instance = null;				//Not needed at the moment
	// Use this for initialization
	protected override void Start ()
	{
		//It appears nothing happens in here because because nothing is created during the Initialization of the board
		base.Start();
	}

	public void MoveBolt (int xDir, int yDir)
	{
		//Calling Start() from MovingObject.cs to add the required things to the projectile
		base.Start();
		//print("In void MoveBolt");
		AttemptMove <Enemy> (xDir, yDir);			//Attempting to move the projectile
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		//print("In void AttemptMove Bolt Class");
		base.AttemptMove <T> (xDir, yDir);			//Actually attempting to move the projectile
	}

	protected override void OnCantMove <T> (T Component)
	{
		int filler = 0;								//Void OnCantMove needed for script construction
	}

	/*
	target()
	{
		//Replace "Player" with clicking on enemy location. Keep that in mind for the future!
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	*/
}
