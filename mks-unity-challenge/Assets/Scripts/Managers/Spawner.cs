using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Camera cam;
    int interval;
    float time;
    int index;
    public GameObject[] enemies;
    public Transform[] Spawns;
    public Transform[] ActivatedSpawns;
    void Start()
    {
        time = interval = 400;//GameManagment.gameManager.GetInterval();
        ActivatedSpawns = new Transform[2];

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        CheckSpawnPoints();


        if(time <= 0){
            Spawn();
            time = interval;
        }
    }

    private void Spawn(){
        CheckSpawnPoints();
        Instantiate(enemies[UnityEngine.Random.Range(0,2)],transform.position, this.transform.rotation);
    }

    private Transform[] CheckSpawnPoints(){  //verifica quais pontos nao estao visiveis para a camera
        index = 0;
        foreach (Transform spawnPoint in Spawns){
            index++;
            Vector3 viewPos = Camera.main.WorldToViewportPoint(spawnPoint.position);
            if(viewPos.x < -0.1 || viewPos.x > 1.1 ||viewPos.y < -0.1 || viewPos.y > 1.1)
                ActivatedSpawns[index] = spawnPoint;
        } 
        return Spawns;
    }
}
