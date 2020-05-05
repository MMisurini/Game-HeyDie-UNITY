using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private float money = 0f;

    void Start() {
        money = ControllerSave.Instance.state.money;
    }

    public float Value{
        set { money = value; }
        get { return money; }
    }
}
