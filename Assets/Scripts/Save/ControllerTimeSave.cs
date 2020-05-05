using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerTimeSave : MonoBehaviour
{
    [SerializeField] private float timerDelaySave = 5f;
    private float timer = 0;

    private GameObject player;
    [SerializeField] private GameObject valueToggle;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate(){

        if (valueToggle.GetComponent<Toggle>().isOn) {
            timer += Time.deltaTime;
            if (timer > ControllerSave.Instance.state.saveTimer) {

                ControllerSave.Instance.state.money = player.GetComponent<MoneyController>().Value;
                ControllerSave.Instance.state.exp = player.GetComponent<LevelsController>().EXP;
                ControllerSave.Instance.state.level = player.GetComponent<LevelsController>().GetLevel;

                ControllerSave.Instance.Save();

                timer = 0;
            }
        }
    }

}
