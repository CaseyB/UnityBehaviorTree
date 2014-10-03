using UnityEngine;
using System.Collections;

public abstract class LeafDecorator : Node
{
	protected LeafNode _leaf;
	public LeafNode Leaf { set { _leaf = value; } }
}
