using System;
using System.Collections.Generic;

public class Sequence : CompositeNode
{
	public override Result Process(Dictionary<String, Object> datastore)
	{
		Result result = Result.SUCCESS;

		foreach(Node node in _nodes)
		{
			node.Init();
			result = node.Process(datastore);
			if(result != Result.SUCCESS) break;
		}

		return result;
	}
}
