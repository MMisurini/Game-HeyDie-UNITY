using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjustWidth : MonoBehaviour
{
    [SerializeField] private RectTransform m_handleRect = null;
    [Space(10)]
    [SerializeField] private Image maskMain = null;
    [SerializeField] private Sprite maskMute = null;
    [SerializeField] private Sprite maskDesmute = null;
    [Space(5)]
    [SerializeField] private Image iconMain = null;
    [SerializeField] private Sprite mute = null;
    [SerializeField] private Sprite desmute = null;

    private Slider sliderScript;
    void Start(){
        sliderScript = GetComponent<Slider>();
        m_handleRect.sizeDelta = new Vector2(float.Parse(Screen.width * 0.035 + ""),m_handleRect.sizeDelta.y);
    }

    void Update(){
        if (sliderScript.transform.parent.name == "Audio Config") {
            if (sliderScript.value == 0) {
                iconMain.sprite = mute;
                maskMain.sprite = maskMute;
            } else {
                iconMain.sprite = desmute;
                maskMain.sprite = maskDesmute;
            }
        }else{
            if (sliderScript.value == 0){
                maskMain.sprite = maskMute;
            }else{
                maskMain.sprite = maskDesmute;
            }
        }
    }
}
