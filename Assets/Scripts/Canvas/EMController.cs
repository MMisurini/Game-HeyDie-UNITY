using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMController : MonoBehaviour
{
    [SerializeField] private GameObject money;
    [SerializeField] private float timerMoney = 4f;
    private float exp;

    [SerializeField] private float moneyGame = 0;

    private bool isDrop = true;

    public void Drop() {
        if (isDrop) {
            GameObject a = Instantiate(money, money.GetComponent<Coins>().Spawn(), money.transform.rotation);
            a.name = "Coin";
            a.transform.SetParent(GameObject.FindGameObjectWithTag("Scenario").transform);

            StartCoroutine(DropProjetil(timerMoney));

            isDrop = false;
        }
    }

    public void ClearListCoins() {
        GameObject[] a = new GameObject[GameObject.FindGameObjectWithTag("Scenario").transform.childCount - 1];
        for (int i = 0;i < GameObject.FindGameObjectWithTag("Scenario").transform.childCount - 1;i++) {
            if(GameObject.FindGameObjectWithTag("Scenario").transform.GetChild(i).name == "Coin")
                Destroy( GameObject.FindGameObjectWithTag("Scenario").transform.GetChild(i).gameObject);
        }
    }

    IEnumerator DropProjetil(float repeat) {
        yield return new WaitForSeconds(repeat);
        isDrop = true;
    }

    public float MoneyInGame{
        set { moneyGame = value; }
        get { return moneyGame; }
    }
}
