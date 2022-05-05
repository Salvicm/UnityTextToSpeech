#if (UNITY_EDITOR) 
using System.Collections;

static class TextHolder
{
    // Base
    public const string InitializingTTS = "Inicializando TTS";
    public const string voidText = "";
    
    // OpenWindows
    public const string OpenHierarchy = "Abriendo Jerarquía";
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
    public const string ThisItemIs = " es del tipo ";
    public const string IsAScript = "Script";
    public const string IsAFolder = "Carpeta";
    public const string IsAScene = "Escena";
    public const string IsAnAudioMixer = "Controlador de mezclador de audio";
    public const string IsAShader = "Shader";
    public const string IsAGameObject = "Game Object";
    public const string UnknownItem = "Desconocido";




    //Info
    public const string HierarchyInfo = "Con el botón general puedes saber que objeto está seleccionado, si tiene padre y cuantos hijos. " +
        "Usa el botón Auxiliar 1 para saber que hijos tiene ese objeto. Pulsa el botón auxiliar 2 para no se. " +
        "Pulsa el botón auxiliar 3 para saber si el objeto pertenece a un prefab y, si estás editando uno, cual es.";
    public const string ProjectFolderInfo = "";
    public const string InspectorInfo = "";
    public const string GameInfo = "";
    public const string ConsoleInfo = "";
    public const string SceneInfo = "";
}
#endif
