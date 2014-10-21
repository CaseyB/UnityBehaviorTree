using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

public class BehaviorEditor : EditorWindow
{
	private static Vector2 _scrollPosition;

	private List<Behavior> _builtIn;
	private List<Behavior> _userCreated;

	private const String USER_BEHAVIOR_PATH = "Assets/Scripts/Behaviors";
	private Type focusedTask;
	private Vector2 _mousePosition;

	private GUIStyle _myStyle;

	[MenuItem ("Window/Behavior Tree Editor")]
	public static void ShowWindow()
	{
		EditorWindow editor = EditorWindow.GetWindow(typeof(BehaviorEditor));
		editor.title = "Behavior Tree";
	}

	public void OnEnable()
	{
		_scrollPosition = Vector2.zero;
		_builtIn = new List<Behavior>();
		_userCreated = new List<Behavior>();

		String[] builtIn = AssetDatabase.FindAssets("t:monoscript", new string[] { "Assets/Standard Assets/BehaviorTree" });
		foreach(String asset in builtIn)
		{
			String path = AssetDatabase.GUIDToAssetPath(asset);
			Behavior b = new Behavior(path.Substring(USER_BEHAVIOR_PATH.Length + 1));
			_builtIn.Add(b);
		}

		OnProjectChange();
	}

	public void OnGUI()
	{
		_myStyle = new GUIStyle(GUI.skin.button);
		_myStyle.alignment = TextAnchor.MiddleCenter;

		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUIStyle.none);

		Vector2 position = Vector2.zero;

		foreach(Behavior behavior in _builtIn)
		{
			behavior.position = position;
			behavior.OnGUI(_myStyle);
			position.y += behavior.size.y;
		}

		foreach(Behavior behavior in _userCreated)
		{
			behavior.position = position;
			behavior.OnGUI(_myStyle);
			position.y += behavior.size.y;
		}

		GUILayout.EndScrollView();
	}

	public void OnProjectChange()
	{
		String[] userCreated = AssetDatabase.FindAssets("t:monoscript", new string[] { USER_BEHAVIOR_PATH });
		_userCreated = new List<Behavior>();

		foreach(String asset in userCreated)
		{
			String path = AssetDatabase.GUIDToAssetPath(asset);
			Behavior b = new Behavior(path.Substring(USER_BEHAVIOR_PATH.Length + 1));
			_userCreated.Add(b);
		}
		Repaint();
	}

	private void InitStyle()
	{

	}
}
