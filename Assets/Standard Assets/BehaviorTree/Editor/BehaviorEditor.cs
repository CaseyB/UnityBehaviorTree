using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

public class BehaviorEditor : EditorWindow
{


	private List<Behavior> _builtIn;
	private List<Behavior> _userCreated;

	private const String USER_BEHAVIOR_PATH = "Assets/Scripts/Behaviors";
	private Type focusedTask;
	private Vector2 _mousePosition;

	private GUISkin _mySkin;


	private Vector2 _scrollPosition;
	private Vector2 _scrollArea;




	[MenuItem ("Window/Behavior Tree Editor")]
	public static void ShowWindow()
	{
		EditorWindow editor = EditorWindow.GetWindow(typeof(BehaviorEditor));
		editor.title = "Behavior Tree";
	}

	public void OnEnable()
	{
		_scrollPosition = Vector2.zero;
		_scrollArea = Vector2.zero;
		_builtIn = new List<Behavior>();
		_userCreated = new List<Behavior>();

		String[] builtIn = AssetDatabase.FindAssets("t:monoscript", new string[] { "Assets/Standard Assets/BehaviorTree" });
		foreach(String asset in builtIn)
		{
			String path = AssetDatabase.GUIDToAssetPath(asset);
			Behavior b = new Behavior(path.Substring(USER_BEHAVIOR_PATH.Length + 1));
			_builtIn.Add(b);
		}

		String[] skins = AssetDatabase.FindAssets("t:GuiSkin", new string[] { "Assets/Standard Assets/BehaviorTree" });
		String skinPath = AssetDatabase.GUIDToAssetPath(skins[0]);
		_mySkin = (GUISkin)AssetDatabase.LoadAssetAtPath(skinPath, typeof(GUISkin));

		OnProjectChange();
	}

	public void OnGUI()
	{
		switch(Event.current.type)
		{
		case EventType.Layout:
			LayoutView();
			break;
		case EventType.Repaint:
			DrawView();
			break;
		}
	}

	private void LayoutView()
	{
		_scrollArea = Vector2.zero;
		Vector2 position = Vector2.zero;
		_scrollArea = _builtIn[0].size;
		_scrollArea.y = _scrollArea.y * (_builtIn.Count + _userCreated.Count);

		GUILayout.BeginArea(new Rect(this.position.width - _scrollArea.x, 0, _scrollArea.x, this.position.height));
		_scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(_scrollArea.x), GUILayout.Height(_scrollArea.y));
		EditorGUILayout.BeginVertical();

		foreach(Behavior behavior in _builtIn)
		{
			behavior.position = position;
			position.y += behavior.size.y;

			_scrollArea.x = Mathf.Max(_scrollArea.x, behavior.size.x);
			_scrollArea.y = Mathf.Max(_scrollArea.y, position.y);
		}
		
		foreach(Behavior behavior in _userCreated)
		{
			behavior.position = position;
			position.y += behavior.size.y;

			_scrollArea.x = Mathf.Max(_scrollArea.x, behavior.size.x);
			_scrollArea.y = Mathf.Max(_scrollArea.y, position.y);
		}

		EditorGUILayout.EndVertical();
		EditorGUILayout.EndScrollView();
		GUILayout.EndArea();
	}

	private void DrawView()
	{
		GUI.skin = _mySkin;

		foreach(Behavior behavior in _builtIn)
		{
			behavior.OnGUI();
		}
		
		foreach(Behavior behavior in _userCreated)
		{
			behavior.OnGUI();
		}
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
