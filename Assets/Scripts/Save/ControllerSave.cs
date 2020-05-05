using UnityEngine;

public class ControllerSave : MonoBehaviour
{
    public static ControllerSave Instance { get; set; }
    public SaveState state;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
    }

    public void Save() {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    public void Load() {
        if (PlayerPrefs.HasKey("save")) {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
            state.saveTimer = 30;
        } else {
            state = new SaveState();
            state.saveTimer = 30;
            Save();
        }
    }

    public bool IsSkillOwned(int index) {

        return (state.skillOwned & (1 << index)) != 0;
    }

    public void UnlockSkill(int index) {
        state.skillOwned |= 1 << index;
    }

    public bool IsItensShopOwned(int index) {

        return (state.itemShopOwned & (1 << index)) != 0;
    }

    public void UnlockItensShop(int index) {
        state.itemShopOwned |= 1 << index;
    }

    public bool IsMapsOwned(int index) {

        return (state.mapsOwned & (1 << index)) != 0;
    }

    public void UnlockMaps(int index) {
        state.mapsOwned |= 1 << index;
    }

    public void BuyMaps(int index) {
        UnlockMaps(index);

        Save();
    }
    public void BuySkill(int index) {
        UnlockSkill(index);
    }

    public void ResetSave() {
        PlayerPrefs.DeleteKey("save");
    }

}
