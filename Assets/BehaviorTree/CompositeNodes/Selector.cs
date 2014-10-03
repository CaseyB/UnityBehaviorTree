using System;
using System.Collections.Generic;

public class Selector : CompositeNode
{
	public override Result Process(Dictionary<String, Object> datastore)
	{
		Result result = Result.FAILURE;

		foreach(Node node in _nodes)
		{
			result = node.Process(datastore);
			if(result != Result.FAILURE) break;
		}

		return result;
	}
}
