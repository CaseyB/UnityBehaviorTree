public abstract class LeafDecorator : LeafNode
{
	protected LeafNode _leaf;
	public LeafNode Leaf { set { _leaf = value; } }

	public override void Init()
	{
		_leaf.Init();
	}
}
