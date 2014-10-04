using System;
using System.Collections.Generic;

public class Succeeder : NodeDecorator
{
	public override Result Process(Dictionary<String, Object> datastore)
	{
		_node.Process(datastore);
		return Result.SUCCESS;
	}
}
