using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEditor.UI;
using UnityEditor.UIElements;


public class ConsoleTabController : TabController
{
    
    public enum typeOfSelection {OnlyErrors, OnlyWarnings, OnlyLogs, OnlyExceptions, OnlyAsserts, All, Count }
    public typeOfSelection selectionType = typeOfSelection.OnlyErrors;
    public int currentSelected = 0;

    /*
     * Tener una lista para todos los logs, con mayor capacidad de logs
     * Inicializar el valor al máximo
     * Al leer, switchear el tipo
     * Hacer una iteración al ir sumando o bajando, hasta encontrar el siguiente del tipo preseleccionado
     * Si no se encuentra, se mantiene el último seleccionado
     * Al inicializarlo, comprobar si el stacktrace es igual al anterior
     * 
     */

    public ConsoleTabController()
    {
        
    }
    ~ConsoleTabController()
    {
    }
    public override void init()
    {
        Debug.Log("A");
        Debug.LogWarning("E");
        Debug.LogError("O");
        currentSelected = MainController.ErrorLogs.Count - 1;
        return;
    }
 
    public override void advanceButton()
    {
        SelectNext(1);
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].value);
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].type.ToString());
    }
    public override void regressionButton()
    {

        SelectNext(-1);
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].value);
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].type.ToString());
    }
    public override void generalButton()
    {
        // Debug Current
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].value);
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].type.ToString());

    }
    public override void infoButton()
    {
        WindowsVoice.speak(TextHolder.ConsoleInfo);
    }
    public override void Update()
    {

        

       
    }
    public override void buttonA()
    {
        /* Información necesaria:
         * Explicar todos los shortcuts de este modo, como por ejemplo abrir el editor de prefabs si un objeto es prefab
         * * Leer el actual ----------------------------------- General Button
         * * Contar cuantos errores, warnings y logs hay ______ Button A
         * */
        


    }
    public override void buttonB()
    {
        
    }
    public override void buttonC()
    {
        selectionType = (typeOfSelection)(((int)selectionType + 1) % (int)typeOfSelection.Count);
        switch (selectionType)
        {
            case typeOfSelection.OnlyErrors:
                WindowsVoice.speak(TextHolder.OnlyErrors);
                break;
            case typeOfSelection.OnlyWarnings:
                WindowsVoice.speak(TextHolder.OnlyWarnings);
                break;
            case typeOfSelection.OnlyLogs:
                WindowsVoice.speak(TextHolder.OnlyLogs);
                break;
            case typeOfSelection.OnlyExceptions:
                WindowsVoice.speak(TextHolder.OnlyExceptions);
                break;
            case typeOfSelection.OnlyAsserts:
                WindowsVoice.speak(TextHolder.OnlyAsserts);
                break;
            case typeOfSelection.All:
                WindowsVoice.speak(TextHolder.All);
                break;
            default:
                break;
        }
        SelectNext(-1);
    }

    public void SelectNext(int x)
    {
        int prevCurrentSelected = currentSelected;
        currentSelected = (currentSelected + x) % (MainController.ErrorLogs.Count - 1);
        LogType type = LogType.Log;
        switch (selectionType)
        {
            case typeOfSelection.OnlyErrors:
                type = LogType.Error;
                break;
            case typeOfSelection.OnlyWarnings:
                type = LogType.Warning;
                break;
            case typeOfSelection.OnlyLogs:
                type = LogType.Log;
                break;
            case typeOfSelection.OnlyExceptions:
                type = LogType.Exception;
                break;
            case typeOfSelection.OnlyAsserts:
                type = LogType.Assert;
                break;
            default:
                break;
        }

        if (selectionType != typeOfSelection.All)
        {
            while (prevCurrentSelected != currentSelected && MainController.ErrorLogs[currentSelected].type != type)
            {
                currentSelected += x;
                if (currentSelected < 0)
                    currentSelected = MainController.ErrorLogs.Count - 1;
                currentSelected %= (MainController.ErrorLogs.Count);
            }
        }
    }
    public override void clean()
    {
        
    }
    public void getErrorLocation()
    {
        // Get script, function and line
    }
}
