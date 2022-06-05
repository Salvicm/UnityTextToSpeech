using UnityEngine;

public class ConsoleTabController : TabController
{
    
    public enum typeOfSelection { All, OnlyErrors, OnlyWarnings, OnlyLogs, OnlyExceptions, OnlyAsserts, Count }
    public typeOfSelection selectionType = typeOfSelection.All;
    public int currentSelected = 0;


    public ConsoleTabController()
    {
        Debug.Log("This is a log Debug");
        Debug.LogError("This is an error Debug");
        Debug.LogWarning("This is a warning Debug");
        Debug.Log("This is another log debug");
        Debug.LogError("This is another error debug");
        Debug.LogWarning("This is another warning debug");
        
    }
    ~ConsoleTabController()
    {
    }
    public override void init()
    {
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
    public override void testInfo()
    {
        WindowsVoice.silence();
        WindowsVoice.speak(TextHolder.infoAboutLogConsole);
    }
}
