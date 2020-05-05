using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.15f;
    private float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController charController;

    [SerializeField] private TypeBall typeBall = TypeBall.FireBall;

    void Start(){
        charController = GetComponent<CharacterController>();
        TypeBallEffect(typeBall);
    }

    void FixedUpdate(){
        moveDirection.y -= gravity * Time.deltaTime;
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void TypeBallEffect(TypeBall value){
        switch (value){
            case TypeBall.EarthBall:

                break;
            case TypeBall.FireBall:

                break;
            case TypeBall.ForestBall:

                break;
        }
    }

    public void SetType(TypeBall value){
        typeBall = value;
    }

    public Vector3 TransformSpawn(){
        return new Vector3(Random.Range(-4.5f, 4.5f), 9, -5);
    }

    void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.collider.tag == "Player"){
            hit.collider.GetComponent<StateController>().Die();
        }
        Destroy(this.gameObject,0.05f);
    }
}
public enum TypeBall { FireBall, EarthBall, ForestBall }
