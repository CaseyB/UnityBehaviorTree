using System;
using System.Collections.Generic;

public class Interrupter : NodeDecorator
{
	public override Result Process(Dictionary<String, Object> datastore)
	{
		// I'm not sure we need to implement this since we'll already call
		// our child's Init in our own init.

		return Result.SUCCESS;
	}
}
