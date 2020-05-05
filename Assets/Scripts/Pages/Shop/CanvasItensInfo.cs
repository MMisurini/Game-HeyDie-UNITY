using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasItensInfo : MonoBehaviour
{
    [SerializeField] private GameObject objectItem;
    [Space(10)]
    [SerializeField] private Text money;
    [SerializeField] private Text titleName;
    [SerializeField] private Text levelName;

    private ControllerMaps maps;

    private void OnEnable() {
        titleName = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        money = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>();
        levelName = transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>();
        

        CheckItensInfo(objectItem);
    }

    void CheckItensInfo(GameObject obj) {
        
    }
}