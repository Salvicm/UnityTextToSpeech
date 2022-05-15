#if (UNITY_EDITOR) 

using System;
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.ShortcutManagement;

[InitializeOnLoad]
class MainController
{
    static TabController currentTabController;
    static EditorWindow previousWindow, currentWindow;
    static string nameOfCurrentWindow = "";
    static bool started = false;
    public static List<CustomDebug> ErrorLogs;

    public static int maxNumOfLogs = 1000;
    public static int logCount = 0;
   
    static MainController()
    {
        nameOfCurrentWindow = SessionState.GetString("LastOpenWindows", "");

        EditorApplication.update += Update;

        /* // Key presses
         System.Reflection.FieldInfo info = typeof(EditorApplication)
             .GetField("globalEventHandler", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
         EditorApplication.CallbackFunction value = (EditorApplication.CallbackFunction)info.GetValue(null);
         value += EditorGlobalKeyPress;

         info.SetValue(null, value);
        */
        //var types = AppDomain.CurrentDomain.GetAssemblies()
        //    .SelectMany(assembly => assembly.GetTypes())
        //    .Where(type => type.IsClass && !type.IsAbstract &&
        //    type.IsSubclassOf(typeof(EditorWindow))).ToArray();
        currentTabController = new HierarchyTabController();

        ErrorLogs = new List<CustomDebug>();
        


        Application.logMessageReceived += HandleLog;

        if (SessionState.GetBool("CanSpeak", true) == false)
        {
            WindowsVoice.destroySpeech();
        }
        
        if (EditorPrefs.GetBool("FirstInitDone", false) == false)
        {
            //Force rebind
            // TEst
            
            KeyCombination keyCombination = new KeyCombination(KeyCode.O);
            ShortcutBinding binding = new ShortcutBinding(keyCombination);
            bool alreadyExists = false;
            foreach(string item in ShortcutManager.instance.GetAvailableProfileIds())
            {
                Debug.Log(item);
                if(item == TextHolder.profileID)
                    alreadyExists = true;
            }
            if(!alreadyExists)
                ShortcutManager.instance.CreateProfile(TextHolder.profileID);
            ShortcutManager.instance.activeProfileId = TextHolder.profileID;
            ShortcutManager.instance.RebindShortcut("Stage/Go Back", binding);

            WindowsVoice.speak(TextHolder.InitializingTTS);
            EditorPrefs.SetBool("FirstInitDone", true);
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
            // No hagas nada, podría ser cosa del usuario
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
            currentTabController.clean();

            switch (nameOfCurrentWindow)
            {
                case Windows.SceneHierarchyWindow:
                    if (currentTabController.GetType() != typeof(HierarchyTabController))
                    {
                        currentTabController = new HierarchyTabController();
                    }
                        WindowsVoice.silence();
                        WindowsVoice.speak(TextHolder.OpenHierarchy);
                    break;
                case Windows.SceneView:
                    if (currentTabController.GetType() != typeof(SceneTabController))
                    {
                        // currentTabController = new SceneTabController();
                    }
                        WindowsVoice.silence();
                        WindowsVoice.speak(TextHolder.OpenScene);
                    break;
               case Windows.GameView:
                    if (currentTabController.GetType() != typeof(GameTabController))
                    {
                        // currentTabController = new GameTabController();
                    }
                        WindowsVoice.silence();
                        WindowsVoice.speak(TextHolder.OpenGame);
                    break;
               case Windows.ConsoleWindow:
                    if (currentTabController.GetType() != typeof(ConsoleTabController))
                    {
                        currentTabController = new ConsoleTabController();
                    }
                        WindowsVoice.silence();
                        WindowsVoice.speak(TextHolder.OpenConsole);
                    break;
               case Windows.InspectorWindow:
                    if (currentTabController.GetType() != typeof(InspectorTabController))
                    {
                        // currentTabController = new InspectorTabController();
                    }
                        WindowsVoice.silence();
                        WindowsVoice.speak(TextHolder.OpenInspector);
                    break;
                case Windows.ProjectBrowser:
                    if (currentTabController.GetType() != typeof(ProjectTabController))
                    {
                        currentTabController = new ProjectTabController();
                    }
                        WindowsVoice.silence();
                        WindowsVoice.speak(TextHolder.OpenInspector);
                    break;
                default:
                    WindowsVoice.speak(TextHolder.OpeningUnsuportedScene + nameOfCurrentWindow);

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

    static void HandleLog(string logString, string stackTrace, LogType type)
    {
        if(ErrorLogs.Count == 0)
        {
            ErrorLogs.Add(new CustomDebug(logString, stackTrace, type));
        }
        else if (stackTrace != ErrorLogs.ElementAt(ErrorLogs.Count-1).stacktrace)
        {
            ErrorLogs.Add(new CustomDebug(logString, stackTrace, type));
            if (ErrorLogs.Count > maxNumOfLogs)
                ErrorLogs.RemoveAt(0);
        }
    }


    #region MenuItems
    [MenuItem("TTS/enable %&L")]
    static void LoadTTS()
    {
        WindowsVoice.initSpeech();
        SessionState.SetBool("CanSpeak", true);
        WindowsVoice.silence();
        WindowsVoice.speak(TextHolder.InitializingTTS);
    }

    [MenuItem("TTS/disable %&U")]
    static void UnloadTTS()
    {
        WindowsVoice.silence();
        WindowsVoice.destroySpeech();
        SessionState.SetBool("CanSpeak", false);
    }

    [MenuItem("TTS/AdvanceTab %&D")]
    static void SelectedTabAdvanceButton()//d
    {
        currentTabController.advanceButton();

    }

    [MenuItem("TTS/RegresTab %&A")]
    static void SelectedTabRegressButton()//a
    {
        currentTabController.regressionButton();
    }

    [MenuItem("TTS/GeneralButton %&X")]
    static void SelectedTabGeneralButton()//x
    {
        currentTabController.generalButton();

    }

    [MenuItem("TTS/InfoButton %&C")]
    static void SelectedTabInfoButton()
    {
        currentTabController.infoButton();

    }

    [MenuItem("TTS/TabUtilA %&B")]
    static void SelectedTabButtonA()
    {
        currentTabController.buttonA();

    }

    [MenuItem("TTS/TabUtilB %&N")]
    static void SelectedTabButtonB()
    {
        currentTabController.buttonB();

    }

    [MenuItem("TTS/TabUtilC %&M")]
    static void SelectedTabButtonC()
    {
        currentTabController.buttonC();

    }

    [MenuItem("TTS/Helper/SilenceVoice %&K")]
    static void silence()
    {

        WindowsVoice.silence();
    }

    //No parece poder hacerse
    //[MenuItem("TTS/Helper/CustomClosePrefab _o")]
    //static void closePrefab()
    //{

    //    EditorApplication.ExecuteMenuItem("Stage/Go back");
    //    Debug.Log("A");
    //}

    #endregion

}


public class CustomDebug
{
    public string value;
    public string stacktrace;
    public LogType type;
    public CustomDebug(string _value, string _stacktrace, LogType _type)
    {
        value = _value;
        stacktrace = _stacktrace;
        type = _type;
    }

}
#endif