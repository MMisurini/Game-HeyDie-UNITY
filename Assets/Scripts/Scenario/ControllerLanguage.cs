using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerLanguage : MonoBehaviour
{
    [SerializeField] private Image br = null;
    [SerializeField] private Image usa = null;

    void Awake(){
        Application.targetFrameRate = 60;

        switch (Application.systemLanguage){
            case SystemLanguage.Portuguese:
                br.color = new Color(0.278f, 0.161f, 0.082f, 1);
                break;
            case SystemLanguage.English:
                usa.color = new Color(0.278f, 0.161f, 0.082f, 1);
                break;
            default:

                break;
        }
    }

    void Update(){
        
    }

}
