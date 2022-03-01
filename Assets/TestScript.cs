using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
static class TestScript
{

    static EditorWindow previousWindow, currentWindow;
    static string nameOfCurrentWindow = "";
    static TestScript()
    {
        EditorApplication.update += Update;
        // Aquí los mencionará todos,
        // pero tengo que mirar que pasa
        // si le van a dar al play cada
        // 1000 veces, o si se recompilarán los scripts
        
    }

    static void Update()
    {

        if (currentWindow == null)
        {
            EditorWindow[] allWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            Debug.Log("Windows Size: " + allWindows.Length);
            allWindows[0].Focus();
            foreach (var item in allWindows)
            {
                if (item.GetType().Name == Windows.SceneView)
                {
                    item.Focus();
                }
            }
            currentWindow = EditorWindow.focusedWindow;
            Debug.Log(currentWindow.GetType().Name);
        }
        WindowsChecker(); 
    }
    
    static void WindowsChecker()
    {
        currentWindow = EditorWindow.focusedWindow;
        if (currentWindow != previousWindow)
        {
            nameOfCurrentWindow = currentWindow.GetType().Name;
            switch (nameOfCurrentWindow)
            {
               case Windows.SceneHierarchy:  
                    Debug.Log("You have opened: " + Windows.SceneHierarchy);
                    break;
               case Windows.SceneView:    
                    Debug.Log("You have opened: " + Windows.SceneView);
                    break;
               case Windows.GameView:     
                    Debug.Log("You have opened: " + Windows.GameView);
                    break;
               case Windows.Console:        
                    Debug.Log("You have opened: " + Windows.Console);
                    break;
               case Windows.Inspector:       
                    Debug.Log("You have opened: " + Windows.Inspector);
                    break;
                case Windows.AssetStore:
                    Debug.Log("You have opened: " + Windows.AssetStore);
                    break;
                default:
                    Debug.Log(nameOfCurrentWindow);
                    break;
            }
        }
        
        
   
        // TODO 
        /* Close all tabs except basic and set layout 
         * Autoclose tabs?
         * ** Set Autoclose optional
         * Get all params from the window and navigate
         * Has unsaved stuff
         * 
         */
       
        previousWindow = currentWindow;
    }

 
 
    static void ShowInspectorEditorWindow()
    {
        string inspectorWindowTypeName = "UnityEditor.InspectorWindow";
        ShowEditorWindowWithTypeName(inspectorWindowTypeName);
    }

    static void ShowSceneEditorWindow()
    {
        string sceneWindowTypeName = "UnityEditor.SceneView";
        ShowEditorWindowWithTypeName(sceneWindowTypeName);
    }

    static void ShowEditorWindowWithTypeName(string windowTypeName)
    { /* ESTO PETA
        var editorAsm = typeof(Editor).Assembly;
        Type inspWndType = editorAsm.GetType(windowTypeName);
        EditorWindow.GetWindow(inspWndType, false, "My Empty Window", true);

        */ 
    }
}
