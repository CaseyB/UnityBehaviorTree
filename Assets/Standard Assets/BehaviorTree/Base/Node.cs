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

	public abstract void Init();
	public abstract Result Process(Dictionary<String, Object> datastore);
}