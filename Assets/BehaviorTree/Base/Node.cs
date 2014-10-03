using System;
using System.Collections.Generic;

public abstract class Node
{
	public enum Result
	{
		SUCCESS,
		FAILURE,
		RUNNING
	}

	public abstract Result Tick();
}
