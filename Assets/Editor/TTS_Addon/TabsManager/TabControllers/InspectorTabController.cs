using UnityEditor;
public class InspectorTabController : TabController
{

    public static string prevSelectedLabel = "";
    public static string currentValueAsString = "";
    public static string elementSelected;
    public static string currentElementSelected { 
        get { return elementSelected; } 
        set { if (value != elementSelected) { elementSelected = value; WindowsVoice.speak(currentElementSelected); } } }
    public InspectorTabController()
    {
        
    }
    ~InspectorTabController()
    {

    }
    public override void init()
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
        WindowsVoice.speak(TextHolder.thisDoesNothing);

    }
    public override void regressionButton()
    {
        WindowsVoice.speak(TextHolder.thisDoesNothing);

    }

    public override void buttonA()
    {
        WindowsVoice.speak(prevSelectedLabel);
        WindowsVoice.speak(currentValueAsString);
    }

    public override void buttonB()
    {
        WindowsVoice.speak(TextHolder.thisDoesNothing);

    }

    public override void buttonC()
    {
        WindowsVoice.speak(TextHolder.thisDoesNothing);

    }

    public override void clean()
    {

    }
    public override void testInfo()
    {
        WindowsVoice.silence();
        WindowsVoice.speak(TextHolder.infoAboutInspector);
    }

}
