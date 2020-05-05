using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerIsGameLoad : MonoBehaviour
{
    [SerializeField] private Animation anim;

    private ControllerAdmob ad;
    [SerializeField] private Image loading;

    private void Start() {
        ad = GameObject.FindGameObjectWithTag("ControllerDontDestroy").transform.GetChild(0).GetComponent<ControllerAdmob>();
        ad.RequestInterstitial();

        StartCoroutine(LoadSceneTimerWait());
        //StartCoroutine(LoadAsync(1));
    }

    IEnumerator LoadAsync(int index) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            
            loading.fillAmount = progress;
            transform.GetChild(0).GetChild(2).GetComponent<Text>().text = (progress * 100f).ToString("0") + "%";

            yield return null;
        }
    }

    IEnumerator LoadSceneTimerWait() {
        yield return new WaitForSeconds(5);
        anim.Stop();
        StartCoroutine(LoadAsync(1));
    }
}
