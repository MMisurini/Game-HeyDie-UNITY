using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piramide : MonoBehaviour {
    private Vector3 startPosition;
    private Quaternion startRotation;

    private Enable enableScript;
    private Animation animScript;
    private ControllerDrop dropScript;

    [Header("Objetos para efeitos da animação")]
    [SerializeField] private GameObject targetPosition = null;
    [SerializeField] private GameObject smoke = null;
    [SerializeField] private AudioSource audioEffetsc = null;
    [Header("Atributos")]
    [SerializeField] private float damage = 0;
    [SerializeField] private float speed = 5;

    [SerializeField]private float timerAttack = 0f;
    private bool stopAnim = true;
    private GameObject alvoInstantiate = null;
    private bool voltarAnim = false;


    void Start() {
        enableScript = GetComponent<Enable>();
        animScript = GetComponent<Animation>();
        dropScript = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<ControllerDrop>();

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update() {
        if (enableScript.ChangeEnable) {
            PlayAttackPiramide(stopAnim);
        } else {
            stopAnim = true;
            voltarAnim = false;

            if (transform.position != startPosition)
                Voltar(timerAttack += Time.deltaTime);
            else
                timerAttack = 0;


            if (alvoInstantiate != null)
                Destroy(alvoInstantiate);
        }
    }

    void PlayAttackPiramide(bool value) {
        if (!voltarAnim) {
            if (value) {
                animScript.Play("Piramide");

                if (animScript.isPlaying) {
                    stopAnim = false;
                }
            }

            if (!value && !animScript.isPlaying) {
                if (alvoInstantiate == null) {
                    alvoInstantiate = Instantiate(targetPosition, new Vector3(Random.Range(-3.5f, 3.5f), targetPosition.transform.position.y, -4.5f), targetPosition.transform.rotation);
                    timerAttack = 0;
                } else {
                    timerAttack += Time.deltaTime;
                }

                if (timerAttack > 0.8f && alvoInstantiate != null) {
                    Vector3 a = new Vector3(alvoInstantiate.transform.position.x, -1.7f, -4.5f);
                    transform.position = Vector3.MoveTowards(transform.position, a, speed * Time.deltaTime);

                    if (transform.position == a) {
                        Destroy(alvoInstantiate);
                        alvoInstantiate = null;
                        timerAttack = 0;
                        voltarAnim = true;

                        InstantiateSmoke();
                    }
                }
            }
        } else{
            Voltar(timerAttack += Time.deltaTime);
        }
    }


    void Voltar(float value) {
        if (value > 2) {
            if (startPosition.x != transform.position.x) {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x, 10, startPosition.z), 20 * Time.deltaTime);
            } else {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, startPosition.y, transform.position.z), 3 * Time.deltaTime);
            }
                
            float a = Vector3.Distance(transform.position, startPosition);
            
            if (a < 0.05f) {
                enableScript.ChangeEnable = false;
                dropScript.SetSpecialAnimation = false;
            }
        }
    }

    void InstantiateSmoke() {
        Instantiate(smoke, new Vector3(transform.position.x,smoke.transform.position.y,transform.position.z), smoke.transform.rotation);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.tag == "Player") {
            hit.GetComponent<StateController>().Die();
        }
    }
}
