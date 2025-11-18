using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimTrainManager : MonoBehaviour
{
    public List<Transform> spawnList = new List<Transform>();
    public LayerMask layer;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioClip hitClip;
    [SerializeField] public GameObject spherePrefab;


    private float fireRate = 0.2f;
    private float nextFire = 0f;

    private GameMode currentGameMode;
    public List<GameObject> ActiveTargets { get; private set; } = new List<GameObject>();


    void Start()
    {

        hitSound.volume = SettingsManager.volume;
        if(GameModeSelect.currentMode != null)
        {
            SetScenario(GameModeSelect.currentMode);
        } else
        {
            SetScenario(new GridShot());
        }

    }

    // Update is called once per frame
    void Update()
    {
        currentGameMode.Update();

        if (Input.GetMouseButtonDown(0) && currentGameMode is GridShot || Input.GetMouseButtonDown(0) && currentGameMode is Strafing)
        {
            DetectHit();
        }

        else if(currentGameMode is Tracking)
        {
            if(Input.GetMouseButton(0) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                DetectHit();
            }
        }

    }

    public void SetScenario(GameMode scenario)
    {
        if (currentGameMode != null)
        {
            currentGameMode.EndMode();
        }

        currentGameMode = scenario;
        currentGameMode.StartMode(this);
    }


    private void DetectHit()
    {
        if (PauseScript.isPaused)
        {
            return;
        }

        bool rayHit = Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f)), out RaycastHit hit, Mathf.Infinity, layer);

        if (rayHit)
        {
            if (currentGameMode is GridShot || currentGameMode is Strafing)
            {
                Destroy(hit.collider.gameObject);
                hitSound.PlayOneShot(hitClip);
                currentGameMode.HandleHit(hit.collider.gameObject);
                ScoreManager.instance.updateScore();
                ScoreManager.instance.registerShot(true);
            }
            else if (currentGameMode is Tracking)
            {
                currentGameMode.HandleHit(hit.collider.gameObject);
                hitSound.PlayOneShot(hitClip);
                ScoreManager.instance.updateScore();
                ScoreManager.instance.registerShot(true);
            }

        }
        else
        {
            ScoreManager.instance.registerShot(false);
        }

    }
}
