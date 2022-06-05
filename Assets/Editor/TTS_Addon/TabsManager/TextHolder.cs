#if (UNITY_EDITOR) 
using System.Collections;
using UnityEditor;

static class TextHolder
{

    // Base
    public static string InitializingTTS { set { } get { return true ? "Initializing TTS" : "Inicializando TTS"; } }
    public static string voidText = "";

    // OpenWindows
    public static string OpenHierarchy { set { } get { return true ? "Opening hierarchy" : "Abriendo jerarquia"; } }
    public static string OpenScene { set { } get { return true ? "Opening scene" : "Abriendo escena"; } }
    public static string OpenGame { set { } get { return true ? "Opening game" : "Abriendo juego"; } }
    public static string OpenConsole { set { } get { return true ? "Opening console" : "Abriendo consola"; } }
    public static string OpenInspector { set { } get { return true ? "Opening inspector" : "Abriendo inspector"; } }
    public static string OpenExplorer { set { } get { return true ? "Opening file explorer" : "Abriendo explorador de archivos"; } }
    public static string OpeningUnsuportedScene { set { } get { return true ? "Opening unsuported window: " : "Abriendo ventana no soportada"; } }



    //Hierarchy controller
    public static string ChildrenList { set { } get { return true ? "has a total of " : " Tiene un total de "; } }
    public static string Children { set { } get { return true ? "children" : "hijos"; } }
    public static string HasParent { set { } get { return true ? "Has a parent" : "Tiene padre"; } }
    public static string IsAPrefab { set { } get { return true ? "Is a prefab" : "Es un prefab"; } }
    public static string NotAPrefab { set { } get { return true ? "Is not a prefab" : "No es un prefab"; } }
    public static string CurrentlyEditingPrefab { set { } get { return true ? "Editing prefab: " : "Editando prefab: "; } }
    public static string NoChildren { set { } get { return true ? "Has no children: " : "No tiene hijos: "; } }

    // project controller
    public static string LocationIs { set { } get { return true ? "Complete path is: " : "La direccion completa es: "; } }
    public static string ActualFolder { set { } get { return true ? "Actual folder is: " : "La carpeta actual es:  "; } }
    public static string ThisItemIs { set { } get { return true ? " is type " : " es del tipo "; } }
    public static string IsAScript { set { } get { return true ? "Script" : "Script"; } }
    public static string IsAFolder { set { } get { return true ? "folder" : "carpeta"; } }
    public static string IsAScene { set { } get { return true ? "scene" : "Escena"; } }
    public static string IsAnAudioMixer { set { } get { return true ? "Audio Mixer controller" : "Controlador de mezclador de audio"; } }
    public static string IsAShader { set { } get { return true ? "Shader" : "Shader"; } }
    public static string IsAGameObject { set { } get { return true ? "Game Object" : "Game Object"; } }
    public static string IsADLL { set { } get { return true ? "DLL" : "DLL"; } }
    public static string UnknownItem { set { } get { return true ? "Unknown" : "Desconocido"; } }

    // Console 
    public static string OnlyErrors { set { } get { return true ? "Only errors" : "Solo errores"; } }
    public static string OnlyWarnings { set { } get { return true ? "Only warnings" : "Solo advertencias"; } }
    public static string OnlyLogs { set { } get { return true ? "Only logs" : "Solo logs"; } }
    public static string OnlyExceptions { set { } get { return true ? "Only exceptions" : "Solo excepciones"; } }
    public static string OnlyAsserts { set { } get { return true ? "Only asserts" : "Solo asserts"; } }
    public static string All { set { } get { return true ? "All" : "Todo"; } }

    public static string readingAll { set { } get { return true ? "Reading full stacktrace: " : "Leyendo stacktrace completo "; } }
    public static string ErrorNumber { set { } get { return true ? "Error number " : "Error n�mero "; } }
    public static string Of { set { } get { return true ? " of " : " de "; } }

    // Inspector Window
    public static string thisDoesNothing { set { } get { return true ? "This button does nothing" : "Este bot�n no hace nada"; } }



    // Generic Documentation
    public static string salutation { set { } get { return true ? "Welcome to Unity's text-to-speech plug-in prototype, Navigate through the windows pressing control and numbers 1 through 5 or control shift c for console, "
        + "You'll need to navigate the Unity menu in order to test this plug-in, the orders for each of the windows will be explained by pressing control alt J;Go on, try and navigate through windows, " +
        "Use control alt V to get info for each window control, " :
        
        "Bienvenido al plug in prototipo de texto a voz de Unity. Navega a trav�s de las ventanas presionando el control y los n�meros 1 a 5, o Control, Shift, C para la consola"
        + "Necesitar�s navegar los men�s de Unity para poder probar este plug in, las instrucciones para cada una de las ventanas ser�n explicadas presionando control, alt, J; Adelante, intenta navegar a trav�s de las ventanas, " +
        "Usa control, alt, v para obtener la informaci�n de los controles de cada ventana"; }
    } 

    public static string infoAboutHierarchy { set { } get { return true ? "In the Hierarchy you'll need to be able to create an object, change its name and edit a prefab, " +
        "To do so you'll need to use commands Control G to create a cube and then press enter, Press F2 to change its name." :

        "En la jerarqu�a necesitar�s ser capaz de crear un objeto, cambiar su nombre y editar un prefab, " +
        "Para hacerlo necesitar�s usar Control, G, para crear un cubo y pulsar enter. Pulsar F2 para cambiar su nombre."; }
    } 

    public static string infoAboutProjectExplorer { set { } get { return true ? "In the project explorer you'll be able to navigate between items in the folders of the project, However it is a bit tricky, " +
        " To do so, after opening the explorer, you'll need to press left and right arrow keys to navigate between the items in the current folder, but to be able to change folder, you'll need to press tab" +
        "and then use up and down to navigate between folders, Sadly, the only way to know which folder is selected is by pressing Tab twice to select the first Item and use Control alt B to know the folder, " +
        "Before finishing, use control U to create an empty Prefab and type in a name" :

        "En el explorador del proyecto ser�s capaz de navegar a trav�s de los objetos en las carpetas del proyecto. Aun as� es un poco complicado actualmente." +
        "Para hacerlo, despues de abrir el explorador, necesitar�s pulsar las flechas de direcci�n lateral para navegar entre los objetos, pero para cambiar la carpeta, deber�s pulsar tab." +
        "Entonces usar las flechas de direcci�n vertical para navegar por las carpetas. Tristemente la �nica manera de saber que carpeta ha sido seleccionada es pulsando el Tab dos veces para seleccionar el primer Item y usar Control, alt, B para saber la carpeta" +
        "Antes de acabar, usa Control U para crear un prefab vac�o, y ponle un nombre."; } 
    } 

    public static string infoAboutLogConsole { set { } get { return true ? "This is the console log, you should be able to navigate through a few logs that have been created as a test, "
        + "To do that you'll need to press the info button and use the base controls on it, You should be able to understand the information of at least three logs, " :

        "Este es el registro de errores(Console log), deber�as ser capaz de navegar a trav�s de varios logs que se han creado como test."
        + "Para hacerlo necesitar�s presionar el bot�n de informaci�n y usar los controles base. Deber�as entender la informaci�n de al menos tres logs."; } 
    } 

    public static string infoAboutInspector { set { } get { return true ? "By pressing Control alt S you'll be able to check which object is currently selected, Select the cube you created on the Hierarchy and then " +
        "proceed to add a Rigidbody with control q, Once done this, use Tab until you hear any property, then use auxiliar button A to check its value, Then, keep tabbing until you reach the rigidbody" +
        "to then finish by activating the IsKinematic value, " :

        "Al presionar Control, alt, S, deber�as poder comprobar que objeto hay seleccionado ahora mismo. Selecciona el cubo que creaste en la jerarqu�a y" +
        "procede a a�adir un rigidbody con control q. Una vez hecho eso, usa Tab hasta que oigas una propiedad, y entonces usa Control, alt, S, para comprobar su valor. Entonces continua haciendo Tab hasta que alcances el rigidbody. Termina activando la opci�n Is Kinematic"; } 
    } 








    #region Information
    //Info
    public static string HierarchyInfo { set { } get { return true ? "Control alt S to know which object is selected, if it has a parent and how many children does it have. " +
        "Control alt D to hear the number of childs it has and enumerate them." +
        "Control alt A to hear the name of the parent object in case it exists." +
        "Control alt B to know what childs does that item have. " +
        "Control alt N to know if the object belongs to a prefab and, in case you're in edit mode, which one." :

        "Control, alt, S  para saber que objeto est� seleccionado, si tiene un padre y cuantos hijos posee." +
        "Control, alt, D para escuchar el numero de hijos que tiene y enumerarlos." + 
        "Control, alt, A para escuchar el nombre del objeto padre en caso que exista" + 
        "Control, alt, B para to saber que hijos tiene ese objeto. " +
        "Control, alt, N para saber si el objeto pertenece a un prefab y si est�s en modo edici�n, cual es."; }
    } 
    public static  string ProjectFolderInfo { set { } get { return true ? "Control alt S to know what object is selected and its extension." +
        "Control alt A to know the selected object's full path." +
        "Control alt B to know the folder of the current selected object." +
        "Control alt N to know if the object is a prefab." :
                 
        "Control, alt, S para saber que objeto est� seleccionado y su extensi�n." +
        "Control, alt, A para saber la direcci�n completa del elemento." +
        "Control, alt, B para saber la carpeta seleccionada actualmente." +
        "Control, alt, N para saber si el objeto es un prefab."; } 
    } 
                 
    public static string ConsoleInfo { set { } get { return true ? "Control alt S to know the actual log, what it says and the type." +
        "Control alt D to advance to the next log." +
        "Control alt A to return to the previous log." +
        "Control alt B to hear actual log path." +
        "Control alt N to hear the full stacktrace." +
        "Control alt M to modify the type of logs to check'." :
                 
        "Control, alt, S para conocer el log seleccionado, lo que dice y su tipo." +
        "Control, alt, D para avanzar al siguiente log." +
        "Control, alt, A para volver al anterior log." +
        "Control, alt, B para escuchar la direcci�n completa del log." +
        "Control, alt, N para escuchar el stacktrace completo." +
        "Control, alt, M para modificar el tipo de logs'."; } 
    } 


    public static string InspectorInfo { set { } get { return true ? "Control alt S to know the current selected item."  + 
        "control alt N to know the value of the current selected property" :

        "Control, alt, S, para saber el objeto seleccionado actualmente." +
        "control, alt, N, para saber el valor de la propiedad seleccionada actualmente.";
        } 
    } 


    public static string GameInfo { set { } get { return true ? "Unimplemented window" : "Este bot�n no hace nada"; } } 
    public static string SceneInfo { set { } get { return true ? "Unimplemented window" : "Este bot�n no hace nada"; } } 



    public const string profileID = "TTSSC";

    #endregion
}
#endif
