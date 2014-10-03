using System;
using System.Collections.Generic;

public class Inverter : LeafDecorator
{
	public override Result Tick()
	{
		Result result = _leaf.Tick();

		switch(result)
		{
		case Result.SUCCESS: return Result.FAILURE;
		case Result.FAILURE: return Result.SUCCESS;
		default: return Result.RUNNING;
		}
	}
}
