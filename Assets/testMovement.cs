using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovement : MonoBehaviour
{

    void Update()
    {
        this.transform.Rotate(new Vector3(50.0f * Time.deltaTime, 20.0f * Time.deltaTime, -10.0f * Time.deltaTime));
    }
}
