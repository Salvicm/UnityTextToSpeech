using System;
using System.Reflection;
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


        // Key presses
        System.Reflection.FieldInfo info = typeof(EditorApplication)
            .GetField("globalEventHandler", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        EditorApplication.CallbackFunction value = (EditorApplication.CallbackFunction)info.GetValue(null);
        value += EditorGlobalKeyPress;
        info.SetValue(null, value);

        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && !type.IsAbstract &&
            type.IsSubclassOf(typeof(EditorWindow))).ToArray();

        string superString = "";
        //foreach (var item in types)
        //{
        //    superString += "- " + item.Name + "\n";
        //    foreach(var x in item.GetMethods())
        //    {
        //        superString += "--- " + x.Name + "\n";
        //        foreach(var j in x.GetParameters())
        //        {
        //            superString += "----- " + j.Name + "\n";

        //        }
        //    }
        //}
        Debug.Log(superString);
        if (!SessionState.GetBool("FirstInitDone", false))
        {
            WindowsVoice.speak("Inicializando TTS");
            SessionState.SetBool("FirstInitDone", true);
        }
        // Aquí los mencionará todos // No ha sido buena idea, tengo que encontrar la manera de obligarlo a callar.


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
                break;
            case KeyCode.Alpha2:
                break;
            case KeyCode.Alpha3:
                break;
            case KeyCode.Alpha4:
                break;
            case KeyCode.Alpha5:
                break;
            case KeyCode.Escape:
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
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo jerarquía");
                    break;
               case Windows.SceneView:
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo escena");
                    break;
               case Windows.GameView:
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo juego");
                    break;
               case Windows.ConsoleWindow:
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo consola");
                    break;
               case Windows.InspectorWindow:
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo inspector");
                    break;
                case Windows.ProjectBrowser:
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo explorador de carpetas");
                    break;
                default:
                    Debug.Log("No soportado por el voiceOver: " + nameOfCurrentWindow);

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
