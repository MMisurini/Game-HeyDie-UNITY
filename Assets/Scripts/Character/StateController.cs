using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private MoveController move;

    public void Die(){
        move = GetComponent<MoveController>();
        move.AnimController().SetWalk(false);
        move.ResetRotation();
        move.ResetPosition();
        move.ButtonsFingersController().SetResetTime();
        move.ButtonsFingersController().SetJump(false);
        move.ButtonsFingersController().SetActive(false);
        move.ButtonsFingersController().CanvasGameOver(true);
    }
}
