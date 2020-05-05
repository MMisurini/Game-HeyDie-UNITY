using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController charController;
    [Space(5)]
    [SerializeField] private TypeAttack typeAttack = TypeAttack.Desert;
    [Space(5)]
    [SerializeField] private GameObject smoke = null;

    private GameObject smokeInstatiate = null;

    void OnEnable (){
        charController = GetComponent<CharacterController>();

        if (typeAttack.ToString() == "Florest")
            transform.rotation = Quaternion.Euler(Random.Range(-90,90), Random.Range(-90, 90), Random.Range(-90, 90));

    }

    void FixedUpdate(){
        moveDirection.y -= gravity * Time.deltaTime;
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public Vector3 TransformSpawn(){
        return new Vector3(Random.Range(-4.5f, 4.5f), 9, -4.5f);
    }

    void OnControllerColliderHit(ControllerColliderHit hit){         
        if (hit.collider.tag == "Player"){
            hit.collider.GetComponent<StateController>().Die();
        }
        
        Destroy(this.gameObject,0.06f);
    }

    void OnDestroy() {
        ButtonsHUDFingers drop = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>().ButtonsFingersController();
        if (drop.GetActive())
            if (smokeInstatiate == null)
                smokeInstatiate = Instantiate(smoke, new Vector3(transform.position.x, smoke.transform.position.y, transform.position.z), smoke.transform.rotation); ;
    }

    public float MoveSpeedY {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

}

public enum TypeAttack { Vulcan,Desert,Snow,Florest}
