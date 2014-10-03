using System;
using System.Collections.Generic;

public class Succeeder : LeafDecorator
{
	public override Result Tick()
	{
		_leaf.Tick();
		return Result.SUCCESS;
	}
}
