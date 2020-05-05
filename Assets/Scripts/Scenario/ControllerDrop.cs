using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class ControllerDrop : MonoBehaviour
{
    private GameObject attack = null;
    [Space(5)]
    [SerializeField] private float repeatBalls = 2f;

    private bool canBall = true;
    [SerializeField] private bool canSpecial = false;

    private GameObject[] clearBalls = null;

    [SerializeField] private GameObject[] attackSpecial = null;

    private float timerSecond = 0;
    private int timerAlvo = 5;
    private int indexAttackSpecial = 0;

    [SerializeField] private GameObject attackSpecial_Instantiate = null;
    [SerializeField] private ControllerTimerDrop timerDrop;

    public void Drop(bool value){
        timerDrop.IsActive = value;

        if (value) {
            if (canBall) {
                Instantiate(attack, attack.GetComponent<SimpleAttack>().TransformSpawn(), attack.transform.rotation);

                StartCoroutine(DropProjetil(repeatBalls));

                canBall = false;
            }

            CheckDropSpecial(Time.deltaTime);
        }
       
    }

    void CheckDropSpecial(float value) {
        if (!canSpecial) {
            repeatBalls = 3.5f;

            timerSecond += value;

            System.Random rdm = new System.Random();
            
            if (timerSecond > timerAlvo) {
                timerAlvo = rdm.Next(5, 8);

                canSpecial = true;
                
                DropSpecial(rdm.Next(0, 2));
            }
        } else {
            timerSecond = 0;
        }
    }

    void DropSpecial(int value) {
        indexAttackSpecial = value;
        if (attackSpecial.Length > 0) {
            if (indexAttackSpecial != 0) {
                attackSpecial_Instantiate = Instantiate(attackSpecial[indexAttackSpecial], attackSpecial[indexAttackSpecial].transform.position, Quaternion.identity);
                attackSpecial_Instantiate.GetComponent<Enable>().ChangeEnable = true;
            } else {
                if (indexAttackSpecial != 2)
                    attackSpecial[indexAttackSpecial].GetComponent<Enable>().ChangeEnable = true;
            }
        }
        
    }

    bool CheckSpecialTimer(GameObject[] value) {
        foreach (GameObject a in value) {
            if (a.GetComponent<Enable>().ChangeEnable)
                return false;
        }
        return true;
    }

    IEnumerator DropProjetil(float repeat){
        yield return new WaitForSeconds(repeat);
        canBall = true;
    }

    public void ClearListBalls(){
        clearBalls = GameObject.FindGameObjectsWithTag("Ball");
        if (clearBalls.Length > 0)
            foreach (GameObject t in clearBalls) {
                Destroy(t);
            }
    }

    public GameObject[] AttackSpecial {
        get { return attackSpecial; }
        set { attackSpecial = value; }
    }

    public bool SetSpecialAnimation {
        get { return canSpecial; }
        set { canSpecial = value; }
    }

    public float QuantBallsDrop {
        get { return repeatBalls; }
        set { repeatBalls = value; }
    }

    public GameObject Attack {
        get { return attack; }
        set { attack = value; }
    }

    public SimpleAttack SimpleAttack {
        get { return attack.GetComponent<SimpleAttack>(); }
    }

    public float TimerSecond {
        set { timerSecond = value; }
    }
}
