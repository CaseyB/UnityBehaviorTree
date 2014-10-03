using System;
using System.Collections.Generic;

public class Succeeder : LeafDecorator
{
	public override Result Process(Dictionary<String, Object> datastore)
	{
		_leaf.Process(datastore);
		return Result.SUCCESS;
	}
}
