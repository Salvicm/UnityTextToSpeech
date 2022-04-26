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
    abstract public void advanceButton();     // Estos tres irán en la parte de los inputs del MainController.cs
    abstract public void regressionButton();  // Estos tres irán en la parte de los inputs del MainController.cs
    abstract public void infoButton();        // Estos tres irán en la parte de los inputs del MainController.cs
    abstract public void generalButton();
    abstract public void buttonA(); // Por si necesito botones extras
    abstract public void buttonB(); // Por si necesito botones extras
    abstract public void buttonC(); // Por si necesito botones extras 
}
#endif


/*
 Si tengo que hacer que funcione constantemente seguramente deba usar
 una instancia en lugar de algo estático, desconozco si se puede dar una situación en la que la instancia se pierda, pero no debería.
    Si quiero que funcione bien, debo reestructurarlo para cada ventana, porque no se como hacerlo de forma genérica
public void Update(); // En el caso de la jerarquía puedo aplicar el event.mouseover, que creo que existe
public void init();
public void advanceButton();     // Estos tres irán en la parte de los inputs del MainController.cs
public void regressionButton();  // Estos tres irán en la parte de los inputs del MainController.cs
public void infoButton();        // Estos tres irán en la parte de los inputs del MainController.cs
public void generalButton();

public void buttonA(); // Por si necesito botones extras
public void buttonB(); // Por si necesito botones extras
public void buttonC(); // Por si necesito botones extras
El infoButton debería explicar la instrucción de ese tab
El tabController de la jerarquía en el update comprobará el actual seleccionado
 
 
 */