using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSkill : MonoBehaviour
{
    [SerializeField] private GameObject selected_Skill = null;
    [SerializeField] private GameObject showSkill_selected = null;

    [SerializeField] private GameObject[] selected_Skills = new GameObject[7];
    [SerializeField] private GameObject[] positionSkills_selected = new GameObject[3];
    [Space(10)]
    [SerializeField] private Text levelText = null;
    [SerializeField] private Text coinsText = null;
    [SerializeField] private Text buttonText = null;
    [Space(10)]
    [SerializeField] private GameObject canvasCheckConfirm = null;

    public GameObject deleteButtonSelect;

    void ValidaSelectedSkill(){
        foreach (GameObject t in selected_Skills){
            if (t != selected_Skill){
                t.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }else{
                t.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                showSkill_selected.GetComponent<Image>().sprite = selected_Skill.transform.GetChild(0).GetComponent<Image>().sprite;
                showSkill_selected.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                levelText.text = ValidaComponentLevel(selected_Skill) + "";
                coinsText.text = "$ " + ValidaComponentCoins(selected_Skill);

                ValidaButtomValueBought();
            }
        }
    }

    void ValidaButtomValueBought(){
        if (ValidaComponentGetBought(selected_Skill))
            buttonText.text = "USE";
        else
            buttonText.text = "BUY";
    }

    float ValidaComponentLevel(GameObject value){
        switch (value.transform.GetChild(0).name){
            case "BrokenEarth":
                return value.GetComponent<BrokenEarth>().Level();
            case "JumpSpeed":
                return value.GetComponent<JumpSpeed>().Level();
            case "Attack":
                return value.GetComponent<Attack>().Level();
            case "Teleport":
                return value.GetComponent<Teleport>().Level();
            case "MoveSpeed":
                return value.GetComponent<MoveSpeed>().Level();
            case "Shield":
                return value.GetComponent<Shield>().Level();
            case "Dash":
                return value.GetComponent<Dash>().Level();
        }
        return 0f;
    }
    float ValidaComponentCoins(GameObject value){
        switch (value.transform.GetChild(0).name){
            case "BrokenEarth":
                return value.GetComponent<BrokenEarth>().Coins();
            case "JumpSpeed":
                return value.GetComponent<JumpSpeed>().Coins();
            case "Attack":
                return value.GetComponent<Attack>().Coins();
            case "Teleport":
                return value.GetComponent<Teleport>().Coins();
            case "MoveSpeed":
                return value.GetComponent<MoveSpeed>().Coins();
            case "Shield":
                return value.GetComponent<Shield>().Coins();
            case "Dash":
                return value.GetComponent<Dash>().Coins();
        }
        return 0f;
    }
    bool ValidaComponentGetBought(GameObject value)
    {
        switch (value.transform.GetChild(0).name)
        {
            case "BrokenEarth":
                return value.GetComponent<BrokenEarth>().GetBought();
            case "JumpSpeed":
                return value.GetComponent<JumpSpeed>().GetBought();
            case "Attack":
                return value.GetComponent<Attack>().GetBought();
            case "Teleport":
                return value.GetComponent<Teleport>().GetBought();
            case "MoveSpeed":
                return value.GetComponent<MoveSpeed>().GetBought();
            case "Shield":
                return value.GetComponent<Shield>().GetBought();
            case "Dash":
                return value.GetComponent<Dash>().GetBought();
        }
        return false;
    }
    void ValidaComponentSetBought(GameObject value){
        switch (value.transform.GetChild(0).name)
        {
            case "BrokenEarth":
                value.GetComponent<BrokenEarth>().SetBought(true);
                break;
            case "JumpSpeed":
                value.GetComponent<JumpSpeed>().SetBought(true);
                break;
            case "Attack":
                value.GetComponent<Attack>().SetBought(true);
                break;
            case "Teleport":
                value.GetComponent<Teleport>().SetBought(true);
                break;
            case "MoveSpeed":
                value.GetComponent<MoveSpeed>().SetBought(true);
                break;
            case "Shield":
                value.GetComponent<Shield>().SetBought(true);
                break;
            case "Dash":
                value.GetComponent<Dash>().SetBought(true);
                break;
        }
    }


    public void ThreeSkillSelect(){
        MoveController player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>();
        if (buttonText.text == "BUY")
            BuySkill(player);
        else
            InsertSkillBought(player);
    }

    void BuySkill(MoveController player){
        if (player.GetMoney() >= ValidaComponentCoins(selected_Skill) & player.GetLevel() >= ValidaComponentLevel(selected_Skill)){
            canvasCheckConfirm.SetActive(true);
            canvasCheckConfirm.transform.GetChild(0).gameObject.SetActive(true);
        }else{
            canvasCheckConfirm.SetActive(true);
            canvasCheckConfirm.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void InsertSkillBought(MoveController player){
        Color opacity0 = new Color(255,255,255,0);
        ValidaSkillAgain();
        if (selected_Skill){
            foreach (GameObject i in positionSkills_selected){
                if (i.transform.childCount == 0 & ValidaSkillAgain()){
                    GameObject a = Instantiate(selected_Skill,i.transform.position, Quaternion.identity);
                    a.transform.SetParent(i.transform);
                    a.GetComponent<Image>().color = opacity0;
                    a.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
                    a.GetComponent<RectTransform>().anchorMax = new Vector2(1,1);
                    a.GetComponent<RectTransform>().anchorMin = new Vector2(0,0);
                    a.GetComponent<RectTransform>().localScale = new Vector3(0.6f,0.6f,1);
                    a.GetComponent<RectTransform>().offsetMin = new Vector2(0,10);
                    a.GetComponent<RectTransform>().offsetMax = new Vector2(-10,0);
                    a.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
                    a.transform.GetChild(1).gameObject.SetActive(false);
                    a.transform.GetChild(2).gameObject.SetActive(true);
                    player.SetSkills(a);
                    break;
                }
            }
        }
    }

    bool ValidaSkillAgain(){
        for (int i = 0; i < positionSkills_selected.Length; i++) {
            if (positionSkills_selected[i].transform.childCount !=0){
                if (positionSkills_selected[i].transform.GetChild(0).GetChild(0).name == selected_Skill.transform.GetChild(0).name){
                    return false;
                }
            }else{
                return true;
            }
        }
        return true;
    }

    public void ThreeSkillDelete(string value){
        MoveController player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>();
        deleteButtonSelect = GameObject.Find("Border "+ value + "(Clone)");
        Destroy(deleteButtonSelect);
        player.SetDeleteSkills(player.GetListSkills().IndexOf(deleteButtonSelect));
        player.DeleteProfileSkill(deleteButtonSelect);
        
    }

    public void ResetSkillSelected(){
        selected_Skill = null;
    }

    public void Selected(GameObject value){
        selected_Skill = value;
        ValidaSelectedSkill();
    }

    public void CheckConfirmButton(string value){
        if (value == "Yes"){
            MoveController player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>();
            
            ValidaComponentSetBought(selected_Skill);
            float moneyPlayer = player.GetMoney() - ValidaComponentCoins(selected_Skill);
            player.SetMoney(moneyPlayer);

            ValidaButtomValueBought();

            canvasCheckConfirm.transform.GetChild(0).gameObject.SetActive(false);
            canvasCheckConfirm.SetActive(false);
        }
        else{
            canvasCheckConfirm.transform.GetChild(0).gameObject.SetActive(false);
            canvasCheckConfirm.SetActive(false);
        }
    }

    public void CheckOkButton(){
        canvasCheckConfirm.transform.GetChild(1).gameObject.SetActive(false);
        canvasCheckConfirm.SetActive(false);
    }
}
