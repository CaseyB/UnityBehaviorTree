using System.Collections.Generic;

public abstract class CompositeNode : Node
{
	protected List<Node> _nodes;

	public CompositeNode()
	{
		_nodes = new List<Node>();
	}

	public void AddNode(Node node)
	{
		_nodes.Add(node);
	}

	public override void Init() { /*  Don't force implmentation */ }
}
