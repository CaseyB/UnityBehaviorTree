using System;
using System.Collections.Generic;

public class Selector : CompositeNode
{
	public override Result Tick()
	{
		Result result = Result.FAILURE;

		foreach(Node node in _nodes)
		{
			result = node.Tick();
			if(result != Result.FAILURE) break;
		}

		return result;
	}
}
