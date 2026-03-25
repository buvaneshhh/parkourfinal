using UnityEngine;

namespace ParkourSystem
{
    public class EnvironmentScanner : MonoBehaviour
    {
        [Header("Forward Ray")]
        [SerializeField] private Vector3 forwardRayOffset = new Vector3(0f, 0.25f, 0f);
        [SerializeField] private float forwardRayLength = 0.8f;

        [Header("Height Ray")]
        [SerializeField] private float heightRayLength = 5f;

        [Header("Layers")]
        [SerializeField] private LayerMask obstacleLayer;

        public struct ObstacleHitData
        {
            public bool forwardHitFound;
            public RaycastHit forwardHit;

            public bool heightHitFound;
            public RaycastHit heightHit;
        }

        public ObstacleHitData ObstacleCheck()
        {
            ObstacleHitData hitData = new ObstacleHitData();

            // Forward ray
            Vector3 forwardOrigin = transform.position + forwardRayOffset;

            hitData.forwardHitFound = Physics.Raycast(
                forwardOrigin,
                transform.forward,
                out hitData.forwardHit,
                forwardRayLength,
                obstacleLayer
            );

            Debug.DrawRay(
                forwardOrigin,
                transform.forward * forwardRayLength,
                hitData.forwardHitFound ? Color.red : Color.white
            );

            // Height ray (only if we hit something in front)
            if (hitData.forwardHitFound)
            {
                // Point above the forward hit point
                Vector3 heightOrigin =
                    hitData.forwardHit.point + (Vector3.up * heightRayLength);

                hitData.heightHitFound = Physics.Raycast(
                    heightOrigin,
                    Vector3.down,
                    out hitData.heightHit,
                    heightRayLength,
                    obstacleLayer
                );

                Debug.DrawRay(
                    heightOrigin,
                    Vector3.down * heightRayLength,
                    hitData.heightHitFound ? Color.red : Color.white
                );
            }

            return hitData;
        }
    }
}
