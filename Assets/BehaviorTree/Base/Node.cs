using UnityEngine;
using System.Collections;

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
