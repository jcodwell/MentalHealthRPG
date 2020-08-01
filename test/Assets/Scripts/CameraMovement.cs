using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != target.position) // if the player positionnot equal to target position
        {
            // target position equals to target positions x and y
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            // target position of x and y will be clamped inside of its min and max
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            // then transform position will equal to the lerp of target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
