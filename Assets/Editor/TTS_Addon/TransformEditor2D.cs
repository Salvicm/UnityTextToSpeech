using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CanEditMultipleObjects, CustomEditor(typeof(Transform))]
public class TransformEditor2D : Editor
{

    private void  OnFocused()
    {

    }


    public void OnSceneGUI()
    {
        TextField textField = new TextField();
        
    }



}
