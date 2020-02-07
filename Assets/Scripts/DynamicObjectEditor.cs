using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DynamicObject))]
public class DynamicObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DynamicObject dynamicObject = target as DynamicObject;

        dynamicObject.ChangeStateSprite = (GameObject)EditorGUILayout.ObjectField("ChangeState", dynamicObject.ChangeStateSprite, typeof(GameObject), true);

        dynamicObject.Property = (DynamicObject.InteractionProperty)EditorGUILayout.EnumPopup("Property", dynamicObject.Property);

        if (dynamicObject.Property == DynamicObject.InteractionProperty.AccessInteraction)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PrefixLabel("UnlockItem");
            dynamicObject.UnlockItem = EditorGUILayout.TextField(dynamicObject.UnlockItem);
            dynamicObject.AccessObject =
                (GameObject) EditorGUILayout.ObjectField("AccessObject", dynamicObject.AccessObject, typeof(GameObject), true);
            EditorGUI.indentLevel--;
        }
    }
}
