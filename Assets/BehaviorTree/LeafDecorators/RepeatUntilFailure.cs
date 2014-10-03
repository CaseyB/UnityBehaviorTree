using System;
using System.Collections.Generic;

public class RepeatUntilFailure : LeafDecorator
{
	public override Result Tick()
	{
		Result result = _leaf.Tick();
		if(result == Result.FAILURE) return Result.SUCCESS;
		else return Result.RUNNING;
	}
}
