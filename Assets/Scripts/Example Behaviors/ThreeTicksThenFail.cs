using System.Collections.Generic;
using UnityEngine;

public class ThreeTicksThenFail : LeafNode
{
	private int _ticks;

	public override void Init()
	{
		_ticks = 0;
	}

	public override Result Process(Dictionary<System.String, System.Object> datastore)
	{
		_ticks++;
		Debug.Log("Tick " + _ticks);
		if(_ticks < 3) return Result.RUNNING;
		else return Result.FAILURE;
	}
}
