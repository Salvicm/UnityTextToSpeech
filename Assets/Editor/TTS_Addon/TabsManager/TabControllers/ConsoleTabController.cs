using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEditor.UI;
using UnityEditor.UIElements;


public class ConsoleTabController : TabController
{
    
    public enum typeOfSelection { All, OnlyErrors, OnlyWarnings, OnlyLogs, OnlyExceptions, OnlyAsserts, Count }
    public typeOfSelection selectionType = typeOfSelection.All;
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
        Debug.LogError("B");
        Debug.LogWarning("C");
        currentSelected = MainController.ErrorLogs.Count > 0 ? MainController.ErrorLogs.Count - 1 : 0;
        return;
    }
 
    public override void advanceButton()
    {
        if (MainController.ErrorLogs.Count == 0) return;
        SelectNext(1);
        WindowsVoice.silence();
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].value);
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].type.ToString());
    }
    public override void regressionButton()
    {
        if (MainController.ErrorLogs.Count == 0) return;
        SelectNext(-1);
        WindowsVoice.silence();
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].value);
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].type.ToString());
    }
    public override void generalButton()
    {
        if (MainController.ErrorLogs.Count == 0) return;
        // Debug Current
        WindowsVoice.silence();
        WindowsVoice.speak(TextHolder.ErrorNumber + (currentSelected + 1).ToString() + TextHolder.Of + MainController.ErrorLogs.Count.ToString());
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].value);
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].type.ToString());

    }
    public override void infoButton()
    {
        WindowsVoice.silence();
        WindowsVoice.speak(TextHolder.ConsoleInfo);
    }
    public override void Update()
    {

        

       
    }
    public override void buttonA()
    {
        if (MainController.ErrorLogs.Count == 0) return;
        WindowsVoice.silence();
        WindowsVoice.speak(MainController.ErrorLogs[currentSelected].fullPath);
    }
    public override void buttonB()
    {
        // Read full callback
        if (MainController.ErrorLogs.Count == 0) return;
        WindowsVoice.silence();
        WindowsVoice.speak(TextHolder.readingAll);


        for (int i = 1; i < MainController.ErrorLogs[currentSelected].logPath.Length - 1; i++)
        {
            WindowsVoice.speak(MainController.ErrorLogs[currentSelected].logPath[i]);
        }
        
    }
    public override void buttonC()
    {

        selectionType = (typeOfSelection)(((int)selectionType + 1) % (int)typeOfSelection.Count);
        WindowsVoice.silence();
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

        if (MainController.ErrorLogs.Count == 0 || MainController.ErrorLogs.Count == 1) return;
        int prevCurrentSelected = currentSelected;
        currentSelected = (currentSelected + x);
        if (currentSelected < 0)
            currentSelected += MainController.ErrorLogs.Count;
        currentSelected %= (MainController.ErrorLogs.Count);
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
                if (currentSelected < 0)
                    currentSelected += MainController.ErrorLogs.Count;
                currentSelected += x;
                currentSelected %= (MainController.ErrorLogs.Count);
            }
        }
    }
    public override void clean()
    {
        
    }

}
