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
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUIStyle.none);

		foreach(Behavior behavior in _builtIn)
		{
			EditorGUILayout.LabelField(AssetDatabase.GUIDToAssetPath(asset));
		}

		foreach(Behavior behavior in _userCreated)
		{
			EditorGUILayout.LabelField(AssetDatabase.GUIDToAssetPath(asset));
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
}
