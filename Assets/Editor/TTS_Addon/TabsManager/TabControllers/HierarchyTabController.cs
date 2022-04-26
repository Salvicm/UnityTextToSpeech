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
        Selection.selectionChanged += OnChangeSelection;
    }
    ~HierarchyTabController()
    {
    }
    public override void init()
    {
        // activeGameObject = Jerarqu�a
        // activeObject = Inspector
        Debug.Log("Initting Hierarchy tab controller");
        list = new GameObject[SceneManager.GetActiveScene().rootCount];
        list = SceneManager.GetActiveScene().GetRootGameObjects();
        if(Selection.activeGameObject == null) 
            Selection.activeGameObject = list[0];
        
        
    }
    public override void advanceButton()
    {
        if (Selection.activeGameObject.transform.childCount > 0) {
            Transform[] allChildren = Selection.activeGameObject.GetComponentsInChildren<Transform>();

            Debug.Log("- Object: " + Selection.activeGameObject.name + " has: " + Selection.activeGameObject.transform.childCount + " children");

            Debug.Log("-- Child Names:");
            for (int i = 1; i < allChildren.Length; i++)
            {
                if(allChildren[i].gameObject.transform.parent.gameObject == Selection.activeGameObject.transform.gameObject)
                    Debug.Log("--- " + allChildren[i].gameObject.name);
            }
        }
    }
    public override void regressionButton()
    {
        Debug.Log("Regress");
    }
    public override void generalButton()
    {
        Debug.Log("__________");
        Debug.Log("- Object: " + Selection.activeGameObject.name);
        if (Selection.activeGameObject.transform.parent != null)
            Debug.Log("-- Parent: " + Selection.activeGameObject.transform.parent.name);
        if (Selection.activeGameObject.transform.childCount > 0)
            Debug.Log("-- Number of children: " + Selection.activeGameObject.transform.childCount);
    }
    public override void infoButton()
    {
        
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
            // TODO Deber�a poder enumerar en lista la selecci�n, cambiar el funcionamiento del bot�n general seg�n si se est� seleccionando mas de 
            // Un objeto
        }
        */
    }
    public override void buttonA()
    {
        /* Informaci�n necesaria:
         * Explicar todos los shortcuts de este modo, como por ejemplo abrir el editor de prefabs si un objeto es prefab
         * * Nombre del objeto ________________________________ General Button // Done
         * * Nombre del padre, si tiene _______________________ General Button / Regression button // Falta
         * * Cantidad de hijos ________________________________ General Button / Advance Button  // Done
         * * * Listado de hijos _______________________________ Button A / Advance Button        // Done
         * * Nombre del siguiente y del anterior objeto? ______ Button B // No se si esto es posible // Falta
         * * Comprueba si es prefab y si est�s en modo editar _ Button C // Con la P se abre el men� y con la O se cierra // TODO Ver si puedo asignarlo por c�digo, la O no est� de base. O cerrarlo por c�digo
         */
        if (Selection.activeGameObject.transform.childCount == 0) return;
        Transform[] allChildren = Selection.activeGameObject.GetComponentsInChildren<Transform>();
        Debug.Log("__________");

        Debug.Log("- Child Names for: " + Selection.activeGameObject.name);
        for (int i = 1; i < allChildren.Length; i++)
        {
            if (allChildren[i].gameObject.transform.parent.gameObject == Selection.activeGameObject.transform.gameObject)
                Debug.Log("-- " + allChildren[i].gameObject.name);
        }
    }
    public override void buttonB()
    {
    }
    public override void buttonC()
    {
        if (PrefabUtility.GetPrefabAssetType(Selection.activeGameObject) != PrefabAssetType.NotAPrefab ||
            PrefabUtility.GetPrefabAssetType(Selection.activeGameObject) != PrefabAssetType.MissingAsset)
        {
            Debug.Log("Is a prefab");
        }
        else
        {
            Debug.Log("Not a prefab");
        }
        if (EditorSceneManager.IsPreviewSceneObject(Selection.activeGameObject))
        {
            Debug.Log("Editing prefab");
        }
    }

    public void OnChangeSelection()
    {
        if (Selection.activeGameObject == null) return;
        Debug.Log(Selection.activeObject.name);
    }

    public override void clean()
    {
        Selection.selectionChanged -= OnChangeSelection;
    }
}
