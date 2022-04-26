#if (UNITY_EDITOR) 

using System;
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[InitializeOnLoad]
class MainController
{
    static TabController currentTabController;
    static EditorWindow previousWindow, currentWindow;
    static string nameOfCurrentWindow = "";
    static bool started = false;
    static MainController()
    {
        nameOfCurrentWindow = SessionState.GetString("LastOpenWindows", "");

        EditorApplication.update += Update;

        // Key presses
        System.Reflection.FieldInfo info = typeof(EditorApplication)
            .GetField("globalEventHandler", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        EditorApplication.CallbackFunction value = (EditorApplication.CallbackFunction)info.GetValue(null);
        value += EditorGlobalKeyPress;
        
        info.SetValue(null, value);

        //var types = AppDomain.CurrentDomain.GetAssemblies()
        //    .SelectMany(assembly => assembly.GetTypes())
        //    .Where(type => type.IsClass && !type.IsAbstract &&
        //    type.IsSubclassOf(typeof(EditorWindow))).ToArray();
        currentTabController = new HierarchyTabController();
        
        if (!SessionState.GetBool("CanSpeak", true))
        {
            WindowsVoice.destroySpeech();
        }
        if (!SessionState.GetBool("FirstInitDone", false))
        {
            
            WindowsVoice.speak("Inicializando TTS");
            SessionState.SetBool("FirstInitDone", true);
        }
    }

    static void EditorGlobalKeyPress()
    {
        Event current = Event.current;

                
        if ((!current.alt && !current.control)|| current.type != EventType.KeyUp) return;
        switch (Event.current.keyCode)
        {
            case KeyCode.L:
                WindowsVoice.initSpeech();
                SessionState.SetBool("CanSpeak", true);
                WindowsVoice.silence();
                WindowsVoice.speak("Inicializando TTS");
                break;
            case KeyCode.U:
                WindowsVoice.silence();
                WindowsVoice.destroySpeech();
                SessionState.SetBool("CanSpeak", false);
                break;

            case KeyCode.M:
                currentTabController.generalButton();
                break;
            case KeyCode.X:
                currentTabController.advanceButton();
                break;
            case KeyCode.C:
                currentTabController.regressionButton();
                break;
            case KeyCode.V:
                currentTabController.buttonA();
                break;
            case KeyCode.B:
                currentTabController.buttonB();
                break;
            case KeyCode.N:
                currentTabController.buttonC();
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
            // No hagas nada, podr�a ser cosa del usuario
        }
        currentWindow = EditorWindow.focusedWindow;
        if (currentWindow != null)
        {
            WindowFocusDetector();
        }
        else
        {
            if(previousWindow != null)
                Debug.Log("Nothing Selected");
            previousWindow = null;
        }
        currentTabController.Update();
    }

    static void WindowFocusDetector()
    {
        if (currentWindow != previousWindow)
        {
            nameOfCurrentWindow = currentWindow.GetType().Name;
            SessionState.SetString("LastOpenWindows", nameOfCurrentWindow);

            switch (nameOfCurrentWindow)
            {
               case Windows.SceneHierarchyWindow:
                    currentTabController = new HierarchyTabController();
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo jerarqu�a");
                    break;
               case Windows.SceneView:
                    // currentTabController = new SceneTabController();
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo escena");
                    break;
               case Windows.GameView:
                    // currentTabController = new GameTabController();
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo juego");
                    break;
               case Windows.ConsoleWindow:
                    // currentTabController = new ConsoleTabController();
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo consola");
                    break;
               case Windows.InspectorWindow:
                    // currentTabController = new InspectorTabController();
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo inspector");
                    break;
                case Windows.ProjectBrowser:
                    // currentTabController = new ProjectTabController();
                    WindowsVoice.silence();
                    WindowsVoice.speak("Abriendo explorador de carpetas");
                    break;
                default:
                    WindowsVoice.speak("Se ha abierto la ventana: " + nameOfCurrentWindow + ". Actualmente no soportada por el TTS");

                    break;
            }
            currentTabController.init();
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

#endif