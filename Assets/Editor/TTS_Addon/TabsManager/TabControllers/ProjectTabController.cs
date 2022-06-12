using UnityEngine;
using UnityEditor;
using System.IO;

public class ProjectTabController : TabController
{
    static GameObject[] list;

    public ProjectTabController()
    {
    }
    ~ProjectTabController()
    {
    }
    public override void init()
    {
        // activeGameObject = Jerarquía
        // activeObject = Inspector
        Selection.selectionChanged += OnChangeSelection;
        /* Información necesaria:
         * Explicar todos los shortcuts de este modo, como por ejemplo abrir el editor de prefabs si un objeto es prefab
         * * Nombre del objeto  // General
         * * Tipo del objeto    // General
         * * Path               // Button A
         * * Carpeta actual     // Button B
         * * Es un prefab       // Button C
         * * 
         * */

    }
    public override void advanceButton()
    {
        WindowsVoice.speak(TextHolder.thisDoesNothing);

    }
    public override void regressionButton()
    {
        if(Selection.activeObject == null) return;

        string[] _path = AssetDatabase.GetAssetPath(Selection.activeObject).Split('/');
        string newPath = "";
        for (int i = 0; i < _path.Length - 2; i++)
        {
            newPath += _path[i];
            newPath += "/";
        }
        newPath = newPath.Substring(0, newPath.Length - 1);
        Object obj = AssetDatabase.LoadAssetAtPath<Object>(newPath);

        Selection.activeObject = obj;
        WindowsVoice.silence();
        sayFolder(obj);

    }
    public override void generalButton()
    {
        if (Selection.activeObject == null) return;
        WindowsVoice.speak(Selection.activeObject.name);

        WindowsVoice.speak(TextHolder.ThisItemIs);
        switch (Selection.activeObject.GetType().Name)      
        {
            case "SceneAsset":
                WindowsVoice.speak(TextHolder.IsAScene);
                break;
            case "DefaultAsset":
                if (AssetDatabase.IsValidFolder(AssetDatabase.GetAssetPath(Selection.activeObject)))
                    WindowsVoice.speak(TextHolder.IsAFolder);
                else
                {

                    string extension = Path.GetExtension(AssetDatabase.GetAssetPath(Selection.activeObject)).ToLowerInvariant();
                    if (extension == ".dll" || extension == ".so") {
                        WindowsVoice.speak(TextHolder.IsADLL);
                    }
                    else 
                        WindowsVoice.speak(TextHolder.UnknownItem);
                }
                break;
            case "MonoScript":
                WindowsVoice.speak(TextHolder.IsAScript);
                break;
            case "GameObject":
                WindowsVoice.speak(TextHolder.IsAGameObject);
                if (PrefabUtility.GetPrefabAssetType(Selection.activeGameObject) != PrefabAssetType.NotAPrefab)
                    WindowsVoice.speak(TextHolder.IsAPrefab);
                break;
            case "Shader":
                WindowsVoice.speak(TextHolder.IsAShader);
                break;
            case "AudioMixerController":
                WindowsVoice.speak(TextHolder.IsAnAudioMixer);

                break;
            default:
                
                WindowsVoice.speak(Selection.activeObject.GetType().Name);
                break;
        }
    }
    public override void infoButton()
    {
        WindowsVoice.speak(TextHolder.ProjectFolderInfo);
    }
    public override void Update() 
    {
    }
    public override void buttonA()
    {
        
        if (Selection.activeObject == null) return;
        WindowsVoice.speak(TextHolder.LocationIs);
        string[] _path = AssetDatabase.GetAssetPath(Selection.activeObject).Split('/');
        _path[_path.Length - 1] = _path[_path.Length -1].Split('.')[0];
        foreach (string item in _path)
        {
            WindowsVoice.speak(item);
        }
    }
    public override void buttonB()
    {
        if (Selection.activeObject == null) return;
        string[] _path = AssetDatabase.GetAssetPath(Selection.activeObject).Split('/');
        WindowsVoice.speak(TextHolder.ActualFolder);
        WindowsVoice.speak(_path[_path.Length - 2]);
    }
    public void sayFolder(Object obj)
    {
        string[] _path = AssetDatabase.GetAssetPath(obj).Split('/');
        WindowsVoice.speak(_path[_path.Length - 2]);
    }
    public override void buttonC()
    {
        if (Selection.activeObject == null) return;
        Debug.Log(PrefabUtility.GetPrefabAssetType(Selection.activeObject));
        if (PrefabUtility.GetPrefabAssetType(Selection.activeObject) != PrefabAssetType.NotAPrefab && 
            PrefabUtility.GetPrefabAssetType(Selection.activeObject) != PrefabAssetType.MissingAsset)
        {
            WindowsVoice.speak(TextHolder.IsAPrefab);
        }
        else
        {
            WindowsVoice.speak(TextHolder.NotAPrefab);
        }
        
    }

    public void OnChangeSelection()
    {
        if (Selection.activeObject == null) return;
        WindowsVoice.speak(Selection.activeObject.name);
   
    }

    public override void clean()
    {
        Selection.selectionChanged -= OnChangeSelection;
    }
    public override void testInfo()
    {
        WindowsVoice.silence();
        WindowsVoice.speak(TextHolder.infoAboutProjectExplorer);
    }
}

