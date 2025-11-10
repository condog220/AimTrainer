using UnityEngine;

public interface GameMode
{
    void StartMode(AimTrainManager manager);
    void EndMode();

    void Update();

    void HandleHit(GameObject target);
}
