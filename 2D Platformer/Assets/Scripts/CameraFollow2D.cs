using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector2 posOffset;

    [SerializeField]
    float leftLimit;

    [SerializeField]
    float rightLimit;

    [SerializeField]
    float bottomLimit;

    [SerializeField]
    float topLimit;


    private Vector3 velocity;

    void Update()
    {
        //Cameras current position
        Vector3 startPos = transform.position;

        //Players current position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        //Linear Interpolation (Lerp)
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        //dampening
        //transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),

            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Top Boundary Line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));

        //Right Boundary Line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));

        //Bottom Boundary Line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));

        //Left Boundary Line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));

    }
}
