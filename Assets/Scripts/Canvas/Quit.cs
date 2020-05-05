using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField] private GameObject checkQuit;

    public void Sair() {
        checkQuit.SetActive(true);
    }

    public void CheckQuit(string value) {
        if(value == "Yes") {
            Application.Quit();
        } else {
            checkQuit.SetActive(false);
        }
    }
}
