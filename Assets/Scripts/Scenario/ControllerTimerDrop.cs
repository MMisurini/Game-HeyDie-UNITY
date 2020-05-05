using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTimerDrop : MonoBehaviour {
    private ControllerDrop control;

    [SerializeField] private float timerAlvo;

    private int qntInt = 0;
    private float timerDeltatime = 0;
    private bool isActive = false;

    private int qntBallAlvo = 5;

    void OnEnable() {
        control = GetComponent<ControllerDrop>();

        timerAlvo = 30;
    }

    void Update(){
        if(isActive)
            ControlerTime(Time.deltaTime);    
    }

    void ControlerTime(float value) {
        timerDeltatime += value;

        if(timerDeltatime > timerAlvo) {

            if (control.SimpleAttack.MoveSpeedY < 0.25f)
                control.SimpleAttack.MoveSpeedY += 0.02f;

            MultipliAlvo(control.SimpleAttack.MoveSpeedY);
        }
    }


    private void MultipliAlvo(float value) {
        timerAlvo += value + 0.25f;

        qntInt++;

        if (qntInt > qntBallAlvo) {
            control.QuantBallsDrop -= Random.Range(0.08f, 0.2f);
            qntBallAlvo -= 1;
        }

        timerDeltatime = 0;
    }

    public bool IsActive {
        set { isActive = value; }
    }
}
