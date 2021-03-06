﻿using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(TransformValue)), CanEditMultipleObjects]
public class TransformValueEditor: Editor {

	private static TransformValue aux;

	public override void OnInspectorGUI () {
		aux = (TransformValue)target;
		base.OnInspectorGUI();
		GUILayout.BeginHorizontal();
		if ( GUILayout.Button("Save p1") ) {
			ApplyTransform(ref aux.p1,aux.name +" p1");
		}
		if ( GUILayout.Button("Save p2") ) {
			ApplyTransform(ref aux.p2,aux.name + " p2");
		}
		GUILayout.EndHorizontal();
	}

	void ApplyTransform (ref Transform p, string n) {
		if (p==null) {
			p = new GameObject(n).transform;
			p.transform.parent = aux.transform.parent;
		}	
		p.transform.position = aux.transform.position;
		p.transform.rotation = aux.transform.rotation;
		p.transform.localScale = aux.transform.localScale;	
	}

}
