using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winceground : MonoBehaviour
{
    private Enable enableScript;

    [SerializeField] private GameObject particleThorns = null;
    [SerializeField] private List<GameObject> cubes = null;
    private float max = 0.08f;
    private float min = -0.02f;
    [Header("Velocidade Tremor")]
    [SerializeField] private float speed;
    [SerializeField] private float duration = 1.2f;
    private float timerAttack = 0f;

    private ParticleSystem thorn_instantiate = null;
    private GameObject ground_instantiate = null;

    void Start() {
        enableScript = GetComponent<Enable>();
        
        FindAllObjects();
    }

    void OnEnable() {
        transform.position = new Vector3(Random.Range(-3.5f, 3.5f), transform.position.y, -4.5f);

        ground_instantiate = Instantiate(particleThorns, transform.position, particleThorns.transform.rotation);
        ground_instantiate.transform.GetChild(0).GetComponent<ParticleSystem>().trigger.SetCollider(0, GameObject.FindGameObjectWithTag("Player").transform);
    }

    void Update() {
        if (enableScript.ChangeEnable) {
            timerAttack += Time.deltaTime;
            if (timerAttack < duration) {
                Objects();                
            } else {
                if (ground_instantiate.GetComponent<ParticleSystem>().isStopped) {
                    foreach (GameObject a in cubes) {
                        a.SetActive(false);
                    }

                    timerAttack = 0;
                    Destroy(ground_instantiate);
                    GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<ControllerDrop>().SetSpecialAnimation = false;
                    enableScript.ChangeEnable = false;
                    Destroy(transform.gameObject);
                }
            }
        }
    }


    void Objects() {
        cubes[0].transform.position = Vector3.Lerp(cubes[0].transform.position, new Vector3(cubes[0].transform.position.x, Random.Range(min, max), cubes[0].transform.position.z), speed * Time.deltaTime);
        cubes[1].transform.position = Vector3.Lerp(cubes[1].transform.position, new Vector3(cubes[1].transform.position.x, Random.Range(min, max), cubes[1].transform.position.z), speed * Time.deltaTime);
        cubes[2].transform.position = Vector3.Lerp(cubes[2].transform.position, new Vector3(cubes[2].transform.position.x, Random.Range(min, max), cubes[2].transform.position.z), speed * Time.deltaTime);
        cubes[3].transform.position = Vector3.Lerp(cubes[3].transform.position, new Vector3(cubes[3].transform.position.x, Random.Range(min, max), cubes[3].transform.position.z), speed * Time.deltaTime);
        cubes[4].transform.position = Vector3.Lerp(cubes[4].transform.position, new Vector3(cubes[4].transform.position.x, Random.Range(min, max), cubes[4].transform.position.z), speed * Time.deltaTime);
        cubes[5].transform.position = Vector3.Lerp(cubes[5].transform.position, new Vector3(cubes[5].transform.position.x, Random.Range(min, max), cubes[5].transform.position.z), speed * Time.deltaTime);
        cubes[6].transform.position = Vector3.Lerp(cubes[6].transform.position, new Vector3(cubes[6].transform.position.x, Random.Range(min, max), cubes[6].transform.position.z), speed * Time.deltaTime);
        cubes[7].transform.position = Vector3.Lerp(cubes[7].transform.position, new Vector3(cubes[7].transform.position.x, Random.Range(min, max), cubes[7].transform.position.z), speed * Time.deltaTime);
        cubes[8].transform.position = Vector3.Lerp(cubes[8].transform.position, new Vector3(cubes[8].transform.position.x, Random.Range(min, max), cubes[8].transform.position.z), speed * Time.deltaTime);
        cubes[9].transform.position = Vector3.Lerp(cubes[9].transform.position, new Vector3(cubes[9].transform.position.x, Random.Range(min, max), cubes[9].transform.position.z), speed * Time.deltaTime);
        cubes[10].transform.position = Vector3.Lerp(cubes[10].transform.position, new Vector3(cubes[10].transform.position.x, Random.Range(min, max), cubes[10].transform.position.z), speed * Time.deltaTime);
        cubes[11].transform.position = Vector3.Lerp(cubes[1].transform.position, new Vector3(cubes[11].transform.position.x, Random.Range(min, max), cubes[11].transform.position.z), speed * Time.deltaTime);
        cubes[12].transform.position = Vector3.Lerp(cubes[12].transform.position, new Vector3(cubes[12].transform.position.x, Random.Range(min, max), cubes[12].transform.position.z), speed * Time.deltaTime);
        cubes[12].transform.position = Vector3.Lerp(cubes[13].transform.position, new Vector3(cubes[13].transform.position.x, Random.Range(min, max), cubes[13].transform.position.z), speed * Time.deltaTime);
        cubes[14].transform.position = Vector3.Lerp(cubes[14].transform.position, new Vector3(cubes[14].transform.position.x, Random.Range(min, max), cubes[14].transform.position.z), speed * Time.deltaTime);
        cubes[15].transform.position = Vector3.Lerp(cubes[15].transform.position, new Vector3(cubes[15].transform.position.x, Random.Range(min, max), cubes[15].transform.position.z), speed * Time.deltaTime);
        cubes[16].transform.position = Vector3.Lerp(cubes[16].transform.position, new Vector3(cubes[16].transform.position.x, Random.Range(min, max), cubes[16].transform.position.z), speed * Time.deltaTime);
        cubes[17].transform.position = Vector3.Lerp(cubes[17].transform.position, new Vector3(cubes[17].transform.position.x, Random.Range(min, max), cubes[17].transform.position.z), speed * Time.deltaTime);
        cubes[18].transform.position = Vector3.Lerp(cubes[18].transform.position, new Vector3(cubes[18].transform.position.x, Random.Range(min, max), cubes[18].transform.position.z), speed * Time.deltaTime);
        cubes[19].transform.position = Vector3.Lerp(cubes[19].transform.position, new Vector3(cubes[19].transform.position.x, Random.Range(min, max), cubes[19].transform.position.z), speed * Time.deltaTime);
        cubes[20].transform.position = Vector3.Lerp(cubes[20].transform.position, new Vector3(cubes[20].transform.position.x, Random.Range(min, max), cubes[20].transform.position.z), speed * Time.deltaTime);
        cubes[21].transform.position = Vector3.Lerp(cubes[21].transform.position, new Vector3(cubes[21].transform.position.x, Random.Range(min, max), cubes[21].transform.position.z), speed * Time.deltaTime);
        cubes[22].transform.position = Vector3.Lerp(cubes[22].transform.position, new Vector3(cubes[22].transform.position.x, Random.Range(min, max), cubes[22].transform.position.z), speed * Time.deltaTime);
        cubes[23].transform.position = Vector3.Lerp(cubes[23].transform.position, new Vector3(cubes[23].transform.position.x, Random.Range(min, max), cubes[23].transform.position.z), speed * Time.deltaTime);
        cubes[24].transform.position = Vector3.Lerp(cubes[24].transform.position, new Vector3(cubes[24].transform.position.x, Random.Range(min, max), cubes[24].transform.position.z), speed * Time.deltaTime);
        cubes[25].transform.position = Vector3.Lerp(cubes[25].transform.position, new Vector3(cubes[25].transform.position.x, Random.Range(min, max), cubes[25].transform.position.z), speed * Time.deltaTime);
        cubes[26].transform.position = Vector3.Lerp(cubes[26].transform.position, new Vector3(cubes[26].transform.position.x, Random.Range(min, max), cubes[26].transform.position.z), speed * Time.deltaTime);
        cubes[27].transform.position = Vector3.Lerp(cubes[27].transform.position, new Vector3(cubes[27].transform.position.x, Random.Range(min, max), cubes[27].transform.position.z), speed * Time.deltaTime);
        cubes[28].transform.position = Vector3.Lerp(cubes[28].transform.position, new Vector3(cubes[28].transform.position.x, Random.Range(min, max), cubes[28].transform.position.z), speed * Time.deltaTime);
        cubes[29].transform.position = Vector3.Lerp(cubes[29].transform.position, new Vector3(cubes[29].transform.position.x, Random.Range(min, max), cubes[29].transform.position.z), speed * Time.deltaTime);
        cubes[30].transform.position = Vector3.Lerp(cubes[30].transform.position, new Vector3(cubes[30].transform.position.x, Random.Range(min, max), cubes[30].transform.position.z), speed * Time.deltaTime);
        cubes[31].transform.position = Vector3.Lerp(cubes[31].transform.position, new Vector3(cubes[31].transform.position.x, Random.Range(min, max), cubes[31].transform.position.z), speed * Time.deltaTime);
        cubes[32].transform.position = Vector3.Lerp(cubes[32].transform.position, new Vector3(cubes[32].transform.position.x, Random.Range(min, max), cubes[32].transform.position.z), speed * Time.deltaTime);
        cubes[33].transform.position = Vector3.Lerp(cubes[33].transform.position, new Vector3(cubes[33].transform.position.x, Random.Range(min, max), cubes[33].transform.position.z), speed * Time.deltaTime);
        cubes[34].transform.position = Vector3.Lerp(cubes[34].transform.position, new Vector3(cubes[34].transform.position.x, Random.Range(min, max), cubes[34].transform.position.z), speed * Time.deltaTime);
        cubes[35].transform.position = Vector3.Lerp(cubes[35].transform.position, new Vector3(cubes[35].transform.position.x, Random.Range(min, max), cubes[35].transform.position.z), speed * Time.deltaTime);
        cubes[36].transform.position = Vector3.Lerp(cubes[36].transform.position, new Vector3(cubes[36].transform.position.x, Random.Range(min, max), cubes[36].transform.position.z), speed * Time.deltaTime);
        cubes[37].transform.position = Vector3.Lerp(cubes[37].transform.position, new Vector3(cubes[37].transform.position.x, Random.Range(min, max), cubes[37].transform.position.z), speed * Time.deltaTime);
        cubes[38].transform.position = Vector3.Lerp(cubes[38].transform.position, new Vector3(cubes[38].transform.position.x, Random.Range(min, max), cubes[38].transform.position.z), speed * Time.deltaTime);
        cubes[39].transform.position = Vector3.Lerp(cubes[39].transform.position, new Vector3(cubes[39].transform.position.x, Random.Range(min, max), cubes[39].transform.position.z), speed * Time.deltaTime);
        cubes[40].transform.position = Vector3.Lerp(cubes[40].transform.position, new Vector3(cubes[40].transform.position.x, Random.Range(min, max), cubes[40].transform.position.z), speed * Time.deltaTime);
    }

    void FindAllObjects() {
        for (int i = 0;i < transform.childCount;i++) {
            cubes.Add(transform.GetChild(i).gameObject);
        }
    }
}
