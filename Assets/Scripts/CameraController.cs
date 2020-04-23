using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float horizontalSpeed = 20f;
    public float activeBorderSize = 5f;
    public float scrollSpeed = 3f;
    public float minY = 20f;
    public float maxY = 80f;

    void Update()
    {
        if (Input.GetKey("s") || Input.mousePosition.y <= activeBorderSize)
        {
            transform.Translate(Vector3.forward * horizontalSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - activeBorderSize)
        {
            transform.Translate(Vector3.back * horizontalSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - activeBorderSize)
        {
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= activeBorderSize)
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;
        position.y -= scroll * 100 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
