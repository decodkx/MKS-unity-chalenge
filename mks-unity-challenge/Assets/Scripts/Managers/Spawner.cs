using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Camera cam;
    int interval;
    float time;
    public GameObject[] enemies;
    public Transform[] Spawns;
    public List<Transform> activatedSpawns = new List<Transform>();
    void Start()
    {
        time = interval = GameManagment.gameManager.GetInterval();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0){
            Spawn();
            time = interval;
        }
    }

    private void Spawn(){
        CheckSpawnPoints();
        if(activatedSpawns.Count > 0) 
            Instantiate(enemies[UnityEngine.Random.Range(0,2)],activatedSpawns[UnityEngine.Random.Range(0,activatedSpawns.Count)].position, this.transform.rotation);
    }

    private List<Transform> CheckSpawnPoints(){  //verifica quais pontos nao estao visiveis para a camera
        activatedSpawns.Clear();
        foreach (Transform spawnPoint in Spawns){

            Vector3 viewPos = Camera.main.WorldToViewportPoint(spawnPoint.position);
            if(viewPos.x < -0.1 || viewPos.x > 1.1 ||viewPos.y < -0.1 || viewPos.y > 1.1)
                activatedSpawns.Add(spawnPoint);            
        } 
        return activatedSpawns;
    }
}
