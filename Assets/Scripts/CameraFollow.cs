using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public string playerTag = "Player"; 
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        if (players.Length > 0)
        {
            Transform target = players[0].transform;

            //Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y,0);
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            //transform.position = smoothedPosition;
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, gameObject.transform.position.z);

            transform.position = desiredPosition;

        }
    }
}
