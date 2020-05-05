using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageOptions : MonoBehaviour
{
    [SerializeField] private GameObject[] pagsOptions;
    [SerializeField] private GameObject[] buttonsOptions;

    void OnEnable() {

        for (int i = 0;i < pagsOptions.Length;i++) {
            if(pagsOptions[i].name != "Credits") {
                pagsOptions[i].SetActive(false);
                buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color = new Color(buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.r, buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.g, buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.b,0.5f);
                buttonsOptions[i].GetComponent<Image>().color = new Color(1,1,1,0.5f);
            }
        }
    }

    public void IndexButtonPags(int index) {
        for (int i = 0;i < pagsOptions.Length;i++) {
            if(pagsOptions[i] == pagsOptions[index]) {
                pagsOptions[i].SetActive(true);
                buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color = new Color(buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.r, buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.g, buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.b, 1f);
                buttonsOptions[i].GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            } else {
                pagsOptions[i].SetActive(false);
                buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color = new Color(buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.r, buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.g, buttonsOptions[i].transform.GetChild(0).GetComponent<Text>().color.b, 0.5f);
                buttonsOptions[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            }
        }
    }
}
