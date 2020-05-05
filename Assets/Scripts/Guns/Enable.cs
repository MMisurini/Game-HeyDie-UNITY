using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    [SerializeField] private bool enable = false;

    public bool ChangeEnable{
        get{ return enable; }
        set { enable = value; }
    }
}
