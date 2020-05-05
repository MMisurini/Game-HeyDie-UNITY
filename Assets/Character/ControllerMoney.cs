using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMoney : MonoBehaviour
{
    [SerializeField] private float money = 0f;

    void Update(){
        
    }

    public float Value{
        set { money = value; }
        get { return money; }
    }
}
