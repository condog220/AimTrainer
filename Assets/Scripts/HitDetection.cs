using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class HitDetection : MonoBehaviour
{

    public AudioSource hitSound;
    public AudioClip hitClip;

    [SerializeField]LayerMask layer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DetectHit(){
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f)), out RaycastHit hit, layer)){
            Destroy(hit.collider.gameObject);
            PlayHitSound();
            Debug.Log("Hit Detected, object destroyed and sound played.");



        }
    }

    void PlayHitSound()
    {
        hitSound.PlayOneShot(hitClip);
    }
}
