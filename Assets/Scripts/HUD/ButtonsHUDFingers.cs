using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsHUDFingers : MonoBehaviour
{
    private Vector2 positionJoystick, sizeJoystick;
    private Vector2 sizeSkill;

    private MoveController playerController = null;
    private AnimationController animController = null;
    private DropController dropController = null;

    [SerializeField]
    private bool isJump = false;
    private bool isActiveScript = false;
    private float inMinuteGame = 0f;
    private float inSecondGame = 0f;

    private GameObject buttonsSkills;
    private Transform canvasMain;

    [SerializeField] private Sprite imagePause = null;
    [SerializeField] private Sprite imageStart = null;
    [Space(10)]
    [SerializeField] private Image buttonPauseStart = null;
    [Space(10)]
    [SerializeField] private Text tempoGame = null;
    [SerializeField] private Text moneyGame = null;
    [Space(10)]
    [SerializeField] private GameObject canvasGameOver = null;
    [Space(10)]
    [SerializeField] private GameObject[] spritesSkills_selected = null;
    void Start(){
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>();
        animController = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimationController>();
        dropController = GetComponent<DropController>();
        canvasMain = GameObject.FindGameObjectWithTag("Canvas").transform;
        inSecondGame = 0f;
        inMinuteGame = 0f;
    }

    void FixedUpdate(){
        if (playerController.CharController().isGrounded && animController.GetStateInfo(0).IsName("Jump"))
            StartCoroutine(Test(animController.GetStateInfo(0).length));

        if (isActiveScript) {
            ValidaCountFinger(Input.touchCount);

            ValidaOpacityButtons(buttonsSkills, playerController.gameObject);

            playerController.TouchMoveScreen(isJump);
        }else{
            dropController.ClearListBalls();
        }
    }

    void Update(){
        ValidaPlayAndPause();
        Temporizer();

        if (canvasMain.GetChild(0).gameObject.activeSelf && canvasMain.GetChild(0).GetComponent<CanvasGroup>().alpha == 1)
            if (isActiveScript)
                dropController.Drop();
    }

    IEnumerator Test(float value){
        yield return new WaitForSeconds(value - 0.15f);
        animController.SetJumpFalse();
        isJump = false;
    }

    void ValidaCountFinger(int value){
        switch (value){
            case 0:
                    
                break;
            case 1:
                if (Input.GetTouch(0).phase == TouchPhase.Began){
                    if (Input.GetTouch(0).position.x > Screen.width / 2)
                        ValidaJump(ValidaPositionOneFingerRight(Input.GetTouch(0).position));
                    else
                        ValidaJump(ValidaPositionOneFingerLeft(Input.GetTouch(0).position));
                }
                break;

            case 2:
                if (Input.GetTouch(1).phase == TouchPhase.Began | Input.GetTouch(1).phase == TouchPhase.Ended){
                    if (Input.GetTouch(1).position.x > Screen.width / 2){
                        ValidaJump(ValidaPositionOneFingerRight(Input.GetTouch(1).position));
                    }else{
                        ValidaJump(ValidaPositionOneFingerLeft(Input.GetTouch(1).position));
                    }
                }
                break;
        }
    }

    void ValidaOpacityButtons(GameObject buttons, GameObject character){
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        int speedOpaticy = 8;
        if (ValidaPositionOneFingerRight(screenPosition)){
            if (buttons.transform.GetChild(0).GetComponent<Image>().color != new Color(0, 0, 0, 0.5f)){
                buttons.transform.GetChild(0).GetComponent<Image>().color = Color.Lerp(buttons.transform.GetChild(0).GetComponent<Image>().color, (new Color(255, 255, 255, 0.5f)), speedOpaticy * Time.deltaTime);
                buttons.transform.GetChild(1).GetComponent<Image>().color = Color.Lerp(buttons.transform.GetChild(0).GetComponent<Image>().color, (new Color(255, 255, 255, 0.5f)), speedOpaticy * Time.deltaTime);
                buttons.transform.GetChild(2).GetComponent<Image>().color = Color.Lerp(buttons.transform.GetChild(0).GetComponent<Image>().color, (new Color(255, 255, 255, 0.5f)), speedOpaticy * Time.deltaTime);
                buttons.transform.GetChild(3).GetComponent<Image>().color = Color.Lerp(buttons.transform.GetChild(0).GetComponent<Image>().color, (new Color(255, 255, 255, 0.5f)), speedOpaticy * Time.deltaTime);
            }
        }else{
            if (buttons.transform.GetChild(0).GetComponent<Image>().color != new Color(0, 0, 0, 1f)){
                buttons.transform.GetChild(0).GetComponent<Image>().color = Color.Lerp(buttons.transform.GetChild(0).GetComponent<Image>().color, (new Color(255, 255, 255, 1f)), speedOpaticy * Time.deltaTime);
                buttons.transform.GetChild(1).GetComponent<Image>().color = Color.Lerp(buttons.transform.GetChild(0).GetComponent<Image>().color, (new Color(255, 255, 255, 1f)), speedOpaticy * Time.deltaTime);
                buttons.transform.GetChild(2).GetComponent<Image>().color = Color.Lerp(buttons.transform.GetChild(0).GetComponent<Image>().color, (new Color(255, 255, 255, 1f)), speedOpaticy * Time.deltaTime);
                buttons.transform.GetChild(3).GetComponent<Image>().color = Color.Lerp(buttons.transform.GetChild(0).GetComponent<Image>().color, (new Color(255, 255, 255, 1f)), speedOpaticy * Time.deltaTime);
            }
        }
    }

    bool ValidaPositionOneFingerRight(Vector3 value){
        if (value.y <= sizeSkill.y + 20 || value.y >= Screen.height - (Screen.height * 0.15))
            if (value.x >= (Screen.width - sizeSkill.x) - 20)
                return true;
        
        return false;
    }

    bool ValidaPositionOneFingerLeft(Vector3 value)
    {
        if (value.x <= (positionJoystick.x + sizeJoystick.x / 2) + 20)
            if (value.y <= (positionJoystick.y + sizeJoystick.y / 2) + 20)
                return true;

        return false;
    }

    void ValidaJump(bool value)
    {
        if (!value){
            animController.SetWalk(false);
            playerController.ResetRotation();
            if (playerController.CharController().isGrounded && !animController.GetJump()){
                animController.SetJumpTrue();
            }
        }
    }

    void Temporizer(){
        if (isActiveScript) {
            inSecondGame += Time.deltaTime;

            float second = inSecondGame % 60;
            if (second >= 59.98f){
                inMinuteGame += 1;
            }

            float money = 0f;

            tempoGame.text = string.Format("{0:00}:{1:00}", inMinuteGame, second) + " s";
            moneyGame.text = string.Format("{0:00.00}", money);
        }else{
            
            tempoGame.text = "0 s";
            moneyGame.text = "00.00";
        }
    }

    void ValidaPlayAndPause(){;
        if (Time.timeScale == 1)
            buttonPauseStart.sprite = imagePause;
        else
            buttonPauseStart.sprite = imageStart;
    }

    public void Joystick(Vector2 valuePosition, Vector2 valueSize)
    {
        positionJoystick = valuePosition;
        sizeJoystick = valueSize;
    }

    public void Skills(Vector2 valueSize)
    {
        sizeSkill = valueSize;
    }

    public void CanvasGameOver(bool value){
        canvasGameOver.SetActive(value);
    }

    public void SetButtonSkill(GameObject value){
        buttonsSkills = value;
    }

    public void SetResetTime(){
        inMinuteGame = 0f;
        inSecondGame = 0f;
    }
    public void SetActive(bool value){
        isActiveScript = value;
    }

    public bool GetActive(){
        return isActiveScript;
    }

    public void SetJump(bool value){
        isJump = value;
    }

    public void ResetListSkillsAndDelete(){
        for (int i = 0;i < spritesSkills_selected.Length;i++){
            if (spritesSkills_selected[i].transform.childCount > 0){
                spritesSkills_selected[i].GetComponent<Image>().enabled = true;
                Destroy(spritesSkills_selected[i].transform.GetChild(0).gameObject);
            }
        }
    }

    public void SetSkillSpritesSelected(List<GameObject> value){       
        for (int i = 0; i < value.Count; i++){
            if (value[i] != null) {
                GameObject a = Instantiate(value[i], spritesSkills_selected[i].transform.position, Quaternion.identity);
                a.transform.SetParent(spritesSkills_selected[i].transform);
                a.name = a.transform.GetChild(0).name + "Border";
                a.GetComponent<Image>().color = new Color(255,255,255,255);
                a.GetComponent<Image>().sprite = ValidaSpriteScript(value[i]);
                a.transform.GetChild(0).GetComponent<Image>().enabled = false;
                a.transform.GetChild(2).gameObject.SetActive(false);
                a.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                a.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                a.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                a.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                a.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                a.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                spritesSkills_selected[i].GetComponent<Image>().enabled = false;
            }else{
                if (spritesSkills_selected[i].transform.childCount > 0)
                    Destroy(spritesSkills_selected[i].transform.GetChild(0));

                spritesSkills_selected[i].GetComponent<Image>().enabled = true;
            }
        }
    }

    Sprite ValidaSpriteScript(GameObject t){
        switch (t.transform.GetChild(0).name)
        {
            case "BrokenEarth":
                return t.GetComponent<BrokenEarth>().GetSpriteGame();
            case "JumpSpeed":
                return t.GetComponent<JumpSpeed>().GetSpriteGame();
            case "Attack":
                return t.GetComponent<Attack>().GetSpriteGame();
            case "Teleport":
                return t.GetComponent<Teleport>().GetSpriteGame();
            case "MoveSpeed":
                return t.GetComponent<MoveSpeed>().GetSpriteGame();
            case "Shield":
                return t.GetComponent<Shield>().GetSpriteGame();
            case "Dash":
                return t.GetComponent<Dash>().GetSpriteGame();
        }
        return null;
    }
}
