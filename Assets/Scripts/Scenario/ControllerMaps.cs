using UnityEngine;
using UnityEngine.UI;

public class ControllerMaps : MonoBehaviour
{
    [SerializeField] private GameObject objectsMainMenu;
    [SerializeField] private GameObject[] objectsMaps;
    [SerializeField] private GameObject objectsMaps_selected;
    [SerializeField] private Light objectsLight_selected;

    private GameObject player;
    private ButtonsHUDFingers btnFingers;

    [SerializeField] private int objectsMaps_index = 0;

    private bool isChange = false;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        btnFingers = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<ButtonsHUDFingers>();

        objectsMaps_selected = Instantiate(objectsMaps[objectsMaps_index], Vector3.zero, Quaternion.identity);
        objectsMaps_selected.name = "Maps";
        objectsMaps_selected.transform.SetParent(GameObject.FindGameObjectWithTag("Scenario").transform);

        Scenario maps = objectsMaps_selected.GetComponent<Scenario>();

        objectsLight_selected = Instantiate(maps.GetSkyLightScene(), Vector3.up, maps.GetSkyLightScene().transform.rotation);
        objectsLight_selected.name = maps.GetSkyLightScene().name;
        objectsLight_selected.transform.SetParent(GameObject.FindGameObjectWithTag("Light").transform);

        RenderSettings.ambientSkyColor = maps.GetSkyColorSettings();
        RenderSettings.skybox = maps.GetSkyboxSettings();

        btnFingers.GetDropController.AttackSpecial = maps.AttackSpecial;
        btnFingers.GetDropController.Attack = maps.SimpleAttack;
    }

    void Update() {
        ChangeMaps(objectsMaps_selected);

        if (!objectsMaps_selected.GetComponent<Scenario>().Bought) {
            objectsMainMenu.transform.GetChild(4).GetComponent<Button>().interactable = false ;
            objectsMainMenu.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.2588235f, 0.1294118f, 0.04313726f,0.5f);
            objectsMainMenu.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = "BLOCKED";
        } else {
            objectsMainMenu.transform.GetChild(4).GetComponent<Button>().interactable = true;
            objectsMainMenu.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(0.2588235f, 0.1294118f, 0.04313726f, 1);
            objectsMainMenu.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = "PLAY";
        }
    }
    
    void ChangeMaps(GameObject value){
        if(value != null & isChange){
            isChange = false;
            Destroy(objectsMaps_selected);

            objectsMaps_selected = Instantiate(SelectMaps(objectsMaps_index),Vector3.zero,Quaternion.identity);
            objectsMaps_selected.name = "Maps";
            objectsMaps_selected.transform.SetParent(GameObject.FindGameObjectWithTag("Scenario").transform);
            Scenario maps = objectsMaps_selected.GetComponent<Scenario>();

            objectsLight_selected = Instantiate(maps.GetSkyLightScene(), Vector3.up, maps.GetSkyLightScene().transform.rotation);
            objectsLight_selected.name = maps.GetSkyLightScene().name;
            objectsLight_selected.transform.SetParent(GameObject.FindGameObjectWithTag("Light").transform);

            RenderSettings.ambientSkyColor = maps.GetSkyColorSettings();
            RenderSettings.skybox = maps.GetSkyboxSettings();
            player.transform.GetChild(3).GetComponent<Light>().intensity = maps.GetIntensityLightInPlayer();
            player.transform.GetChild(3).GetComponent<Light>().color = maps.GetColorLightInPlayer();

            btnFingers.GetDropController.AttackSpecial = maps.AttackSpecial;
            btnFingers.GetDropController.Attack = maps.SimpleAttack;
        }
    }

    public void NextButton(){
        objectsMaps_selected = GameObject.FindGameObjectWithTag("Scenario").transform.Find("Maps").gameObject;
        Destroy(objectsLight_selected.gameObject);

        if (objectsMaps_index < 2)
            objectsMaps_index++;
        else
            objectsMaps_index = 0;

        isChange = true;
    }

    public void PreviuosButton(){
        objectsMaps_selected = GameObject.FindGameObjectWithTag("Scenario").transform.Find("Maps").gameObject;
        Destroy(objectsLight_selected.gameObject);

        if (objectsMaps_index > 0)
            objectsMaps_index--;
        else
            objectsMaps_index = 2;

        isChange = true;
    }
    
    GameObject SelectMaps(int value){
        for (int i = 0; i < objectsMaps.Length; i++){
            if (i == objectsMaps_index)
                return objectsMaps[i];
        }

        return objectsMaps[0];
    }

    public GameObject[] GetMapsSelect {
        get { return objectsMaps; }
    }
}
