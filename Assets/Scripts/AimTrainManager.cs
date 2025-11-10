using System.Collections.Generic;
using UnityEngine;

public class AimTrainManager : MonoBehaviour
{
    public List<Transform> spawnList = new List<Transform>();
    public LayerMask layer;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioClip hitClip;
    [SerializeField] public GameObject spherePrefab;

    private GameMode currentGameMode;
    public List<GameObject> ActiveTargets { get; private set; } = new List<GameObject>();


    void Start()
    {
        hitSound.volume = SettingsManager.volume;
        SetScenario(new GridShot());

    }

    // Update is called once per frame
    void Update()
    {
        currentGameMode.Update();

        if (Input.GetMouseButtonDown(0))
        {
            DetectHit();
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

        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f)), out RaycastHit hit, Mathf.Infinity, layer))
        {
            Destroy(hit.collider.gameObject);
            hitSound.PlayOneShot(hitClip);
            currentGameMode.HandleHit(hit.collider.gameObject);
            ScoreManager.instance.updateScore();
            ScoreManager.instance.registerShot(true);
        }
        else
        {
            ScoreManager.instance.registerShot(false);
        }

    }
}
