using System;
using System.Collections.Generic;

public class Inverter : NodeDecorator
{
	public override Result Process(Dictionary<String, Object> datastore)
	{
		Result result = _node.Process(datastore);

		switch(result)
		{
		case Result.SUCCESS: return Result.FAILURE;
		case Result.FAILURE: return Result.SUCCESS;
		default: return Result.RUNNING;
		}
	}
}
