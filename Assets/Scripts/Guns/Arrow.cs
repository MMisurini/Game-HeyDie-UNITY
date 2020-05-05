using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    private int direction = 0;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController charController;

    void Start(){
        charController = GetComponent<CharacterController>();

    }

    void FixedUpdate()
    {
        moveDirection.x = direction;
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public Vector3 TransformSpawn()
    {
        return new Vector3(RandomRange(Random.Range(0,1)), 10, -5);
    }

    public int RandomRange(int value){
        switch (value){
            case 0:
                return -4;
            case 1:
                return 4;
        }
        return 4;
    }

    public void Direction(){
        if (transform.position.x == 4)
            direction = -1;
        else if (transform.position.x == -4)
            direction = 1;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Player"){
            hit.collider.GetComponent<MoveController>().AnimController().SetWalk(false);
            hit.collider.GetComponent<MoveController>().ResetPosition();
            hit.collider.GetComponent<MoveController>().transform.position = new Vector3(0, 0, -5);
        }
        Destroy(this.gameObject, 0.1f);
    }
}
