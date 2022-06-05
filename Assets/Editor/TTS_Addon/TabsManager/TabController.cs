#if (UNITY_EDITOR) 
using UnityEngine;

abstract public class TabController
{
    public TabController()
    {

    }
    abstract public void Update(); 
    abstract public void init();
    abstract public void advanceButton();     // Estos tres irán en la parte de los inputs del MainController.cs
    abstract public void regressionButton();  // Estos tres irán en la parte de los inputs del MainController.cs
    abstract public void infoButton();        // Estos tres irán en la parte de los inputs del MainController.cs
    abstract public void generalButton();
    abstract public void buttonA(); // Por si necesito botones extras
    abstract public void buttonB(); // Por si necesito botones extras
    abstract public void buttonC(); // Por si necesito botones extras 
    abstract public void clean();
    abstract public void testInfo();
}
#endif


