#if (UNITY_EDITOR) 
using System.Collections;
using UnityEditor;
using UnityEngine;
static class TextHolder
{
    
    // Base
    public static string InitializingTTS {  set { } get { return Application.systemLanguage == SystemLanguage.English ?  "Initializing TTS" : "Inicializando TTS"; } }
    public static string voidText = "";
    
    // OpenWindows
    public static string OpenHierarchy {  set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening hierarchy" : "Abriendo jerarquía"; } }
    public static string OpenScene {  set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening scene" : "Abriendo escena"; } }
    public static string OpenGame { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening game" : "Abriendo juego"; } }
    public static string OpenConsole { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening console" : "Abriendo consola"; } }
    public static string OpenInspector { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening inspector" : "Abriendo inspector"; } }
    public static string OpenExplorer { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening file explorer" : "Abriendo explorador de archivos"; } }
    public static string OpeningUnsuportedScene { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening unsuported window: " : "Abriendo ventana no soportada"; } }


    //Hierarchy controller
    public static string ChildrenList { set { } get { return Application.systemLanguage == SystemLanguage.English ? "has a total of " : " Tiene un total de "; } }
    public static string Children { set { } get { return Application.systemLanguage == SystemLanguage.English ? "children" : "hijos"; } }
    public static string HasParent { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Has a parent" : "Tiene padre"; } }
    public static string IsAPrefab { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Is a prefab" : "Es un prefab"; } }
    public static string NotAPrefab { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Is not a prefab" : "No es un prefab"; } }
    public static string CurrentlyEditingPrefab { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Editing prefab: " : "Editando prefab: "; } }

    // project controller
    public static string LocationIs { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Complete path is: " : "La direccion completa es: "; } }
    public static string ActualFolder { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Actual folder is: " : "La carpeta actual es:  "; } }
    public static string ThisItemIs { set { } get { return Application.systemLanguage == SystemLanguage.English ? " is type " : " es del tipo "; } }
    public static string IsAScript { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Script" : "Script"; } }
    public static string IsAFolder { set { } get { return Application.systemLanguage == SystemLanguage.English ? "folder" : "carpeta"; } }
    public static string IsAScene { set { } get { return Application.systemLanguage == SystemLanguage.English ? "scene" : "Escena"; } }
    public static string IsAnAudioMixer { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Audio Mixer controller" : "Controlador de mezclador de audio"; } }
    public static string IsAShader { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Shader" : "Shader"; } }
    public static string IsAGameObject { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Game Object" : "Game Object"; } }
    public static string IsADLL { set { } get { return Application.systemLanguage == SystemLanguage.English ? "DLL" : "DLL"; } }
    public static string UnknownItem { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Unknown" : "Desconocido"; } }

    // Console 
    public static string OnlyErrors { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Only errors" : "Solo errores"; } }
    public static string OnlyWarnings { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Only warnings" : "Solo advertencias"; } }
    public static string OnlyLogs { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Only logs" : "Solo logs"; } }
    public static string OnlyExceptions { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Only exceptions" : "Solo excepciones"; } }
    public static string OnlyAsserts { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Only asserts" : "Solo asserts"; } }
    public static string All { set { } get { return Application.systemLanguage == SystemLanguage.English ? "All" : "Todo";
} }

    public static string readingAll { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Reading full stacktrace: " : "Leyendo stacktrace completo "; } }
    public static string ErrorNumber { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Error number " : "Error número "; } }
    public static string Of { set { } get { return Application.systemLanguage == SystemLanguage.English ? " of " : " de "; } }

    
    //Info
    public static string HierarchyInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "With the general button you can know which object is selected, if it has a parent and how many children does it have. " +
        "Use advance button to hear the number of childs it has and enumerate them." +
        "Use regress button to hear the name of the parent object in case it exists." +
        "Use auxiliar button 1 to saber que hijos tiene ese objeto. " +
        "Use auxiliar button 2 to . " +
        "Use auxiliar button 3 to know if the object belongs to a prefab and, in case you're in edit mode, which one." 
        : "Con el botón general puedes saber que objeto está seleccionado, si tiene padre y cuantos hijos. " +
        "Usa el botón de avance para oir el número de hijos que tiene y enumerarlos" +
        "Usa el botón de retroceso para oir el nombre del objeto padre en caso de tenerlo" +
        "Usa el botón Auxiliar 1 para saber que hijos tiene ese objeto. " +
        "Usa el botón auxiliar 2 para <no implementado>. " +
        "Usa el botón auxiliar 3 para saber si el objeto pertenece a un prefab y, si estás editando uno, cual es."; } }
    public static string ProjectFolderInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "With the general button you know what object is selected and its extension." +
        "Use advance button to " +
        "Use regress button to " +
        "Use auxiliar button 1 to know the selected object's full path." +
        "Use auxiliar button 2 to know the folder of the current selected object." +
        "Use auxiliar button 3 to know if the object is a prefab." 
        : "Con el botón general puedes saber que objeto está seleccionado y su extensión." +
        "Usa el botón de avance para <no implementado>" +
        "Usa el botón de retroceso para <no implementado>" +
        "Usa el botón Auxiliar 1 para saber la dirección completa del objeto seleccionado." +
        "Usa el botón Auxiliar 2 para saber la carpeta actual del objeto seleccionado." +
        "Usa el botón auxiliar 3 para saber si el objeto es un prefab."; } }
    public static string InspectorInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Unimplemented window" : "Ventana no implementada"; } }
    public static string GameInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Unimplemented window" : "Ventana no implementada"; } }
    public static string ConsoleInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "With the general button you can know the actual log, what it says and the type." +
        "Use advance button to advance to the next log." +
        "Use regress button to return to the previous log." +
        "Use auxiliar button 1 to hear actual log path." +
        "Use auxiliar button 2 to hear the full stacktrace." +
        "Use auxiliar button 3 to modify the type of logs to check'." 
        : "Con el botón general puedes saber el log actual, lo que dice y el tipo." +
        "Usa el botón de avance para avanzar al siguiente Log" +
        "Usa el botón de retroceso para retroceder al log anterior" +
        "Usa el botón Auxiliar 1 para escuchar el path del log actual." +
        "Usa el botón Auxiliar 2 para escuchar el stacktrace completo." +
        "Usa el botón auxiliar 3 para modificar el tipo de logs que quieres revisar."; } }
    public static string SceneInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Unimplemented window" : "Ventana no implementada"; } }



    public const string profileID = "TTSSC";

    
    
}
#endif
