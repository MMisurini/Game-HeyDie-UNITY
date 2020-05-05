using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private MoveController playerController;
    private Animator fred;

    [SerializeField] private float jumpSpeed = 5.0f;

    // Start is called before the first frame update
    void Start(){
        playerController = GetComponent<MoveController>();
        fred = GetComponent<Animator>();
    }

    public void Jump(){
        playerController.SetMoveDirectionJump(jumpSpeed);
    }

    public void SetJumpTrue(){
        playerController.ButtonsFingersController().SetJump(true);
        fred.SetBool("do_jump", true);
    }
    public void SetJumpFalse(){
        fred.SetBool("do_jump", false);
    }

    public bool GetJump(){
        return fred.GetBool("do_jump");
    }

    public void SetWalk(bool value){
        fred.SetBool("do_walk", value);
    }

    public bool GetWalk(){
        return fred.GetBool("do_walk");
    }

    public void SetAnimatorSpeed(float value){
        if (fred.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            fred.speed = value;
    }

    public AnimatorStateInfo GetStateInfo(int value){
        return fred.GetCurrentAnimatorStateInfo(value);
    }

    public AnimatorTransitionInfo GetTransitionInfo(int value){
        return fred.GetAnimatorTransitionInfo(value);
    }


}
