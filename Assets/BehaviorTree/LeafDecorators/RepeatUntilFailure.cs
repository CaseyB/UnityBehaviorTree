using UnityEngine;
using System.Collections;

public class RepeatUntilFailure : LeafDecorator
{
	public override Result Tick()
	{
		Result result = _leaf.Tick();
		if(result == Result.FAILURE) return Result.SUCCESS;
		else return Result.RUNNING;
	}
}
