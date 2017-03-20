using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Sprites;

public class SpriteShowAttribute : PropertyAttribute {

	public SpriteShowAttribute()
	{

	}
}

[CustomPropertyDrawer(typeof (SpriteShowAttribute))]
public class SpriteShowDrawer : PropertyDrawer 
{
	Sprite mySprite;

	SpriteShowAttribute CusSprite
	{
		get { return ((SpriteShowAttribute)attribute); }
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight (property, label) * 5;
	}

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		Texture2D myText = SpriteUtility.GetSpriteTexture(property.objectReferenceValue, false);
		GUI.Label(position, myText);
	}

}
