using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
[System.Serializable]
    public class Wave{
        public Enemy[]enemies;
        public int count;
        public float timeBetweenSpawns;
    }
    public Wave wave;
    public Transform[]spawnPoints;
    private Transform player;
    private bool  finishedSpawning;
    public GameObject boss,sidehp;
    public Transform bossSpawnPoint;
     private Scene sceneLoaded;
    private void Start() {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        sceneLoaded=SceneManager.GetActiveScene();
        
             StartCoroutine(StartNextWave());    
        
        
        
    } 
    private void Update() {
        
        if(finishedSpawning&&GameObject.FindGameObjectsWithTag("Enemy").Length==0&&GameObject.FindGameObjectsWithTag("tta").Length==0){
            //lOAD SCENE ++
            UIManger.Instance.loadScene(2);
        }
        
    }
    IEnumerator StartNextWave(){
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(SpawnWave());
    }
    IEnumerator SpawnWave(){
            Wave currentWave=wave;
            for (int i = 0; i < currentWave.count; i++)
            {
                if(player==null){
                    yield break;
                }
                Enemy randomEnemy=currentWave.enemies[Random.Range(0,currentWave.enemies.Length)];
                Transform randomSpot=spawnPoints[Random.Range(0,spawnPoints.Length)];
                Instantiate(randomEnemy,randomSpot.position,randomSpot.rotation);
                if(i==currentWave.count-1){
                    finishedSpawning=true;
                }else{
                    finishedSpawning=false;
                }
                yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
            }
    }
}
