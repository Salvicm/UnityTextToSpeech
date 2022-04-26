#if (UNITY_EDITOR) 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TabController
{
    public TabController()
    {

    }
    abstract public void Update(); 
    abstract public void init();
    abstract public void advanceButton();     // Estos tres ir�n en la parte de los inputs del MainController.cs
    abstract public void regressionButton();  // Estos tres ir�n en la parte de los inputs del MainController.cs
    abstract public void infoButton();        // Estos tres ir�n en la parte de los inputs del MainController.cs
    abstract public void generalButton();
    abstract public void buttonA(); // Por si necesito botones extras
    abstract public void buttonB(); // Por si necesito botones extras
    abstract public void buttonC(); // Por si necesito botones extras 
}
#endif


/*
 Si tengo que hacer que funcione constantemente seguramente deba usar
 una instancia en lugar de algo est�tico, desconozco si se puede dar una situaci�n en la que la instancia se pierda, pero no deber�a.
    Si quiero que funcione bien, debo reestructurarlo para cada ventana, porque no se como hacerlo de forma gen�rica
public void Update(); // En el caso de la jerarqu�a puedo aplicar el event.mouseover, que creo que existe
public void init();
public void advanceButton();     // Estos tres ir�n en la parte de los inputs del MainController.cs
public void regressionButton();  // Estos tres ir�n en la parte de los inputs del MainController.cs
public void infoButton();        // Estos tres ir�n en la parte de los inputs del MainController.cs
public void generalButton();

public void buttonA(); // Por si necesito botones extras
public void buttonB(); // Por si necesito botones extras
public void buttonC(); // Por si necesito botones extras
El infoButton deber�a explicar la instrucci�n de ese tab
El tabController de la jerarqu�a en el update comprobar� el actual seleccionado
 
 
 */