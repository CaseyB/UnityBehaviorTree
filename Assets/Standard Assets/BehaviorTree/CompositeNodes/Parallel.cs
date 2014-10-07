using System;
using System.Collections.Generic;

/// <summary>
/// Parallel.
/// Process all child nodes until one returns FAILURE, then fail this node
/// </summary>
public class Parallel : CompositeNode
{
	private int _currentNode, _previousTick;
	
	public override void Init()
	{
		foreach(Node node in _nodes)
		{
			node.Init();
		}
	}
	
	public override Result Process(Dictionary<String, Object> datastore)
	{
		foreach(Node node in _nodes)
		{
			if(node.Process(datastore) == Result.FAILURE) return Result.FAILURE;
		}

		return Result.RUNNING;
	}
}
