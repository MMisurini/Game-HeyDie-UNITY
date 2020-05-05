using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCoinsPlayer : MonoBehaviour
{
    private MoveController playerController;

    [SerializeField] private Text canvasTextMoney = null;

    void Start(){
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>();    
    }
    void FixedUpdate(){
        canvasTextMoney.text = string.Format("{0:00.00}",playerController.GetMoney());
    }
}
