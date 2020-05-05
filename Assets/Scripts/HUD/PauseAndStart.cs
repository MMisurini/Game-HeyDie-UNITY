using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndStart : MonoBehaviour
{
    public void pAnds(){
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
