using UnityEngine;

public class GridShot : GameMode
{
    private AimTrainManager manager;
    private int maxSpheres = 3;

    public void StartMode(AimTrainManager manager)
    {
        this.manager = manager;

        for (int i = 0; i < maxSpheres; i++)
        {
            SpawnTarget();
        }
    }

    public void Update()
    {
        if (manager.ActiveTargets.Count < maxSpheres)
        {
            SpawnTarget();
        }


    }

    public void HandleHit(GameObject target)
    {
        manager.ActiveTargets.Remove(target);
        Object.Destroy(target);

        if (manager.ActiveTargets.Count < maxSpheres)
        {
            SpawnTarget();
        }



    }

    private void SpawnTarget()
    {
        if (manager.ActiveTargets.Count >= maxSpheres)
        {
            return;
        }


        int temp = Random.Range(0, manager.spawnList.Count);
        Transform randPoint = manager.spawnList[temp];

        if(randPoint.childCount > 0)
        {
            return;
        }

        GameObject gameObject = Object.Instantiate(manager.spherePrefab, randPoint.position, Quaternion.identity);
        manager.ActiveTargets.Add(gameObject);
        gameObject.transform.parent = randPoint;
    }

        public void EndMode()
    {
        foreach (var target in manager.ActiveTargets)
        {
            Object.Destroy(target);
        }
        manager.ActiveTargets.Clear();

    }
}
