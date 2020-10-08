using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Panning")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    [Header("Limit")]
    public float minY = 10f;
    public float maxY = 80f;
    public Vector2 limitZ;
    public Vector2 limitX;

    [Header("Scrolling")]
    public float scrollSpeed = 5f;

    private void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        // Forward - W
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        // Backward - S
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        // Left - A
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

        // Right - D
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, limitX.x, limitX.y);
        pos.z = Mathf.Clamp(pos.z, limitZ.x, limitZ.y);
        transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Top Border
        Gizmos.DrawLine(new Vector3(limitX.x, 0, limitZ.x), new Vector3(limitX.y, 0, limitZ.x));
        //Right Border
        Gizmos.DrawLine(new Vector3(limitX.y, 0, limitZ.x), new Vector3(limitX.y, 0, limitZ.y));
        //Left Border
        Gizmos.DrawLine(new Vector3(limitX.x, 0, limitZ.x), new Vector3(limitX.x, 0, limitZ.y));
        //Bottom Border
        Gizmos.DrawLine(new Vector3(limitX.x, 0, limitZ.y), new Vector3(limitX.y, 0, limitZ.y));
    }
}
