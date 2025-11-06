using System;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class SphereSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;
    public int maxSphere = 3;
    public int randomSpawn;

    [SerializeField] private List<GameObject> activeSpheres = new List<GameObject>();
    [SerializeField] private List<Transform> spawnList = new List<Transform>();
    [SerializeField] LayerMask layer;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioClip hitClip;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitSound.volume = SettingsManager.volume;


    }

    // Update is called once per frame
    void Update()
    {

        SpawnSphere();

        if(Input.GetMouseButtonDown(0)){
            DetectHit();
        }
        
    }

    void SpawnSphere(){
        if(activeSpheres.Count >= maxSphere){
            return;
        }

        int temp = (int)Random.Range(0,spawnList.Count);
        Transform randPoint = spawnList[temp];
        while(randPoint.childCount == 0){
            GameObject sphere = Instantiate(spherePrefab, randPoint.position, UnityEngine.Quaternion.identity);
            activeSpheres.Add(sphere);
            sphere.transform.parent = randPoint;
        }
    }

    void DetectHit(){
        if (PauseScript.isPaused)
        {
            return;
        }

        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f)), out RaycastHit hit, Mathf.Infinity, layer)){
            Destroy(hit.collider.gameObject);
            activeSpheres.Remove(hit.collider.gameObject);
            if(activeSpheres.Count < maxSphere){
                SpawnSphere();
            }
            playSound();
            ScoreManager.instance.updateScore();
            ScoreManager.instance.registerShot(true);
        }
        else
        {
            ScoreManager.instance.registerShot(false);
        }
    }

    void playSound()
    {
        hitSound.PlayOneShot(hitClip);
    }

    
}
