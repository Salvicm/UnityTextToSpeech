using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CanEditMultipleObjects, CustomEditor(typeof(Transform))]
public class TTSEditor_Transform : Editor
{

    public override VisualElement CreateInspectorGUI()
    {

        VisualElement myInspector = new VisualElement();
        myInspector = base.CreateInspectorGUI();
        Debug.Log(myInspector == null);
        //myInspector[0].RegisterCallback<FocusInEvent>(OnFocusInEvent);
        /*for(int i = 0; i < myInspector.childCount; i++)
        {
            myInspector[i].RegisterCallback<FocusInEvent>(OnFocusInEvent);
        }*/
        TextField textField = new TextField();
        textField.name = "Test text field";
        textField.value = "Test";
        textField.label = "Test label";

        myInspector.Add(textField);
        //TextField textField2 = new TextField();
        //textField2.name = "Test text field";
        //textField2.value = "Test";
        //textField2.label = "Test label";
        //myInspector.Add(textField2);

        //textField.RegisterCallback<FocusInEvent>(OnFocusInEvent);
        //textField2.RegisterCallback<FocusInEvent>(OnFocusInEvent);

        return myInspector;
    }

    private void OnFocusInEvent(FocusInEvent evt)
    {
        var textField = evt.target as TextField;
        Debug.Log("Testing with field: " + textField.name);
    }

}
