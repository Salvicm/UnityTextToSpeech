using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.UI;
using System;

[InitializeOnLoad]
public static class WindowsVoice {
    [DllImport("WindowsVoice")] public static extern void initSpeech();
    [DllImport("WindowsVoice")] public static extern void destroySpeech();
    [DllImport("WindowsVoice")] public static extern void addToSpeechQueue(string s);
    [DllImport("WindowsVoice")] public static extern void clearSpeechQueue();
    [DllImport("WindowsVoice")] public static extern void statusMessage(StringBuilder str, int length);
    [DllImport("WindowsVoice")] public static extern void silenceQueue();

    private static readonly Destructor Finalise = new Destructor();

    static WindowsVoice()
    {
        initSpeech();
    }
    private sealed class Destructor
    {
        ~Destructor()
        {
            // One time only destructor.
            destroySpeech();

        }
    }
    public static void speak(string msg, float delay = 0f) {

        if (SessionState.GetBool("CanSpeak", true) == false)
        {
            return;
        }
        if (delay == 0f)
        {
            if(Application.systemLanguage == SystemLanguage.English)
                addToSpeechQueue("<RATE ABSSPEED=\"-1\"><VOICE REQUIRED=\"language=409\">" + msg + "</VOICE></RATE>"); 
            else
            addToSpeechQueue("<RATE ABSSPEED=\"-1\">" + msg + "</RATE>");
        }
        
    }
    public static void silence()
    {
        WindowsVoice.clearSpeechQueue();
        WindowsVoice.silenceQueue();
        WindowsVoice.speak(TextHolder.voidText);

    }
    public static string GetStatusMessage()
    {
      StringBuilder sb = new StringBuilder(40);
      statusMessage(sb, 40);
      return sb.ToString();
    }
    public static void testFunct()
    {
        Debug.Log("this is a test");
    }

    internal static void speak(object noChildren)
    {
        throw new NotImplementedException();
    }
}
