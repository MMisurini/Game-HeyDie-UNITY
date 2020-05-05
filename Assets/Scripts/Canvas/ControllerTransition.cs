using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerTransition : MonoBehaviour{

    private CanvasGroup canvasGroup;
    private Animation canvasAnim;
    private MoveController playerController;

    [SerializeField] private Animation anim;
    [SerializeField] private ButtonsHUDFingers btnFingers;

    void Start(){
        if (anim == null)
            anim = Camera.main.GetComponent<Animation>();

        canvasGroup = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasGroup>();
        canvasAnim = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Animation>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>();
        btnFingers = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<ButtonsHUDFingers>();
    }

    public void Play(){
        canvasAnim.Play("FadeOutMenu");
        anim.Play("MenuToGame");
        btnFingers.SetActive(true);
        btnFingers.SetSkillSpritesSelected(playerController.GetListSkills());
    }

    public void Menu(){
        btnFingers.ResetListSkillsAndDelete();
        btnFingers.CanvasGameOver(false);
        canvasAnim.Play("FadeOutGame");
        anim.Play("GameToMenu");
    }

    public Animation CanvasAnimation(){
        return canvasAnim;
    }
}
