using UnityEditor;
using UnityEngine;
using System;

public class Behavior
{
	private String _group;
	public String group { get { return _group; } }

	private String _name;
	public String name { get { return _name; } }

	private Rect _rect;
	public Rect rect { get { return _rect; } set { _rect = value; } }
	public Vector2 position { get { return _rect.position; } set { _rect.position = value; } }
	public Vector2 size { get { return _rect.size; } set { _rect.size = value; } }

	/// <summary>
	/// Initializes a new instance of the <see cref="Behavior"/> class.
	/// </summary>
	/// <param name="scriptPath">Path of the script inside of the Assets/Scripts/Behaviors folder.</param>
	public Behavior(String scriptPath)
	{
		int lastSlash = scriptPath.LastIndexOf("/");

		if(lastSlash >= 0)
		{
			_group = scriptPath.Substring(0, lastSlash);
			_name = scriptPath.Substring(lastSlash + 1);
		}
		else
		{
			_group = "";
			_name = scriptPath;
		}

		_name = _name.Replace(".cs", "");
		_name = _name.Replace(".js", "");
		_name = _name.Replace(".boo", "");

		_rect = new Rect(0, 0, 150, 50);
	}

	public void OnGUI(GUIStyle style)
	{
		GUI.Box(_rect, _name, style);
	}
}
