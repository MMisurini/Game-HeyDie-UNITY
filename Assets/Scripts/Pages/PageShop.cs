using UnityEngine;
using UnityEngine.UI;

public class PageShop : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonsChoosePanel;
    [SerializeField] private GameObject[] panelChoose;
    [SerializeField] private GameObject checkConfirmBuy;

    private ControllerMaps maps;

    void Start() {
        maps = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(1).GetComponent<ControllerMaps>();

        for (int i = 0; i < buttonsChoosePanel.Length; i++) {
            if (buttonsChoosePanel[i].name != "Button Itens") {
                buttonsChoosePanel[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                buttonsChoosePanel[i].transform.GetChild(0).GetComponent<Text>().color = new Color(0.282353f, 0.1647059f, 0.08627451f, 0.5f);
                panelChoose[i].SetActive(false);
            }
        } 
    }

    void OnEnable() {
        GameObject ImageBackground = transform.GetChild(1).GetChild(0).gameObject;
        GameObject ImageLeft = transform.GetChild(1).GetChild(1).gameObject;
        GameObject ImageTop = transform.GetChild(1).GetChild(2).gameObject;

        ControllerAdmob.borderBanner[0] = ImageBackground.GetComponent<Image>();
        ControllerAdmob.borderBanner[1] = ImageLeft.GetComponent<Image>();
        ControllerAdmob.borderBanner[2] = ImageTop.GetComponent<Image>();

        ControllerAdmob ad = GameObject.FindGameObjectWithTag("ControllerDontDestroy").transform.GetChild(0).GetComponent<ControllerAdmob>();
        ad.RequestBanner();
    }

    public void ButtonChoosePanelShop(int value) {
        for (int i = 0;i < buttonsChoosePanel.Length;i++) {
            if(buttonsChoosePanel[i] == buttonsChoosePanel[value]) {
                buttonsChoosePanel[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                buttonsChoosePanel[i].transform.GetChild(0).GetComponent<Text>().color = new Color(0.282353f, 0.1647059f, 0.08627451f, 1);
                panelChoose[i].SetActive(true);
            } else {
                buttonsChoosePanel[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                buttonsChoosePanel[i].transform.GetChild(0).GetComponent<Text>().color = new Color(0.282353f, 0.1647059f, 0.08627451f, 0.5f);
                panelChoose[i].SetActive(false);
            }
        }
    }

    public void BuyShopMaps(int value, GameObject button) {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        MoneyController playerMoney = player.GetComponent<MoneyController>();
        LevelsController playerLevel = player.GetComponent<LevelsController>();

        for (int i = 0;i < maps.GetMapsSelect.Length;i++) {
            if (value == maps.GetMapsSelect[i].GetComponent<Scenario>().GetScenarioID()) {
                if (playerMoney.Value >= maps.GetMapsSelect[i].GetComponent<Scenario>().GetScenarioCoin() && playerLevel.GetLevel >= maps.GetMapsSelect[i].GetComponent<Scenario>().GetScenarioLvl()) {
                    playerMoney.Value -= maps.GetMapsSelect[i].GetComponent<Scenario>().GetScenarioCoin();

                    button.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "BOUGHT";
                    button.transform.GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1,1,1,0.5f);
                    button.GetComponent<Button>().interactable = false;

                    ControllerSave.Instance.BuyMaps(value);
                    maps.GetMapsSelect[i].GetComponent<Scenario>().Bought = ControllerSave.Instance.IsMapsOwned(value);
                }
            }
        }
    }

}
