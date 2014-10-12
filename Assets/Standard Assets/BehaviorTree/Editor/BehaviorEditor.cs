using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

public class BehaviorEditor : EditorWindow
{
	private static Vector2 _scrollPosition;
	private static String[] _builtIn;

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
		_builtIn = AssetDatabase.FindAssets("t:monoscript", new string[] { "Assets/Standard Assets/BehaviorTree" });
	}

	public void OnGUI()
	{
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUIStyle.none);

		foreach(String asset in _builtIn)
		{
			EditorGUILayout.LabelField(AssetDatabase.GUIDToAssetPath(asset));
		}

		String[] userCreated = AssetDatabase.FindAssets("t:monoscript", new string[] { "Assets/Scripts/Behaviors" });

		foreach(String asset in userCreated)
		{
			EditorGUILayout.LabelField(AssetDatabase.GUIDToAssetPath(asset));
		}

		GUILayout.EndScrollView();
	}

	public void OnProjectChange()
	{
		String[] userCreated = AssetDatabase.FindAssets("t:monoscript", new string[] { USER_BEHAVIOR_PATH });

		foreach(String asset in userCreated)
		{
			String path = AssetDatabase.GUIDToAssetPath(asset);
			Behavior b = new Behavior(path.Substring(USER_BEHAVIOR_PATH.Length + 1));
		}
		Repaint();
	}
}
