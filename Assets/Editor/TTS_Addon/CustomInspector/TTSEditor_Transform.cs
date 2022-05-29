using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CanEditMultipleObjects, CustomEditor(typeof(Transform))]
public class TTSEditor_Transform : Editor
{
    Transform transform;
    Vector3Field rotationField;
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();

        transform = target as Transform;
        SerializedObject serializedObject = new SerializedObject(transform);


        SerializedProperty posProp = serializedObject.FindProperty("m_LocalPosition");
        SerializedProperty rotProp = serializedObject.FindProperty("m_LocalRotation");
        SerializedProperty scaleProp = serializedObject.FindProperty("m_LocalScale");

        Vector3Field position = new Vector3Field("Position");
        position.BindProperty(posProp);
        root.Add(position);

        rotationField = new Vector3Field("Rotation");
        //rotationField.BindProperty(rotProp);
        root.Add(rotationField);
        rotationField.value = TransformUtils.GetInspectorRotation(transform);
        rotationField.RegisterValueChangedCallback(eventData =>
        {
            Undo.RecordObject(transform, "ChangeRotation");
            TransformUtils.SetInspectorRotation(transform, eventData.newValue);
        });

        Vector3Field scale = new Vector3Field("Scale");
        scale.BindProperty(scaleProp);
        root.Add(scale);
        scale.RegisterCallback<FocusInEvent>(OnFocusInEvent);
        rotationField.RegisterCallback<FocusInEvent>(OnFocusInEvent);
        position.RegisterCallback<FocusInEvent>(OnFocusInEvent);

        return root;
    }
    private void OnSceneGUI()
    {
        rotationField.SetValueWithoutNotify(TransformUtils.GetInspectorRotation(transform));
    }
    private void OnFocusInEvent(FocusInEvent evt)
    {
        Vector3Field vector3Field = evt.target as Vector3Field;
        if (vector3Field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = vector3Field.label;
        else return;
        InspectorTabController.currentValueAsString = "X = " +  vector3Field.value.x + ", Y = " + vector3Field.value.y + ", Z = " + vector3Field.value.z;
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }
}
