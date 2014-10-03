using UnityEngine;
using System.Collections;

public class Sequence : CompositeNode
{
	public override Result Tick()
	{
		Result result = Result.SUCCESS;

		foreach(Node node in _nodes)
		{
			result = node.Tick();
			if(result != Result.SUCCESS) break;
		}

		return result;
	}
}
