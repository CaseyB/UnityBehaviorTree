using System;
using System.Collections.Generic;

public class RepeatUntilFailure : NodeDecorator
{
	public override Result Process(Dictionary<String, Object> datastore)
	{
		Result result = _node.Process(datastore);
		if(result == Result.FAILURE) return Result.SUCCESS;
		else return Result.RUNNING;
	}
}
