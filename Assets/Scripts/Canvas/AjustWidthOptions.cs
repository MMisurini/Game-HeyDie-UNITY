using UnityEngine;
using UnityEngine.UI;

public class AjustWidthOptions : MonoBehaviour
{
    [Header("Menu Top")]
    [SerializeField] private RectTransform m_handleRect = null;
    [SerializeField] private Text value;

    [SerializeField] private GameObject toggleTop;

    [Header("Menu Bottom")]
    [SerializeField] private GameObject toggleBottom;
    [SerializeField] private Button[] buttonsBottom;

    void Start(){
        m_handleRect.sizeDelta = new Vector2(float.Parse(Screen.width * 0.035 + ""),m_handleRect.sizeDelta.y);
    }

    private void Update() {
        ToggleTop();
        ToggleBottom();
    }

    void ToggleTop() {
        float index = 0;
        if (toggleTop.GetComponent<Toggle>().isOn) {
            value.text = "Timer Save: " + transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Slider>().value.ToString("00") + "s";
            value.color = new Color(value.color.r, value.color.g, value.color.b, 1f);
            index = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Slider>().value;
        } else {
            value.text = "Timer Save: 0s";
            value.color = new Color(value.color.r, value.color.g, value.color.b, 0.5f);
            index = 0;
        }

        ControllerSave.Instance.state.saveTimer = (int)index;
    }

    void ToggleBottom() {
        if (toggleBottom.GetComponent<Toggle>().isOn) {
            buttonsBottom[0].interactable = true;
            buttonsBottom[1].interactable = true;
        } else {
            buttonsBottom[0].interactable = false;
            buttonsBottom[1].interactable = false;
        }
    }
}
