using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
public class InspectorTabController : TabController
{

    public InspectorTabController()
    {
        
    }
    ~InspectorTabController()
    {

    }
    public override void init()
    {
        //System.Reflection.FieldInfo info = typeof(EditorApplication)
        //      .GetField("globalEventHandler", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        //EditorApplication.CallbackFunction value = (EditorApplication.CallbackFunction)info.GetValue(null);
        //value += eventHandle;

    }
    public void eventHandle()
    {
        
    }
    public override void Update()
    {
    }
    public override void generalButton()
    {
        if (Selection.activeGameObject == null) return;
        WindowsVoice.speak(Selection.activeGameObject.name);
    }

    public override void infoButton()
    {
        WindowsVoice.speak(TextHolder.InspectorInfo);
    }
    public override void advanceButton()
    {
    }
    public override void regressionButton()
    {
    }

    public override void buttonA()
    {
    }

    public override void buttonB()
    {
    }

    public override void buttonC()
    {
    }

    public override void clean()
    {
        //System.Reflection.FieldInfo info = typeof(EditorApplication)
        //     .GetField("globalEventHandler", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        //EditorApplication.CallbackFunction value = (EditorApplication.CallbackFunction)info.GetValue(null);
        //value -= eventHandle;
    }


}
