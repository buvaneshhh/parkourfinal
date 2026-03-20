using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationspeed = 500f;
    [SerializeField] float groundCheckRadius = 0.2f ;
    [SerializeField] float Vector3 groundCheckOffset ;
    [SerializeField] float LayerMask groundLayer ;

    Quaternion targetrotation;

    CameraController cameraController;
    Animator animator;
    CharacterController Charactercontroller;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        Charactercontroller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = (new Vector3(h,0,v)).normalized;
        var moveDir = cameraController.PlanarRotation * moveInput;
        

        if (moveAmount>0)
        {
            Charactercontroller.Move(moveDir * moveSpeed * Time.deltaTime);
            targetrotation = Quaternion.LookRotation(moveDir);
        }
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrotation , rotationspeed * Time.deltaTime);
        animator.SetFloat("moveAmount", moveAmount ,0.2f, Time.deltaTime);

    }
    void GroundCheck()
    {
        physics.CheckSphere();
        
    }

}
