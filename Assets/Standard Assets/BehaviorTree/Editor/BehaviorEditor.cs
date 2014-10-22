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
	private Rect _scrollViewPosition;
	private Rect _scrollArea;




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

		String[] skins = AssetDatabase.FindAssets("t:GuiSkin", new string[] { "Assets/Standard Assets/BehaviorTree" });
		if(skins.Length > 0)
		{
			String skinPath = AssetDatabase.GUIDToAssetPath(skins[0]);
			_mySkin = (GUISkin)AssetDatabase.LoadAssetAtPath(skinPath, typeof(GUISkin));
		}
		else
		{
			Debug.Log("Behavior GUISkin Not Found!");
		}

		OnProjectChange();
	}

	public void OnGUI()
	{
		GUI.skin = _mySkin;

		Vector2 behaviorSize = _builtIn[0].size;
		Vector2 windowSize = position.size;

		_scrollViewPosition = new Rect(windowSize.x - behaviorSize.x - 17, 0, behaviorSize.x + 17, windowSize.y);
		_scrollArea = new Rect(0, 0, behaviorSize.x, behaviorSize.y * (_builtIn.Count + _userCreated.Count));

		_scrollPosition = GUI.BeginScrollView(_scrollViewPosition, _scrollPosition, _scrollArea, false, true);

		Vector2 itemPos = Vector2.zero;
		foreach(Behavior behavior in _builtIn)
		{
			behavior.position = itemPos;
			itemPos.y += behavior.size.y;

			behavior.OnGUI();
		}

		foreach(Behavior behavior in _userCreated)
		{
			behavior.position = itemPos;
			itemPos.y += behavior.size.y;

			behavior.OnGUI(GUI.skin.customStyles[0]);
		}

		GUI.EndScrollView();
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
