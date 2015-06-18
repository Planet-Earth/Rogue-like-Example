using UnityEngine;
using System.Collections;

public class Bolt : MovingObject
{

	public float speed;

	// Use this for initialization
	protected override void Start ()
	{
		base.Start();
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		base.AttemptMove <T> (xDir, yDir);
	}

	protected override void OnCantMove <T> (T Component)
	{
		int filler = 0;
	}

	/*
	target()
	{
		//Replace "Player" with clicking on enemy location. Keep that in mind for the future!
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	*/
}
