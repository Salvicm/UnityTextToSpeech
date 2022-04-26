using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyTabController : TabController
{
    public override void init()
    {
        Debug.Log("Initting Hierarchy tab controller");
    }
    public override void advanceButton()
    {
        Debug.Log("Advance");
    }
    public override void regressionButton()
    {
        Debug.Log("Regress");
    }
    public override void generalButton()
    {
        Debug.Log("General Button");
    }
    public override void infoButton()
    {
        Debug.Log("Info Button");
    }
    public override void Update()
    {
    }
    public override void buttonA()
    {
        Debug.Log("Button A");
    }
    public override void buttonB()
    {
        Debug.Log("Button B");
    }
    public override void buttonC()
    {
        Debug.Log("Button C");
    }
}
