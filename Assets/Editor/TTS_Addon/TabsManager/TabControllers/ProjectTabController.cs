using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
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
        if (Selection.activeObject == null) return;
       

        //    WindowsVoice.speak(Selection.activeGameObject.name + TextHolder.ChildrenList + Selection.activeGameObject.transform.childCount + TextHolder.Children);
        //    for (int i = 1; i < allChildren.Length; i++)
        //    {
        //        if (allChildren[i].gameObject.transform.parent.gameObject == Selection.activeGameObject.transform.gameObject)
        //            WindowsVoice.speak(allChildren[i].gameObject.name);
        //    }
        //}
    }
    public override void regressionButton()
    {
        if (Selection.activeGameObject == null) return;
        //if (Selection.activeGameObject.transform.parent != null)
        //    WindowsVoice.speak(TextHolder.HasParent + Selection.activeGameObject.transform.parent.name);
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
    public override void Update() { }
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
    public override void buttonC()
    {
        if (Selection.activeObject == null) return;
        Debug.Log(PrefabUtility.GetPrefabAssetType(Selection.activeObject));
        if (PrefabUtility.GetPrefabAssetType(Selection.activeObject) != PrefabAssetType.NotAPrefab && 
            PrefabUtility.GetPrefabAssetType(Selection.activeObject) != PrefabAssetType.MissingAsset)
        {
            Debug.Log(TextHolder.IsAPrefab);
        }
        else
        {
            Debug.Log(TextHolder.NotAPrefab);
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
}
