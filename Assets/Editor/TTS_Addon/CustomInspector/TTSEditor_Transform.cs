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
        scale.RegisterCallback<ChangeEvent<Vector3>>(ChangeEventColor);
        rotationField.RegisterCallback<FocusInEvent>(OnFocusInEvent);
        rotationField.RegisterCallback<ChangeEvent<Vector3>>(ChangeEventColor);
        position.RegisterCallback<FocusInEvent>(OnFocusInEvent);
        position.RegisterCallback<ChangeEvent<Vector3>>(ChangeEventColor);

        return root;
    }
    private void OnSceneGUI()
    {
        try
        {
            rotationField.SetValueWithoutNotify(TransformUtils.GetInspectorRotation(transform));
        }
        catch (Exception)
        {
            // This is no error
        }
    }
    private void OnFocusInEvent(FocusInEvent evt)
    {
        InspectorTabController.currentElementSelected = "Transform";

        Vector3Field vector3Field = evt.target as Vector3Field;
        InspectorTabController.currentValueAsString = "X = " +  vector3Field.value.x + ", Y = " + vector3Field.value.y + 
            ", Z = " + vector3Field.value.z;InspectorTabController.currentValueAsString = "X = " +  vector3Field.value.x + 
            ", Y = " + vector3Field.value.y + ", Z = " + vector3Field.value.z;
        if (vector3Field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = vector3Field.label;
        else return;
        WindowsVoice.silence();
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }
  

    private void ChangeEventColor(ChangeEvent<Vector3> evt)
    {
        Vector3Field vector3Field = evt.target as Vector3Field;
        InspectorTabController.currentValueAsString = "X = " +  vector3Field.value.x + ", Y = " + vector3Field.value.y + 
            ", Z = " + vector3Field.value.z;InspectorTabController.currentValueAsString = "X = " +  vector3Field.value.x + 
            ", Y = " + vector3Field.value.y + ", Z = " + vector3Field.value.z;
    }
}
