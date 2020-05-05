using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPags : MonoBehaviour
{
    private GameObject skills = null;
    private GameObject shop = null;
    private GameObject options = null;
    [SerializeField] private GameObject main = null;

    private Animation animPags;

    void Start(){
        skills = GameObject.FindGameObjectWithTag("Pags").transform.GetChild(0).gameObject;
        shop = GameObject.FindGameObjectWithTag("Pags").transform.GetChild(1).gameObject;
        options = GameObject.FindGameObjectWithTag("Pags").transform.GetChild(2).gameObject;

        animPags = GameObject.FindGameObjectWithTag("Pags").GetComponent<Animation>();
    }

    void Update(){
        if (skills.GetComponent<CanvasGroup>().alpha == 1 && skills.activeInHierarchy | shop.GetComponent<CanvasGroup>().alpha == 1 && shop.activeInHierarchy | options.GetComponent<CanvasGroup>().alpha == 1 && options.activeInHierarchy)
            main.SetActive(false);
        else
            main.SetActive(true);
    }

    public void OpenPage(string value){
        animPags.Play("FadeIn"+value);
    }

    public Animation GetAnimation(){
        return animPags;
    }
}
