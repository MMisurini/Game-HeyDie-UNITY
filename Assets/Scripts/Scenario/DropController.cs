using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [SerializeField] private Ball ball = null;
    [Space(5)]
    [SerializeField] private float repeatBalls = 2f;

    private bool canBall = true;

    private GameObject[] balls = null;

    public void Drop(){
        if (canBall){
            Instantiate(ball.gameObject, ball.TransformSpawn(), Quaternion.identity);

            StartCoroutine(DropProjetil(repeatBalls));

            canBall = false;
        }
    }

    IEnumerator DropProjetil(float repeat){
        yield return new WaitForSeconds(repeat);
        canBall = true;
    }

    public void ClearListBalls(){
        balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length > 0)
            foreach (GameObject t in balls){
                Destroy(t);
            }
    }
}
