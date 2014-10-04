using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
	public TextAsset _behaviorScript;

	private Node _root;
	private Dictionary<System.String, System.Object> _dataStore;
	private bool _done;

	void Awake()
	{
		_dataStore = new Dictionary<System.String, System.Object>();
		_done = false;

		// Parse behavior script but for now hard code;
		Selector selector = new Selector ();
		selector.AddNode(new ThreeTicksThenFail());
		selector.AddNode(new ThreeTicksThenSucceed());
		_root = selector;
	}

	void Start()
	{
	}

	void Update()
	{
		if(_done) return;
		Node.Result result = _root.Process(_dataStore);
		if(result != Node.Result.RUNNING)
		{
			_done = true;
			Debug.Log("Result " + result);
		}
	}
}
