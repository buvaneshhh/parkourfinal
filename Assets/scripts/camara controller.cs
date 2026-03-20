using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float rotationspeed =2;

    [SerializeField] float distance = 5;
    [SerializeField] float minverticalangle =-45;
    [SerializeField] float maxverticalangle = 45;
    [SerializeField] Vector2 framingOffset;

    [SerializeField] bool invertx;
    [SerializeField] bool inverty;

    float rotationy;
    float rotationx;

    float invertxval;
    float invertyval;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        invertxval = (invertx) ? -1 : 1;
        invertyval = (inverty) ? -1 : 1;

        rotationy += Input.GetAxis("Mouse X") * invertyval * rotationspeed;
        rotationx = Mathf.Clamp(rotationx ,minverticalangle ,maxverticalangle);
        rotationx += Input.GetAxis("Mouse Y")* invertxval *rotationspeed;
        var targetRotation = Quaternion.Euler(rotationx,rotationy,0);
        var focusposition = followTarget.position + new Vector3(framingOffset.x,framingOffset.y);
        
        transform.position = focusposition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
        
    }
    public Quaternion PlanarRotation => Quaternion.Euler(0,rotationy,0);
}