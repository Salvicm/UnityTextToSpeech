#if (UNITY_EDITOR) 
using System.Collections;
using UnityEditor;

static class TextHolder
{

    // Base
    public static string InitializingTTS = "Initializing TTS";
    public static string voidText = "";

    // OpenWindows
    public static string OpenHierarchy = "Opening hierarchy";
    public static string OpenScene = "Opening scene";
    public static string OpenGame = "Opening game";
    public static string OpenConsole = "Opening console";
    public static string OpenInspector = "Opening inspector";
    public static string OpenExplorer = "Opening file explorer";
    public static string OpeningUnsuportedScene = "Opening unsuported window: ";


    //Hierarchy controller
    public static string ChildrenList = "has a total of ";
    public static string Children = "children";
    public static string HasParent = "Has a parent";
    public static string IsAPrefab = "Is a prefab";
    public static string NotAPrefab = "Is not a prefab";
    public static string CurrentlyEditingPrefab = "Editing prefab: ";

    // project controller
    public static string LocationIs = "Complete path is: ";
    public static string ActualFolder = "Actual folder is: ";
    public static string ThisItemIs = " is type ";
    public static string IsAScript = "Script";
    public static string IsAFolder = "folder";
    public static string IsAScene = "scene";
    public static string IsAnAudioMixer = "Audio Mixer controller";
    public static string IsAShader = "Shader";
    public static string IsAGameObject = "Game Object";
    public static string IsADLL = "DLL";
    public static string UnknownItem = "Unknown";

    // Console 
    public static string OnlyErrors = "Only errors";
    public static string OnlyWarnings = "Only warnings";
    public static string OnlyLogs = "Only logs";
    public static string OnlyExceptions = "Only exceptions";
    public static string OnlyAsserts = "Only asserts";
    public static string All = "All";
       
    public static string readingAll = "Reading full stacktrace: ";
    public static string ErrorNumber = "Error number ";
    public static string Of = " of ";

    // Inspector Window
    public static string thisDoesNothing = "This button does nothing";














    #region Information
    //Info
    public static string HierarchyInfo = "With the general button you can know which object is selected, if it has a parent and how many children does it have. " +
        "Use advance button to hear the number of childs it has and enumerate them." +
        "Use regress button to hear the name of the parent object in case it exists." +
        "Use auxiliar button 1 to saber que hijos tiene ese objeto. " +
        "Use auxiliar button 2 to . " +
        "Use auxiliar button 3 to know if the object belongs to a prefab and, in case you're in edit mode, which one.";
  
    public static string ProjectFolderInfo = "With the general button you know what object is selected and its extension." +
        "Use advance button to " +
        "Use regress button to " +
        "Use auxiliar button 1 to know the selected object's full path." +
        "Use auxiliar button 2 to know the folder of the current selected object." +
        "Use auxiliar button 3 to know if the object is a prefab.";

    public static string ConsoleInfo = "With the general button you can know the actual log, what it says and the type." +
        "Use advance button to advance to the next log." +
        "Use regress button to return to the previous log." +
        "Use auxiliar button 1 to hear actual log path." +
        "Use auxiliar button 2 to hear the full stacktrace." +
        "Use auxiliar button 3 to modify the type of logs to check'.";
    public static string InspectorInfo = "Work in progress";


    public static string GameInfo = "Unimplemented window";
    public static string SceneInfo = "Unimplemented window";



    public const string profileID = "TTSSC";

    #endregion
}
#endif
