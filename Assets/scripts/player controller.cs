using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationspeed = 500f;

    Quaternion targetrotation;

    CameraController cameraController;
    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Abs(h) + Mathf.Abs(v);

        var moveInput = (new Vector3(h,0,v)).normalized;
        var moveDir = cameraController.PlanarRotation * moveInput;

        if (moveAmount>0)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            targetrotation = Quaternion.LookRotation(moveDir);
        }
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrotation , rotationspeed * Time.deltaTime);
        

    }
}
