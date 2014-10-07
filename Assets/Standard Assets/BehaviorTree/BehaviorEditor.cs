using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

public class BehaviorEditor : EditorWindow
{
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;

	[MenuItem ("Window/Behavior Tree Editor")]
	public static void ShowWindow()
	{
		EditorWindow editor = EditorWindow.GetWindow(typeof(BehaviorEditor));
		editor.title = "Behavior Tree";
	}

	void OnGUI()
	{
		GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
		GUILayout.BeginScrollView(Vector2.zero, GUIStyle.none);
		GUILayout.BeginArea(new Rect(0, 0, 500, 500));


		myString = EditorGUILayout.TextField ("Text Field", myString);
		groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
		GUILayout.EndArea();
		GUILayout.EndScrollView();
	}
}
