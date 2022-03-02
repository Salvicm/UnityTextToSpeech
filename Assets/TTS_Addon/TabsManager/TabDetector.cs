using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[InitializeOnLoad]
static class SceneDetector
{

    static EditorWindow previousWindow, currentWindow;
    static string nameOfCurrentWindow = "";
    static bool started = false;
    static SceneDetector()
    {
        EditorApplication.update += Update;
        // Aquí los mencionará todos,
        // pero tengo que mirar que pasa
        // si le van a dar al play cada
        // 1000 veces, o si se recompilarán los scripts
        
    }

    static void Update()
    {

        if (currentWindow == null && !started)
        {
            started = true;
            EditorWindow[] allWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            Debug.Log("Windows Size: " + allWindows.Length);
       
            ShowEditorWindowWithTypeName(Windows.SceneView);
            currentWindow = EditorWindow.focusedWindow;
            Debug.Log(currentWindow.GetType().Name); 
        }else if(currentWindow == null && started)
        {
            Debug.Log("a");
        }
        WindowsChecker(); 
    }
    
    static void WindowsChecker()
    {
        currentWindow = EditorWindow.focusedWindow;
        if (currentWindow != previousWindow)
        {
            Debug.Log(currentWindow);
            nameOfCurrentWindow = currentWindow.GetType().Name;
            Debug.Log(nameOfCurrentWindow);
            switch (nameOfCurrentWindow)
            {
               case Windows.SceneHierarchyWindow:  
                    break;
               case Windows.SceneView:    
                    break;
               case Windows.GameView:     
                    break;
               case Windows.ConsoleWindow:        
                    break;
               case Windows.InspectorWindow:       
                    break;
                case Windows.ProjectBrowser:
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
    {

        /*
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type =>type.IsClass && !type.IsAbstract && 
            type.IsSubclassOf(typeof(EditorWindow))).ToArray();

        var window = EditorWindow.GetWindow<UnityEditor.SceneView>(types);
        */

        
        var types = new List<Type>()
        { 
            // first add your preferences
            typeof(SceneView),
            typeof(Editor).Assembly.GetType("UnityEditor." + windowTypeName)
        };

        // and then add all others as fallback (who cares about duplicates at this point ? ;) )
        types.AddRange(AppDomain.CurrentDomain.GetAssemblies().
            SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && !type.IsAbstract 
            && type.IsSubclassOf(typeof(EditorWindow))));

        switch (windowTypeName)
        {
            case Windows.SceneHierarchyWindow:
                break;
            case Windows.SceneView:
                var window = EditorWindow.GetWindow<UnityEditor.SceneView>(types.ToArray());
                window.Focus();
                break;
            case Windows.GameView:
                window = EditorWindow.GetWindow<UnityEditor.SceneView>(types.ToArray());
                window.Focus();
                break;
            case Windows.ConsoleWindow:
                break;
            case Windows.InspectorWindow:
                break;
            case Windows.ProjectBrowser:
                break;
            default:
                Debug.Log(nameOfCurrentWindow);
                break;

        }


    }
} 
