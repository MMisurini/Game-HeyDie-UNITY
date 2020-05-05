using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMenu : MonoBehaviour
{
    private ControllerPags pagsController;

    void Start(){
        pagsController = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(1).GetComponent<ControllerPags>();
    }

    public void Return(){
        pagsController.GetAnimation().Play("FadeOut" + this.name);
    }
}
