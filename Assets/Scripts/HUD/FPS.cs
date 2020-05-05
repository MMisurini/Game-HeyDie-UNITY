using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour
{
    private float frequency = 1.0f;
    private string fps;

    void Start()
    {
        StartCoroutine(FPSTest());
    }

    private IEnumerator FPSTest()
    {
        for (; ; )
        {
            // Capture frame-per-second
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;

            // Display it

            fps = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
        }
    }


    void OnGUI()
    {
        var test = new GUIStyle();
        test.normal.textColor = new Color(0, 0, 0);
        test.fontSize = 20;
        test.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(Screen.width - 200, 50, 150, 20), fps, test) ;
    }
}