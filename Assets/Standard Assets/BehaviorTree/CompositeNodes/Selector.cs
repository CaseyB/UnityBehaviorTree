using System;
using System.Collections.Generic;

public class Selector : CompositeNode
{
	private int _currentNode, _previousTick;

	public override void Init()
	{
		_currentNode = 0;
		_previousTick = -1;
	}
	
	public override Result Process(Dictionary<String, Object> datastore)
	{
		Result result = Result.RUNNING;
		
		for(/* _currentNode */; _currentNode < _nodes.Count; _currentNode++)
		{
			Node node = _nodes[_currentNode];

			// If this isn't the same node we were processing
			// last tick then we need to Init it.
			if(_currentNode != _previousTick) node.Init();

			result = node.Process(datastore);
			_previousTick = _currentNode;

			if(result == Result.FAILURE) continue;
			else break;
		}

		return result;
	}
}
