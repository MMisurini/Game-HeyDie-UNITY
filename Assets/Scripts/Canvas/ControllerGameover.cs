using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGameover : MonoBehaviour
{
    [SerializeField] private Text timerScore_txt;
    [SerializeField] private Text coinsScore_txt;
    [SerializeField] private Text expScore_txt;
    [Space(5)]
    [SerializeField] private Image expAtual_img;

    private GameObject controllerGame;
    private GameObject player;

    private float timerGame = 0f;

    private float moneyGame = 0f;
    private float xpGanho = 0f;

    private ControllerAdmob ad;


    void OnEnable() {
        controllerGame = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).gameObject;
        ad = GameObject.FindGameObjectWithTag("ControllerDontDestroy").transform.GetChild(0).GetComponent<ControllerAdmob>();
        player = GameObject.FindGameObjectWithTag("Player");

        ad.CreateAndLoadRewardedAdAgain();

        moneyGame = controllerGame.GetComponent<EMController>().MoneyInGame;
        timerGame = controllerGame.GetComponent<ButtonsHUDFingers>().TimerInGame;

        float value = moneyGame * (timerGame / 100);
        float total = moneyGame + value;
        xpGanho = (timerGame * 2) * 0.4f;

        coinsScore_txt.text = string.Format("{0:0.00}", total) + " coins";
        timerScore_txt.text = string.Format("{0:00}", timerGame) + " s";
        expScore_txt.text = "+ " + string.Format("{0:0.00}" , xpGanho) + " xp";

        player.GetComponent<MoneyController>().Value += total;
        player.GetComponent<LevelsController>().EXP = xpGanho;

        controllerGame.GetComponent<EMController>().MoneyInGame = 0;

        moneyGame = 0;
        xpGanho = 0;

    }

    void Update() {
        if (!controllerGame.GetComponent<ButtonsHUDFingers>().GetActive()) {
            if (player.GetComponent<LevelsController>().EXP >= player.GetComponent<LevelsController>().EXPAlvo)
                expAtual_img.fillAmount = 0;
            else
                expAtual_img.fillAmount = Mathf.MoveTowards(expAtual_img.fillAmount, Mathf.Clamp(player.GetComponent<LevelsController>().EXP / player.GetComponent<LevelsController>().EXPAlvo, 0, player.GetComponent<LevelsController>().EXPAlvo), 0.1f * Time.deltaTime);
        }    
    }
}
