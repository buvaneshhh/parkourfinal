using UnityEngine;

namespace ParkourSystem
{
    public class ParkourController : MonoBehaviour
    {
        bool inAction;
        EnvironmentScanner environmentScanner;
        Animator animator;

        private void Awake()
        {
            environmentScanner = GetComponent<EnvironmentScanner>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetButton("Jump") && !inAction)
            {
                var hitData = environmentScanner.ObstacleCheck();

                 if (hitData.forwardHitFound)
                {
                    inAction = true;
                    animator.CrossFade("Stepup", 0.2f );
                }
           

            }
            
        }
    }
}
