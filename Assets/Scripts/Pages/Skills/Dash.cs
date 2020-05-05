using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    [SerializeField] private Sprite spriteSkill_game = null;
    [Space(10)]
    [SerializeField] private float levelTrue = 0f;
    [SerializeField] private float coinsTrue = 0f;
    [Space(10)]
    [SerializeField] private float timeReload = 0f;

    private static int id = 2;
    private bool bought;

    void Awake() {
        bought = ControllerSave.Instance.IsSkillOwned(id);
    }
    public bool GetBought()
    {
        return bought;
    }

    public void SetBought(bool value)
    {
        bought = value;
    }
    public float Level()
    {
        return levelTrue;
    }

    public float Coins()
    {
        return coinsTrue;
    }
    public Sprite GetSpriteGame()
    {
        return spriteSkill_game;
    }
    public float TimeReload()
    {
        return timeReload;
    }
    public int ID {
        get { return id; }
    }
    public bool FadeAndWait(Image fadeImg, float fadeTime)
    {
        bool faded = false;

        if (fadeImg == null)
            return faded;

        if (!fadeImg.gameObject.activeInHierarchy)
        {
            fadeImg.gameObject.SetActive(true);
            fadeImg.fillAmount = 1f;
        }

        fadeImg.fillAmount -= fadeTime * Time.deltaTime;

        if (fadeImg.fillAmount <= 0.0f)
        {
            fadeImg.gameObject.SetActive(false);
            faded = true;
        }

        return faded;
    }
}
