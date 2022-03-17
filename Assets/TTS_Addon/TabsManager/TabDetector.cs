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

    static bool pressedControl = false;

    static SceneDetector()
    {
        EditorApplication.update += Update;


        System.Reflection.FieldInfo info = typeof(EditorApplication)
            .GetField("globalEventHandler",
            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        EditorApplication.CallbackFunction value = (EditorApplication.CallbackFunction)info.GetValue(null);

        value += EditorGlobalKeyPress;

        info.SetValue(null, value);

        // Aquí los mencionará todos,
        // pero tengo que mirar que pasa
        // si le van a dar al play cada
        // 1000 veces, o si se recompilarán los scripts


    }
    static void EditorGlobalKeyPress()
    {
        Event current = Event.current;

        if (Event.current.keyCode == KeyCode.LeftControl) // TODO cambiar esto para que sea 1 click
        {
            pressedControl = true;
        }
        
        if (!pressedControl) return;
        switch (Event.current.keyCode)
        {
            case KeyCode.Alpha1:
                Debug.Log("Scene");
                WindowsVoice.speak("Opening Scene");
                break;
            case KeyCode.Alpha2:
                Debug.Log("Game");
                WindowsVoice.speak("Opening Game");
                break;
            case KeyCode.Alpha3:
                Debug.Log("Inspector");
                WindowsVoice.speak("Opening Inspector");
                break;
            case KeyCode.Alpha4:
                Debug.Log("Hierarchy");
                WindowsVoice.speak("Opening Hierarchy");
                break;
            case KeyCode.Alpha5:
                Debug.Log("Project");
                WindowsVoice.speak("Opening Project");
                break;
            case KeyCode.Escape:
                Debug.Log("Console");
                break;
            default:
                break;
        }
    }
    static void Update()
    {
       
        if (currentWindow == null && !started)
        {
            started = true;
            EditorWindow[] allWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            ShowSceneEditorWindow();
            currentWindow = EditorWindow.focusedWindow;
        }else if(currentWindow == null && started)
        {
            //Debug.Log("a"); 
        }
        currentWindow = EditorWindow.focusedWindow;
        if (currentWindow != null)
        {
            WindowsChecker();
        }
        else
        {
            if(previousWindow != null)
                Debug.Log("Nothing Selected");
            previousWindow = null;
        }

      


    }




    static void WindowsChecker()
    {
        if (currentWindow != previousWindow)
        {
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
                    Debug.Log("Unsuported by voiceOver: " + nameOfCurrentWindow);

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
        ShowEditorWindowWithTypeName(Windows.InspectorWindow);
    }

    static void ShowSceneEditorWindow()
    {
        ShowEditorWindowWithTypeName(Windows.SceneView);
    }

    static void ShowEditorWindowWithTypeName(string windowTypeName)
    {

        /*
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type =>type.IsClass && !type.IsAbstract && 
            type.IsSubclassOf(typeof(EditorWindow))).ToArray();

        var window = EditorWindow.GetWindow<UnityEditor.SceneView>(types);
        
        Debug.Log(string.Join("\n",
            AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && !type.IsAbstract 
            && type.IsSubclassOf(typeof(EditorWindow))).Select(t => t.FullName)));
        */
        var types = new List<Type>()
        { 
            // first add your preferences
            typeof(SceneView),
            typeof(Editor).Assembly.GetType("UnityEditor.GameView"),
            typeof(Editor).Assembly.GetType("UnityEditor.SceneHierarchyWindow"),
            typeof(Editor).Assembly.GetType("UnityEditor.ConsoleWindow"),
            typeof(Editor).Assembly.GetType("UnityEditor.ProjectBrowser"),
            typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow")
        };
        /*
        // and then add all others as fallback (who cares about duplicates at this point ? ;) )
        types.AddRange(AppDomain.CurrentDomain.GetAssemblies().
        SelectMany(assembly => assembly.GetTypes())
        .Where(type => type.IsClass && !type.IsAbstract 
        && type.IsSubclassOf(typeof(EditorWindow))));
        */
   
        switch (windowTypeName)
        {
            case Windows.SceneHierarchyWindow:
                var hWindow = EditorWindow.GetWindow(typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
                hWindow.Focus();
                break;
            case Windows.SceneView:
                var sWindow = EditorWindow.GetWindow(typeof(SceneView));
                sWindow.Focus();
                break;
            case Windows.GameView:
                var gWindow = EditorWindow.GetWindow(typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
                gWindow.Focus();
                break;
            case Windows.ConsoleWindow:
                var cWindow = EditorWindow.GetWindow(typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
                cWindow.Focus();
                break;
            case Windows.InspectorWindow:
                var iWindow = EditorWindow.GetWindow(typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
                iWindow.Focus();
                break;
            case Windows.ProjectBrowser:
                var pWindow = EditorWindow.GetWindow(typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
                pWindow.Focus();
                break;
            default:
                Debug.Log("You're trying to open a non-supported window");
                break;

        }


    }
} 
