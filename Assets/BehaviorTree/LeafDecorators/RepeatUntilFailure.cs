using System;
using System.Collections.Generic;

public class RepeatUntilFailure : LeafDecorator
{
	public override Result Process(Dictionary<String, Object> datastore)
	{
		Result result = _leaf.Process(datastore);
		if(result == Result.FAILURE) return Result.SUCCESS;
		else return Result.RUNNING;
	}
}
