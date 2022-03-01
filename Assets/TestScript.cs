using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
static class TestScript
{

    static EditorWindow previousWindow;
    static EditorWindow currentWindow;
    static string nameOfCurrentWindow = "";
    static TestScript()
    {
        EditorApplication.update += Update;
    }
    




    static void Update()
    {
        test();
    }
    static void test()
    {
        currentWindow = EditorWindow.focusedWindow;
        if (currentWindow != previousWindow)
        {
            nameOfCurrentWindow = currentWindow.GetType().Name;

            switch (nameOfCurrentWindow)
            {
               case NameHolder.SceneHierarchy:  
                    Debug.Log("You have opened: " + NameHolder.SceneHierarchy);
                    break;
               case NameHolder.SceneView:    
                    Debug.Log("You have opened: " + NameHolder.SceneView);
                    break;
               case NameHolder.GameView:     
                    Debug.Log("You have opened: " + NameHolder.GameView);
                    break;
               case NameHolder.Console:        
                    Debug.Log("You have opened: " + NameHolder.Console);
                    break;
               case NameHolder.Inspector:       
                    Debug.Log("You have opened: " + NameHolder.Inspector);
                    break;
                case NameHolder.AssetStore:
                    Debug.Log("You have opened: " + NameHolder.AssetStore);
                    break;
                default:
                    Debug.Log(nameOfCurrentWindow);
                    break;
            }
        }
        
        
        // Abrir
        if (false)
        { 
            // I can use this when i want to get all currently open windows
            EditorWindow[] allWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            foreach (var item in allWindows)
            {
                Debug.Log(item);
            }
            var editorAsm = typeof(Editor).Assembly;
            Type inspWndType = editorAsm.GetType("UnityEditor.InspectorWindow");
            EditorWindow.GetWindow(inspWndType, true, "My Empty Window");
        }
        // TODO 
        /* Close all tabs except basic and set layout 
         * Autoclose tabs?
         * ** Set Autoclose optional
         * Get all params from the window and navigate
         * Has unsaved stuff
         */
        if (false)
        {
            var editorAsm = typeof(Editor).Assembly;
            Type inspWndType = editorAsm.GetType("UnityEditor.SceneHierarchyWindow");
            EditorWindow.GetWindow(inspWndType, true, "My Empty Window");
        }
        previousWindow = currentWindow;
    }

 
 
   



    //public void ShowInspectorEditorWindow()
    //{
    //    string inspectorWindowTypeName = "UnityEditor.InspectorWindow";
    //    ShowEditorWindowWithTypeName(inspectorWindowTypeName);
    //}

    //public void ShowSceneEditorWindow()
    //{
    //    string sceneWindowTypeName = "UnityEditor.SceneView";
    //    ShowEditorWindowWithTypeName(sceneWindowTypeName);
    //}

    //public void ShowEditorWindowWithTypeName(string windowTypeName)
    //{
    //    var windowType = typeof(Editor).Assembly.GetType(windowTypeName);
    //    EditorWindow.GetWindow(windowType);
    //}
}
