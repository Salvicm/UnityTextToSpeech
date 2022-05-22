#if (UNITY_EDITOR) 
using System.Collections;
using UnityEditor;

static class TextHolder
{
    // Base
    public const string InitializingTTS = "Inicializando TTS";
    public const string voidText = "";
    
    // OpenWindows
    public const string OpenHierarchy = "Abriendo Jerarqu�a";
    public const string OpenScene = "Abriendo escena";
    public const string OpenGame = "Abriendo juego";
    public const string OpenConsole = "Abriendo consola";
    public const string OpenInspector = "Abriendo inspector";
    public const string OpenExplorer = "Abriendo explorador de archivos";
    public const string OpeningUnsuportedScene = "Abriendo ventana no soportada por el TTS: ";


    //Hierarchy controller
    public const string ChildrenList = "tiene un total de ";
    public const string Children = "hijos";
    public const string HasParent = "Tiene padre";
    public const string IsAPrefab = "Es un prefab";
    public const string NotAPrefab = "No es un prefab";
    public const string CurrentlyEditingPrefab = "Editando el prefab: ";

    // project controller
    public const string LocationIs = "La direccion completa es: ";
    public const string ActualFolder = "La carpeta actual es: ";
    public const string ThisItemIs = " es del tipo ";
    public const string IsAScript = "Script";
    public const string IsAFolder = "Carpeta";
    public const string IsAScene = "Escena";
    public const string IsAnAudioMixer = "Controlador de mezclador de audio";
    public const string IsAShader = "Shader";
    public const string IsAGameObject = "Game Object";
    public const string IsADLL = "DLL";
    public const string UnknownItem = "Desconocido";

    // Console 
    public const string OnlyErrors = "Solo errores";
    public const string OnlyWarnings = "Solo advertencias";
    public const string OnlyLogs = "Solo logs";
    public const string OnlyExceptions = "Solo excepciones";
    public const string OnlyAsserts = "Solo asserts";
    public const string All = "Todos";

    public const string readingAll = "Leyendo el stacktrace completo: ";
    public const string ErrorNumber = "Error n�mero ";
    public const string Of = " de ";

    [MenuItem("TTS/test %&J")]
    static void LoadTTS()
    {
        char t = "a"[2];
    }
    //Info
    public const string HierarchyInfo = "Con el bot�n general puedes saber que objeto est� seleccionado, si tiene padre y cuantos hijos. " +
        "Usa el bot�n de avance para oir el n�mero de hijos que tiene y enumerarlos" +
        "Usa el bot�n de retroceso para oir el nombre del objeto padre en caso de tenerlo" +
        "Usa el bot�n Auxiliar 1 para saber que hijos tiene ese objeto. " +
        "Usa el bot�n auxiliar 2 para <no implementado>. " +
        "Usa el bot�n auxiliar 3 para saber si el objeto pertenece a un prefab y, si est�s editando uno, cual es.";
    public const string ProjectFolderInfo = "Con el bot�n general puedes saber que objeto est� seleccionado y su extensi�n." +
        "Usa el bot�n de avance para <no implementado>" +
        "Usa el bot�n de retroceso para <no implementado>" +
        "Usa el bot�n Auxiliar 1 para saber la direcci�n completa del objeto seleccionado." +
        "Usa el bot�n Auxiliar 2 para saber la carpeta actual del objeto seleccionado." +
        "Usa el bot�n auxiliar 3 para saber si el objeto es un prefab.";
    public const string InspectorInfo = "Con el bot�n general puedes <no implementado>." +
        "Usa el bot�n de avance para <no implementado>" +
        "Usa el bot�n de retroceso para <no implementado>" +
        "Usa el bot�n Auxiliar 1 para <no implementado>." +
        "Usa el bot�n Auxiliar 2 para <no implementado>." +
        "Usa el bot�n auxiliar 3 para <no implementado>.";
    public const string GameInfo = "Con el bot�n general puedes <no implementado>." +
        "Usa el bot�n de avance para <no implementado>" +
        "Usa el bot�n de retroceso para <no implementado>" +
        "Usa el bot�n Auxiliar 1 para <no implementado>." +
        "Usa el bot�n Auxiliar 2 para <no implementado>." +
        "Usa el bot�n auxiliar 3 para <no implementado>.";
    public const string ConsoleInfo = "Con el bot�n general puedes <no implementado>." +
        "Usa el bot�n de avance para <no implementado>" +
        "Usa el bot�n de retroceso para <no implementado>" +
        "Usa el bot�n Auxiliar 1 para <no implementado>." +
        "Usa el bot�n Auxiliar 2 para <no implementado>." +
        "Usa el bot�n auxiliar 3 para <no implementado>.";
    public const string SceneInfo = "Con el bot�n general puedes <no implementado>." +
        "Usa el bot�n de avance para <no implementado>" +
        "Usa el bot�n de retroceso para <no implementado>" +
        "Usa el bot�n Auxiliar 1 para <no implementado>." +
        "Usa el bot�n Auxiliar 2 para <no implementado>." +
        "Usa el bot�n auxiliar 3 para <no implementado>.";



    public const string profileID = "TTSSC";

    
}
#endif
