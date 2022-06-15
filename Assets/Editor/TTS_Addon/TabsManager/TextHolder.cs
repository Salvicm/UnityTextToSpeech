#if (UNITY_EDITOR) 
using UnityEngine;


static class TextHolder
{

    // Base
    public static string InitializingTTS { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Initializing TTS" : "Inicializando TTS"; } }
    public static string voidText = "";

    // OpenWindows
    public static string OpenHierarchy { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening hierarchy" : "Abriendo jerarquia"; } }
    public static string OpenScene { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Opening scene" : "Abriendo escena"; } }
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
    public static string NoChildren { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Has no children: " : "No tiene hijos: "; } }

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
    public static string All { set { } get { return Application.systemLanguage == SystemLanguage.English ? "All" : "Todo"; } }

    public static string readingAll { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Reading full stacktrace: " : "Leyendo stacktrace completo "; } }
    public static string ErrorNumber { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Error number " : "Error número "; } }
    public static string Of { set { } get { return Application.systemLanguage == SystemLanguage.English ? " of " : " de "; } }

    // Inspector Window
    public static string thisDoesNothing { set { } get { return Application.systemLanguage == SystemLanguage.English ? "This button does nothing" : "Este botón no hace nada"; } }



    // Generic Documentation
    public static string salutation { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Welcome to Unity's text-to-speech plug-in prototype, Navigate through the windows pressing control and numbers 1 through 5 or control shift c for console, "
        + "You'll need to navigate the Unity menu in order to test this plug-in, the orders for each of the windows will be explained by pressing control alt J;Go on, try and navigate through windows, " +
        "Use control alt V to get info for each window control, " :
        
        "Bienvenido al plug in prototipo de texto a voz de Unity. Navega a través de las ventanas presionando el control y los números 1 a 5, o Control, Shift, C para la consola"
        + "Necesitarás navegar los menús de Unity para poder probar este plug in, las instrucciones para cada una de las ventanas serán explicadas presionando control, alt, J; Adelante, intenta navegar a través de las ventanas, " +
        "Usa control, alt, v para obtener la información de los controles de cada ventana"; }
    } 

    public static string infoAboutHierarchy { set { } get { return Application.systemLanguage == SystemLanguage.English ? "In the Hierarchy you'll need to be able to create an object, change its name and edit a prefab, " +
        "To do so you'll need to use commands Control G to create a cube and then press enter, Press F2 to change its name." :

        "En la jerarquía necesitarás ser capaz de crear un objeto, cambiar su nombre y editar un prefab, " +
        "Para hacerlo necesitarás usar Control, G, para crear un cubo y pulsar enter. Pulsar F2 para cambiar su nombre."; }
    } 
    // Cambiar y no decir que da problemas
    public static string infoAboutProjectExplorer { set { } get { return Application.systemLanguage == SystemLanguage.English ? "In the project explorer you'll be able to navigate between items in the folders of the project, " +
        "To do so after opening the explorer, you'll need to press left and right arrow keys to navigate between the items in the current folder." +
        "To go back one folder use Control Alt A and use Control alt B to know the folder, " +
        "Before finishing, use control U to create an empty Prefab and type in a name. Lastly get the name of the current folder with Control alt N." :

        "En el explorador del proyecto serás capaz de navegar a través de los objetos en las carpetas del proyecto." +
        "Para hacerlo, despues de abrir el explorador, necesitarás pulsar las flechas de dirección lateral para navegar entre los objetos." +
        "Para volver una carpeta atrás se ha de usar Control, Alt, A, y usar Control, alt, B para permite saber la carpeta" +
        "Antes de acabar, usa Control U para crear un prefab vacío, y ponle un nombre. Por último obtén el nombre de la carpeta actual con Control, alt, N"; } 
    } 

    public static string infoAboutLogConsole { set { } get { return Application.systemLanguage == SystemLanguage.English ? "This is the console log, you should be able to navigate through a few logs that have been created as a test, "
        + "To do that you'll need to press Control Alt V and use the base controls on it, You should be able to understand the information of at least three logs, " :

        "Este es el registro de errores(Console log), deberías ser capaz de navegar a través de varios logs que se han creado como test."
        + "Para hacerlo necesitarás presionar control alt V, y usar los controles base. Deberías entender la información de al menos tres logs."; } 
    } 

    public static string infoAboutInspector { set { } get { return Application.systemLanguage == SystemLanguage.English ? "By pressing Control alt S you'll be able to check which object is currently selected, Select the cube you created on the Hierarchy and then " +
        "proceed to add a Rigidbody with control q, Once done this, use Tab until you hear any property, then use Control alt B to check its value, Then, keep tabbing until you reach the rigidbody" +
        "to then finish by activating the IsKinematic value, " :

        "Al presionar Control, alt, S, deberías poder comprobar que objeto hay seleccionado ahora mismo. Selecciona el cubo que creaste en la jerarquía y" +
        "procede a añadir un rigidbody con control q. Una vez hecho eso, usa Tab hasta que oigas una propiedad, y entonces usa Control, alt, B, para comprobar su valor. Entonces continua haciendo Tab hasta que alcances el rigidbody. Termina activando la opción Is Kinematic"; } 
    } 








    #region Information
    //Info
    public static string HierarchyInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Control alt S to know which object is selected, if it has a parent and how many children does it have. " +
        "Control alt D to hear the number of childs it has and enumerate them." +
        "Control alt A to hear the name of the parent object in case it exists." +
        "Control alt B to know what childs does that item have. " +
        "Control alt N to know if the object belongs to a prefab and, in case you're in edit mode, which one." :

        "Control, alt, S  para saber que objeto está seleccionado, si tiene un padre y cuantos hijos posee." +
        "Control, alt, D para escuchar el numero de hijos que tiene y enumerarlos." + 
        "Control, alt, A para escuchar el nombre del objeto padre en caso que exista" + 
        "Control, alt, B para to saber que hijos tiene ese objeto. " +
        "Control, alt, N para saber si el objeto pertenece a un prefab y si estás en modo edición, cual es."; }
    } 
    public static  string ProjectFolderInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Control alt S to know what object is selected and its extension." +
        "Control alt B to know the selected object's full path." +
        "Control alt A to go one folder back" +
        "Control alt N to know the folder of the current selected object." +
        "Control alt H to know if the object is a prefab." :
                 
        "Control, alt, S para saber que objeto está seleccionado y su extensión." +
        "Control, alt, A para ir una carpeta hacia atrás" +
        "Control, alt, B para saber la dirección completa del elemento." +
        "Control, alt, N para saber la carpeta seleccionada actualmente." +
        "Control, alt, H para saber si el objeto es un prefab."; } 
    } 
                 
    public static string ConsoleInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Control alt S to know the actual log, what it says and the type." +
        "Control alt D to advance to the next log." +
        "Control alt A to return to the previous log." +
        "Control alt B to hear actual log path." +
        "Control alt N to hear the full stacktrace." +
        "Control alt H to modify the type of logs to check'." :
                 
        "Control, alt, S para conocer el log seleccionado, lo que dice y su tipo." +
        "Control, alt, D para avanzar al siguiente log." +
        "Control, alt, A para volver al anterior log." +
        "Control, alt, B para escuchar la dirección completa del log." +
        "Control, alt, N para escuchar el stacktrace completo." +
        "Control, alt, H para modificar el tipo de logs'."; } 
    } 


    public static string InspectorInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Control alt S to know the current selected item."  + 
        "control alt B to know the value of the current selected property" :

        "Control, alt, S, para saber el objeto seleccionado actualmente." +
        "control, alt, B, para saber el valor de la propiedad seleccionada actualmente.";
        } 
    } 


    public static string GameInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Unimplemented window" : "Este botón no hace nada"; } } 
    public static string SceneInfo { set { } get { return Application.systemLanguage == SystemLanguage.English ? "Unimplemented window" : "Este botón no hace nada"; } } 



    public const string profileID = "TTSSC";

    #endregion
}
#endif
