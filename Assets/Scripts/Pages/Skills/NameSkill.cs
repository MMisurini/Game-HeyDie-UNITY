using UnityEngine;
using UnityEngine.UI;

public class NameSkill : MonoBehaviour
{
    [SerializeField] private Text nomeSkill;
    void Start()
    {
        nomeSkill = transform.Find("Text").GetComponent<Text>();
        nomeSkill.text = transform.GetChild(0).name;
    }
}
