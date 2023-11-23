using UnityEngine;
using UnityEngine.Events;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private string keyCode;
    [SerializeField]
    private float moveSpeed;

    public UnityEvent MoveEvent = new();

    void Update()
    {
        bool moveEvent = false;

        if (Input.GetAxis(keyCode + "Vertical") > 0)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            moveEvent = true;
        }

        if (Input.GetAxis(keyCode + "Horizontal") < 0)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            moveEvent = true;
        }

        if (Input.GetAxis(keyCode + "Vertical") < 0)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            moveEvent = true;
        }

        if (Input.GetAxis(keyCode + "Horizontal") > 0)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            moveEvent = true;
        }

        if (moveEvent)
            MoveEvent?.Invoke();
    }
}
