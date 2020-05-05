using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasItensMapsInfo : MonoBehaviour
{
    [SerializeField] private TypeSceneario type;
    [Space(10)]
    [SerializeField] private Text money;
    [SerializeField] private Text titleName;
    [SerializeField] private Text levelName;
    [SerializeField] private Text buttonBought;

    [SerializeField] private GameObject mapsSeletec;
    private ControllerMaps maps;

    private void OnEnable() {
        maps = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(1).GetComponent<ControllerMaps>();

        titleName = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        levelName = transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>();
        money = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>();
        buttonBought = transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();

        CheckMapInfo(maps);
    }

    void CheckMapInfo(ControllerMaps value) {
        for (int i = 0;i < value.GetMapsSelect .Length;i++) {
            if(value.GetMapsSelect[i].GetComponent<Scenario>().GetTypeScenario == type) {
                titleName.text = type.ToString().ToUpper();
                levelName.text = "LEVEL: " + value.GetMapsSelect[i].GetComponent<Scenario>().GetScenarioLvl();
                money.text = "PRICE: $" + value.GetMapsSelect[i].GetComponent<Scenario>().GetScenarioCoin();

                mapsSeletec = value.GetMapsSelect[i];

                if (value.GetMapsSelect[i].GetComponent<Scenario>().Bought) {
                    buttonBought.text = "BOUGHT";
                    buttonBought.color = new Color(buttonBought.color.r, buttonBought.color.g, buttonBought.color.b,0.5f);
                    buttonBought.transform.parent.parent.GetComponent<Button>().interactable = false;
                } else {
                    buttonBought.text = "BUY";
                }
            }
        }
    }
}