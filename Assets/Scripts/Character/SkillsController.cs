using UnityEngine;
using UnityEngine.UI;

public class SkillsController : MonoBehaviour
{
    private int[] fadeImages;
    private GameObject[] objImages;

    private MoveController player;
    void Start(){
        fadeImages = new int[] { 0, 0, 0, 0};
        objImages = new GameObject[] { null, null, null, null };

        player = GetComponent<MoveController>();
    }

    void Update() {
        if (fadeImages[0] == 1) {
            ValidaSkillStopWalk(objImages[0]);

            if (ValidaScriptObject0()){
                fadeImages[0] = 0;
                objImages[0] = null;
                player.ButtonsFingersController().SetJump(false);
            }
        }if ( fadeImages[1] == 1){
            ValidaSkillStopWalk(objImages[1]);

            if (ValidaScriptObject1()){
                fadeImages[1] = 0;
                objImages[1] = null;
            }
        }
         if (fadeImages[2] == 1){
            ValidaSkillStopWalk(objImages[2]);

            if (ValidaScriptObject2()){
                fadeImages[2] = 0;
                objImages[2] = null;
            }
        }
         if (fadeImages[3] == 1){
            ValidaSkillStopWalk(objImages[3]);

            if (ValidaScriptObject3()){
                fadeImages[3] = 0;
                objImages[3] = null;
            }
        }
    }

    bool ValidaScriptObject0(){
        switch (objImages[0].name)
        {
            case "BrokenEarthBorder":
                return objImages[0].GetComponent<BrokenEarth>().FadeAndWait(objImages[0].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "JumpSpeedBorder":
                return objImages[0].GetComponent<JumpSpeed>().FadeAndWait(objImages[0].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "AttackBorder":
                return objImages[0].GetComponent<Attack>().FadeAndWait(objImages[0].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "TeleportBorder":
                return objImages[0].GetComponent<Teleport>().FadeAndWait(objImages[0].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "MoveSpeedBorder":
                return objImages[0].GetComponent<MoveSpeed>().FadeAndWait(objImages[0].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "ShieldBorder":
                return objImages[0].GetComponent<Shield>().FadeAndWait(objImages[0].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "DashBorder":
                return objImages[0].GetComponent<Dash>().FadeAndWait(objImages[0].transform.GetChild(3).GetComponent<Image>(), 0.2f);
        }
        return false;
    }
    bool ValidaScriptObject1()
    {
        switch (objImages[1].name)
        {
            case "BrokenEarthBorder":
                return objImages[1].GetComponent<BrokenEarth>().FadeAndWait(objImages[1].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "JumpSpeedBorder":
                return objImages[1].GetComponent<JumpSpeed>().FadeAndWait(objImages[1].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "AttackBorder":
                return objImages[1].GetComponent<Attack>().FadeAndWait(objImages[1].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "TeleportBorder":
                return objImages[1].GetComponent<Teleport>().FadeAndWait(objImages[1].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "MoveSpeedBorder":
                return objImages[1].GetComponent<MoveSpeed>().FadeAndWait(objImages[1].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "ShieldBorder":
                return objImages[1].GetComponent<Shield>().FadeAndWait(objImages[1].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "DashBorder":
                return objImages[1].GetComponent<Dash>().FadeAndWait(objImages[1].transform.GetChild(3).GetComponent<Image>(), 0.2f);
        }
        return false;
    }
    bool ValidaScriptObject2()
    {
        switch (objImages[2].name)
        {
            case "BrokenEarthBorder":
                return objImages[2].GetComponent<BrokenEarth>().FadeAndWait(objImages[2].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "JumpSpeedBorder":
                return objImages[2].GetComponent<JumpSpeed>().FadeAndWait(objImages[2].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "AttackBorder":
                return objImages[2].GetComponent<Attack>().FadeAndWait(objImages[2].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "TeleportBorder":
                return objImages[2].GetComponent<Teleport>().FadeAndWait(objImages[2].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "MoveSpeedBorder":
                return objImages[2].GetComponent<MoveSpeed>().FadeAndWait(objImages[2].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "ShieldBorder":
                return objImages[2].GetComponent<Shield>().FadeAndWait(objImages[2].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "DashBorder":
                return objImages[2].GetComponent<Dash>().FadeAndWait(objImages[2].transform.GetChild(3).GetComponent<Image>(), 0.2f);
        }
        return false;
    }
    bool ValidaScriptObject3()
    {
        switch (objImages[3].name)
        {
            case "BrokenEarthBorder":
                return objImages[3].GetComponent<BrokenEarth>().FadeAndWait(objImages[3].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "JumpSpeedBorder":
                return objImages[3].GetComponent<JumpSpeed>().FadeAndWait(objImages[3].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "AttackBorder":
                return objImages[3].GetComponent<Attack>().FadeAndWait(objImages[3].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "TeleportBorder":
                return objImages[3].GetComponent<Teleport>().FadeAndWait(objImages[3].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "MoveSpeedBorder":
                return objImages[3].GetComponent<MoveSpeed>().FadeAndWait(objImages[3].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "ShieldBorder":
                return objImages[3].GetComponent<Shield>().FadeAndWait(objImages[3].transform.GetChild(3).GetComponent<Image>(), 0.2f);
            case "DashBorder":
                return objImages[3].GetComponent<Dash>().FadeAndWait(objImages[3].transform.GetChild(3).GetComponent<Image>(), 0.2f);
        }
        return false;
    }
    void ValidaSkillStopWalk(GameObject value){
        //if (value.name != "MoveSpeedBorder" && value.name != "JumpSpeedBorder")
            //print("Entro");
            //player.ButtonsFingersController().SetJump(true);
    }

    public void UltimateSkill() {
  
    }

    public void InfoReloadSkill(int value, GameObject obj) {
        fadeImages[value] = 1;
        objImages[value] = obj;
    }
}
