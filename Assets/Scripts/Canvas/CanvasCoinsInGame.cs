using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCoinsInGame : MonoBehaviour
{
    private EMController emController;

    [SerializeField] private Text canvasTextMoney = null;

    void Start(){
        emController = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<EMController>();
    }
    void FixedUpdate(){
        GetTextCanvas();

        canvasTextMoney.text = string.Format("{0:0.00}", emController.MoneyInGame);
    }

    void GetTextCanvas() {
        if (canvasTextMoney == null) {
            canvasTextMoney = transform.GetChild(0).GetComponent<Text>();
        }
    }
}
