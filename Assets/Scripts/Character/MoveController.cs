using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;
    private float gravity = 20.0f;

    [SerializeField] private ControllerLevels level = null;
    [SerializeField] private ControllerMoney money = null;
    
    private bool OnButtonJoystick = false;

    private Vector2 moveDirection = Vector2.zero;

    private CharacterController charController = null;
    private AnimationController animController = null;
    private ButtonsHUDFingers buttonController = null;
    private Joystick joyController = null;

    private Quaternion BeganRotation;

    private List<GameObject> Skills = new List<GameObject>();
    private Image[] profileSkills = new Image[3];
    [Space(20)]
    [SerializeField] private Sprite profileSkills_default = null;
    [SerializeField] private GameObject canvasInGame = null;

    void Start(){
        profileSkills[0] = GameObject.FindGameObjectWithTag("Profiler").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
        profileSkills[1] = GameObject.FindGameObjectWithTag("Profiler").transform.GetChild(0).transform.GetChild(1).GetComponent<Image>();
        profileSkills[2] = GameObject.FindGameObjectWithTag("Profiler").transform.GetChild(0).transform.GetChild(2).GetComponent<Image>();

        BeganRotation = Quaternion.identity;

        charController = GetComponent<CharacterController>();
        animController = GetComponent<AnimationController>();
        buttonController = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<ButtonsHUDFingers>();
        joyController = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();

        level = GetComponent<ControllerLevels>();
        money = GetComponent<ControllerMoney>();

        canvasInGame.SetActive(false);

        animController.SetAnimatorSpeed(moveSpeed);
    }

    public void TouchMoveScreen(bool value) {                

        if (!charController.isGrounded){
            moveDirection.y -= gravity * Time.deltaTime;
        }else{
            if (OnButtonJoystick && !value){
                buttonController.SetJump(false);
                animController.SetAnimatorSpeed(joyController.GetInput().magnitude + 0.5f);
                if (joyController.GetInput().magnitude > 0.4f){
                    moveDirection.x = joyController.GetInput().x;
                    animController.SetWalk(true);

                    if (joyController.GetInput().x > 0)
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                    else if (joyController.GetInput().x < 0)
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                }else{
                    moveDirection.x = 0;
                    animController.SetWalk(false);
                }
            }else{
                ResetRotation();
                animController.SetWalk(false);
                moveDirection.x = 0;
            }
        }

        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void ResetRotation(){
        transform.rotation = BeganRotation;
    }

    public void ResetPosition(){
        transform.position = new Vector3(0,0,-5);
    }

    public void SetGravity(float value) {
        gravity = value;
    }
    public void SetMoveSpeed(float value){
        moveSpeed = value;
    }

    public void SetMoveDirectionJump(float value){
        moveDirection.y = value;
    }

    public void SetOnButtonJoystick(bool value){
        OnButtonJoystick = value;
    }

    public CharacterController CharController()
    {
        return charController;
    }

    public AnimationController AnimController(){
        return animController;
    }

    public ButtonsHUDFingers ButtonsFingersController(){
        return buttonController;
    }

    public float GetMoney(){
        return money.Value;
    }
    public void SetMoney(float value){
        money.Value = value;
    }
    public float GetLevel(){
        return level.Get;
    }

    public void SetSkills(GameObject value){
        Skills.Add(value);
        profileSkills[Skills.IndexOf(value)].sprite = value.transform.GetChild(0).GetComponent<Image>().sprite;
    }
    public void SetDeleteSkills(int value){
        Skills.RemoveAt(value);
    }
    public void DeleteProfileSkill(GameObject value){
        foreach (Image t in profileSkills){
            if(t.sprite.name == value.transform.GetChild(0).GetComponent<Image>().name)
                t.sprite = profileSkills_default;
        }
    }

    public List<GameObject> GetListSkills(){
        return Skills;
    }
}
