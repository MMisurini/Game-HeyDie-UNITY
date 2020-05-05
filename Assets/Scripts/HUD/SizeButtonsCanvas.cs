using UnityEngine;

public class SizeButtonsCanvas : MonoBehaviour
{
    [SerializeField] private ButtonsHUDFingers oneFinger = null;
    [Space(10)]
    [SerializeField] private RectTransform SkillsButton = null;
    [SerializeField] private RectTransform JoystickButton = null;

    void Awake(){
        Joystick();
        Skills();
        oneFinger.SetButtonSkill(SkillsButton.gameObject);
    }

    void Joystick(){
        Vector2 sizeScreen = new Vector2(Screen.width * 0.11f, Screen.height * 0.195f);
        JoystickButton.sizeDelta = CheckPercentSize(sizeScreen);
        JoystickButton.position = new Vector2(sizeScreen.x / 2 + (Screen.width / 2 * 0.15f), sizeScreen.y / 2 + (Screen.height / 2 * 0.1f));

        oneFinger.Joystick(JoystickButton.position, JoystickButton.sizeDelta);

        JoystickButton.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = CheckPercentSize(new Vector2(sizeScreen.x * 0.625f, sizeScreen.y * 0.625f));
    }

    void Skills(){
        Vector2 sizeScreen = new Vector2(Screen.width * 0.243f, Screen.height * 0.431f);
        SkillsButton.sizeDelta = CheckPercentSize(sizeScreen);
        SkillsButton.position = new Vector2((Screen.width - sizeScreen.x/2), sizeScreen.y / 2 + 10);

        oneFinger.Skills(SkillsButton.sizeDelta);
    }

    Vector2 CheckPercentSize(Vector2 value){
        if (value.x > value.y)
            return new Vector2(value.x, value.x);
        else
            return new Vector2(value.y, value.y);
    }
}
