using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
	public TextAsset _behaviorScript;

	private Node _root;
	private Dictionary<System.String, System.Object> _dataStore;

	void Awake()
	{
		_dataStore = new Dictionary<System.String, System.Object>();
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
		_root.Process(_dataStore);
	}
}
