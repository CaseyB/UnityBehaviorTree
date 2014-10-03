using UnityEngine;
using System.Collections;

public class Succeeder : LeafDecorator
{
	public override Result Tick()
	{
		_leaf.Tick();
		return Result.SUCCESS;
	}
}
