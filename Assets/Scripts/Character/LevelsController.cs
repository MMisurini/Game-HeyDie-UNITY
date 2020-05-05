using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private int levelAtual = 0;
    private float expAtual = 0;
    [SerializeField] private float expAlvo = 250;

    private float multiplyExp = 1.65f;
    private float xpGanho = 0;

    [SerializeField] private Image expAtual_img = null;
    [SerializeField] private Text expAtual_txt = null;
    [SerializeField] private Text expAlvo_txt = null;
    [SerializeField] private Text lvlAtual_txt = null;

    void Start(){
        expAtual = ControllerSave.Instance.state.exp;
        levelAtual = ControllerSave.Instance.state.level;

        expAtual_img = GameObject.FindGameObjectWithTag("Exp").transform.GetChild(1).GetComponent<Image>();

        expAtual_txt = GameObject.FindGameObjectWithTag("Exp").transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
        expAlvo_txt = GameObject.FindGameObjectWithTag("Exp").transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>();
        lvlAtual_txt = GameObject.FindGameObjectWithTag("Profiler").transform.GetChild(1).GetChild(0).GetComponent<Text>();
    }

    void Update(){
        ChangeExp();
        ChangeMultiplyExp(levelAtual);
    }

    void Upgrade(){
        levelAtual++;
        expAlvo *= multiplyExp;
    }

    void ChangeExp(){
        if (xpGanho != 0){
            expAtual += xpGanho;
            xpGanho = 0;
        }

        if (expAtual >= expAlvo) {
            if (expAtual_img.fillAmount >= 0.99f){
                expAtual = 0;
                Upgrade();
            }
        }

        expAtual_img.fillAmount = Mathf.Lerp(expAtual_img.fillAmount,Mathf.Clamp(expAtual / expAlvo, 0, expAlvo), 5 * Time.deltaTime);
        expAlvo_txt.text = expAlvo.ToString("0");
        expAtual_txt.text = expAtual.ToString("0");
        lvlAtual_txt.text = levelAtual.ToString();
    }

    void ChangeMultiplyExp(int value){
        switch (value){
            case 0:
                multiplyExp = 1.35f;
                break;
            case 10:
                multiplyExp = 2f;
                break;
            case 20:
                multiplyExp = 2.65f;
                break;
            case 30:
                multiplyExp = 3.1f;
                break;
            case 40:
                multiplyExp = 3.7f;
                break;
            case 50:
                multiplyExp = 4.5f;
                break;
        }
    }

    public int GetLevel{
        get { return levelAtual; }
    }

    public float EXP{
        set { xpGanho = value; }
        get { return expAtual; }
    }

    public float EXPAlvo {
        get { return expAlvo; }
    }
}
