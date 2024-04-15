using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    [SerializeField] SpriteRenderer maps;

    float zoomOutMin = 4;
    float zoomOutMax = 20;

    Vector3 touchStart;
    float mapsMinX, mapsMaxX, mapsMinY, mapsMaxY;
    public Movement pauza = Movement.Instance;

    void Start()
    {
        mapsMinX = maps.transform.position.x - maps.bounds.size.x / 2.0f;
        mapsMaxX = maps.transform.position.x + maps.bounds.size.x / 2.0f;
        mapsMinY = maps.transform.position.y - maps.bounds.size.y / 2.0f;
        mapsMaxY = maps.transform.position.y + maps.bounds.size.y / 2.0f;
    }
    
    void Update()
    {
        if (!pauza.GetPause())
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.touchCount == 2)
            {
                /*Vector3 diff = touchStart - Camera.main.ScreenToViewportPoint(Input.mousePosition);


                Camera.main.transform.position += diff;*/

                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.01f);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += direction;
                //Camera.main.transform.position = board(Camera.main.transform.position + direction);
            }

            //zoom(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
        Camera.main.transform.position = board(Camera.main.transform.position);
    }

    Vector3 board(Vector3 cam)
    {
        float camH = Camera.main.orthographicSize;
        float camW = Camera.main.orthographicSize * Camera.main.aspect;

        float minX = mapsMinX + camW;
        float maxX = mapsMaxX - camW;
        float minY = mapsMinY + camH;
        float maxY = mapsMaxY - camH;

        return new Vector3(
            Mathf.Clamp(cam.x, minX, maxX),
            Mathf.Clamp(cam.y, minY, maxY),
            cam.z
            );
    }
}
