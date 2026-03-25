using UnityEngine;

namespace ParkourSystem
{
    public class ParkourController : MonoBehaviour
    {
        private EnvironmentScanner _environmentScanner;

        private void Awake()
        {
            _environmentScanner = GetComponent<EnvironmentScanner>();
        }

        private void Update()
        {
            var hitData = _environmentScanner.ObstacleCheck();

            if (hitData.forwardHitFound)
            {
                Debug.Log(
                    "Obstacle found: " + hitData.forwardHit.transform.name
                );
                // TODO: Trigger parkour actions here in later parts
            }
        }
    }
}
