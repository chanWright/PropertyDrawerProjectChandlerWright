using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VectorScaleAttribute : PropertyAttribute {

    public VectorScaleAttribute()
    {

    }
}

[CustomPropertyDrawer(typeof(VectorScaleAttribute))]
public class VectorScaleDrawer : PropertyDrawer
{

    VectorScaleAttribute CusObj
    {
        get { return ((VectorScaleAttribute)attribute); }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 5;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GameObject myObj = (GameObject)property.objectReferenceValue;

        Rect drawPos = position;
        drawPos.height = drawPos.height / 5;
        EditorGUI.PropertyField(drawPos, property, label, true);
        if (myObj != null)
        {
            drawPos.y += drawPos.height;
            float myFloat1 = myObj.transform.localScale.x;
            float myFloat2 = myObj.transform.localScale.y;
            float myFloat3 = myObj.transform.localScale.z;
            myFloat1 = EditorGUI.Slider(drawPos, "Scale X", myFloat1, 1, 10);
            drawPos.y += drawPos.height;
			myFloat2 = EditorGUI.Slider(drawPos, "Scale Y", myFloat2, 1, 10);
            drawPos.y += drawPos.height;
			myFloat3 = EditorGUI.Slider(drawPos, "Scale Z", myFloat3, 1, 10);
            myObj.transform.localScale = new Vector3(myFloat1, myFloat2, myFloat3);

            drawPos.y += drawPos.height;
            myObj.transform.position = EditorGUI.Vector3Field(drawPos, "Position", myObj.transform.position);
        }
        //base.OnGUI(position, property, label);
    }
}
