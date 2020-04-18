using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    public float smoothSpeed = 10f;

    [Range(5, 10)]
    public int cameraZoom = 10;

    public int cameraDistance = 10;

    public Camera thisCam;
    

    void Start()
    {
        thisCam = this.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        thisCam.orthographicSize = cameraZoom;

        Vector3 desiredPosition = new Vector3(target.position.x, cameraDistance, target.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        cameraZoomFunct();
    }

    void cameraZoomFunct()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && cameraZoom <=10 && cameraZoom >5)
        {
            cameraZoom--;
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && cameraZoom >= 5 && cameraZoom <10)
        {
                cameraZoom++;
            
        }
    }
}
