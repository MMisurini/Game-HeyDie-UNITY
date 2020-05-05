using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDown : MonoBehaviour, IPointerDownHandler
{
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        ButtonsHUDFingers buttonController = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<ButtonsHUDFingers>();
        if (!buttonController.GetActive())
        {
            PageSkill page = GameObject.FindGameObjectWithTag("Pags").transform.GetChild(0).GetComponent<PageSkill>();
            page.Selected(this.gameObject);
        }
        else
        {
            GameObject playerController = GameObject.FindGameObjectWithTag("Player");
            ValidaPositionSkillCanvas(playerController.GetComponent<MoveController>().GetListSkills(), playerController.GetComponent<SkillsController>());
        }
    }

    void ValidaPositionSkillCanvas(List<GameObject> value, SkillsController skill)
    {
        for (int i = 0; i < value.Count; i++)
        {
            if (value[i].transform.GetChild(0).name + "Border" == gameObject.name){
                skill.InfoReloadSkill(i, this.gameObject) ;
            }
        }
    }
}
