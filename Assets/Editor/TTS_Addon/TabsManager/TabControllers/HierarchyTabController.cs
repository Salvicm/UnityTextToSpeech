using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
public class HierarchyTabController : TabController
{
    static GameObject[] list;

    public HierarchyTabController()
    {
    }
    ~HierarchyTabController()
    {
    }
    public override void init()
    {
        // activeGameObject = Jerarquía
        // activeObject = Inspector
        list = new GameObject[SceneManager.GetActiveScene().rootCount];
        list = SceneManager.GetActiveScene().GetRootGameObjects();
        if(Selection.activeGameObject == null) 
            Selection.activeGameObject = list[0];
        Selection.selectionChanged += OnChangeSelection;


    }
    public override void advanceButton()
    {
        if (Selection.activeGameObject == null) return;
        if (Selection.activeGameObject.transform.childCount > 0) {
            Transform[] allChildren = Selection.activeGameObject.GetComponentsInChildren<Transform>();

            WindowsVoice.speak(Selection.activeGameObject.name + TextHolder.ChildrenList + Selection.activeGameObject.transform.childCount + TextHolder.Children);
            for (int i = 1; i < allChildren.Length; i++)
            {
                if(allChildren[i].gameObject.transform.parent.gameObject == Selection.activeGameObject.transform.gameObject)
                WindowsVoice.speak(allChildren[i].gameObject.name);
            }
        }
    }
    public override void regressionButton()
    {
        if (Selection.activeGameObject == null) return;
        if (Selection.activeGameObject.transform.parent != null)
            WindowsVoice.speak(TextHolder.HasParent + Selection.activeGameObject.transform.parent.name);
    }
    public override void generalButton()
    {
        if (Selection.activeGameObject == null) return;
        WindowsVoice.speak(Selection.activeGameObject.name);
        if (Selection.activeGameObject.transform.parent != null)
            WindowsVoice.speak(TextHolder.HasParent + Selection.activeGameObject.transform.parent.name);
        if (Selection.activeGameObject.transform.childCount > 0)
            WindowsVoice.speak(TextHolder.ChildrenList + Selection.activeGameObject.transform.childCount + TextHolder.Children);
    }
    public override void infoButton()
    {
        WindowsVoice.speak(TextHolder.HierarchyInfo);
    }
    public override void Update()
    {/*
        if (Selection.count == 0) return;
        else if(Selection.count == 1)
        {
            Debug.Log(Selection.activeObject.name);

        }else if(Selection.count > 1)
        {
            Debug.Log("Selected: " + Selection.count + " objects");
            // TODO Debería poder enumerar en lista la selección, cambiar el funcionamiento del botón general según si se está seleccionando mas de 
            // Un objeto
        }
        */
    }
    public override void buttonA()
    {
        /* Información necesaria:
         * Explicar todos los shortcuts de este modo, como por ejemplo abrir el editor de prefabs si un objeto es prefab
         * * Nombre del objeto ________________________________ General Button // Done
         * * Nombre del padre, si tiene _______________________ General Button / Regression button // Done
         * * Cantidad de hijos ________________________________ General Button / Advance Button  // Done
         * * * Listado de hijos _______________________________ Button A / Advance Button        // Done
         * * Nombre del siguiente y del anterior objeto? ______ Button B // No se si esto es posible // Falta
         * * Comprueba si es prefab y si estás en modo editar _ Button C // Con la P se abre el menú y con la O se cierra // Done
         * */
        if (Selection.activeGameObject == null) return;
        if (Selection.activeGameObject.transform.childCount > 0)
        {
            Transform[] allChildren = Selection.activeGameObject.GetComponentsInChildren<Transform>();
            for (int i = 1; i < allChildren.Length; i++)
            {
                if (allChildren[i].gameObject.transform.parent.gameObject == Selection.activeGameObject.transform.gameObject)
                    WindowsVoice.speak(allChildren[i].gameObject.name);
            }
        }
    }
    public override void buttonB()
    {
        if (Selection.activeGameObject == null) return;
    }
    public override void buttonC()
    {
        if (Selection.activeGameObject == null) return;
        //Es prefab el objeto seleccionado?
        if (PrefabUtility.GetPrefabAssetType(Selection.activeGameObject) != PrefabAssetType.NotAPrefab ||
            PrefabUtility.GetPrefabAssetType(Selection.activeGameObject) != PrefabAssetType.MissingAsset)
        {
            WindowsVoice.speak(TextHolder.IsAPrefab);
        }
        else
        {
            WindowsVoice.speak(TextHolder.NotAPrefab);
            return;
        }
        // Está editando ahora mismo prefab?
        if (EditorSceneManager.IsPreviewSceneObject(Selection.activeGameObject))
        {
            WindowsVoice.speak(TextHolder.CurrentlyEditingPrefab + Selection.activeGameObject.transform.root.name);
        }
    }

    public void OnChangeSelection()
    {
        if (Selection.activeGameObject == null) return;
        WindowsVoice.speak(Selection.activeGameObject.name);
    }

    public override void clean()
    {
        Selection.selectionChanged -= OnChangeSelection;
    }
}
