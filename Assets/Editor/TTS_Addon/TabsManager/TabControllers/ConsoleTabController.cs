using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConsoleTabController : TabController
{
    

    public ConsoleTabController()
    {
        
    }
    ~ConsoleTabController()
    {
    }
    public override void init()
    {
        //Debug.Log(Selection.activeContext.name);
        return;
    }
    public override void advanceButton()
    {
        Debug.Log("A");
        return;
    }
    public override void regressionButton()
    {
        Debug.LogWarning("B");
        return;
    }
    public override void generalButton()
    {
        Debug.LogError("C");
        //Debug.Log(Selection.activeContext.name);

        return;
    }
    public override void infoButton()
    {
        Debug.Log(MainController.test.Count);
        //WindowsVoice.speak(TextHolder.ConsoleInfo);
    }
    public override void Update()
    {
        return;
    }
    public override void buttonA()
    {
        /* Información necesaria:
         * Explicar todos los shortcuts de este modo, como por ejemplo abrir el editor de prefabs si un objeto es prefab
         * * Contar cuantos errores, warnings y logs hay ______ General Button
         * * Leer el último log hecho _________________________ Button A 
         * * Decir el tipo de último log ______________________ Button B
         * */
       
    }
    public override void buttonB()
    {
        return;
    }
    public override void buttonC()
    {
        return;
    }

   
    public override void clean()
    {
        return;
    }
}
