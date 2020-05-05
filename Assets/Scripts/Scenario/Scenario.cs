using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    [Header("Skybox")]
    [SerializeField] private Material skybox;
    [Header("Tipo do Cenario")]
    [SerializeField] private TypeSceneario typeScenario_selected = TypeSceneario.Null;
    [Header("Prefab da Iluminação")]
    [SerializeField] private Light originalLight;
    [Header("Lighting Settings HDR Color")]
    [SerializeField] private Color colorSettings;
    [Header("Color Player Bake")]
    [SerializeField] private Color colorLight_player = new Color(255,255,255,255);
    [SerializeField] private float intensityLight_player = 0;
    [Header("Attack Cenário")]
    [SerializeField] private GameObject simpleAttack;
    [SerializeField] private GameObject[] attackSpecial_scenario;

    [SerializeField] private bool bought = false;

    void Awake() {
        if (typeScenario_selected == TypeSceneario.Desert)
            ControllerSave.Instance.UnlockMaps(GetScenarioID());

        bought = ControllerSave.Instance.IsMapsOwned(GetScenarioID());
    }

    public TypeSceneario GetTypeScenario {
        get { return typeScenario_selected; }
    }

    public int GetScenarioID() {
        switch (typeScenario_selected) {
            case TypeSceneario.Desert:
                return 1;
            case TypeSceneario.Florest:
                return 2;
            case TypeSceneario.Vulcan:
                return 3;
            case TypeSceneario.Snow:
                return 4;
            case TypeSceneario.Cemetery:
                return 5;
            case TypeSceneario.Null:
                return 0;
        }

        return 0;
    }

    public float GetScenarioCoin() {
        switch (typeScenario_selected) {
            case TypeSceneario.Desert:
                return 0;
            case TypeSceneario.Florest:
                return 5;
            case TypeSceneario.Vulcan:
                return 7.5f;
            case TypeSceneario.Snow:
                return 0;
            case TypeSceneario.Null:
                return 0;
        }

        return 0;
    }

    public int GetScenarioLvl() {
        switch (typeScenario_selected) {
            case TypeSceneario.Desert:
                return 0;
            case TypeSceneario.Florest:
                return 0;
            case TypeSceneario.Vulcan:
                return 0;
            case TypeSceneario.Snow:
                return 0;
            case TypeSceneario.Null:
                return 0;
        }

        return 0;
    }

    public bool Bought {
        get { return bought; }
        set { bought = value; }
    }

    public Color GetSkyColorSettings() {
        return colorSettings;
    }

    public Light GetSkyLightScene() {
        return originalLight;
    }

    public Color GetColorLightInPlayer() {
        return colorLight_player;
    }
    public float GetIntensityLightInPlayer() {
        return intensityLight_player;
    }

    public Material GetSkyboxSettings() {
        return skybox;
    }

    public GameObject[] AttackSpecial {
        get {return attackSpecial_scenario; }
    }

    public GameObject SimpleAttack {
        get { return simpleAttack; }
    }
}
public enum TypeSceneario {
    Null,Desert,Florest,Vulcan,Snow,Cemetery
}
