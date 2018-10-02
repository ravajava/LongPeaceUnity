using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Title: Camera
 * Author: Josue Lopes
 * Date: October 1st, 2018
*/

public class TopDownCamera : MonoBehaviour
{
    public float CameraSpeed = 10.0f;
    public float ZoomSpeed = 5.0f;

    private const float MOUSE_LOOK_BUFFER = 0.5f;    // buffer distance away from edges for mouse look
    private const float MOUSE_MAX_X_DISTANCE = 5.0f; // boundary constants for mouse movement and zoom
    private const float MOUSE_MAX_Y_DISTANCE = 5.0f;
    private const float MOUSE_MIN_X_DISTANCE = -5.0f;
    private const float MOUSE_MIN_Y_DISTANCE = -5.0f;
    private const float ZOOM_IN_MAX_DISTANCE = 2.0f;
    private const float ZOOM_OUT_MAX_DISTANCE = -2.0f;

    private float m_CameraXDistance = 0.0f;
    private float m_CameraYDistance = 0.0f;
    private float m_ZoomDistance = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        UpdateMouseLook();
        UpdateZoom();
    }

    private void UpdateMouseLook()
    {
        // check if mouse position is at edges of screen
        // bottom
        if (Input.mousePosition.y <= MOUSE_LOOK_BUFFER || Input.GetButton("CameraDown"))
        {
            Vector3 oldPosition = transform.position;
            Vector3 newPosition = oldPosition - transform.up * CameraSpeed * Time.deltaTime;
            float dist = m_CameraYDistance - Vector3.Distance(oldPosition, newPosition);

            if (!CheckForVerticalBounds(dist))
            {
                transform.position = newPosition;
                m_CameraYDistance = dist;
            }
        }

        // top
        if (Input.mousePosition.y >= (Screen.height - MOUSE_LOOK_BUFFER) || Input.GetButton("CameraUp"))
        {
            Vector3 oldPosition = transform.position;
            Vector3 newPosition = oldPosition + transform.up * CameraSpeed * Time.deltaTime;
            float dist = m_CameraYDistance + Vector3.Distance(oldPosition, newPosition);

            if (!CheckForVerticalBounds(dist))
            {
                transform.position = newPosition;
                m_CameraYDistance = dist;
            }
        }

        // left
        if (Input.mousePosition.x <= MOUSE_LOOK_BUFFER || Input.GetButton("CameraLeft"))
        {
            Vector3 oldPosition = transform.position;
            Vector3 newPosition = oldPosition - transform.right * CameraSpeed * Time.deltaTime;
            float dist = m_CameraXDistance - Vector3.Distance(oldPosition, newPosition);

            if (!CheckForHorizontalBounds(dist))
            {
                transform.position = newPosition;
                m_CameraXDistance = dist;
            }
        }

        // right
        if (Input.mousePosition.x >= (Screen.width - MOUSE_LOOK_BUFFER) || Input.GetButton("CameraRight"))
        {
            Vector3 oldPosition = transform.position;
            Vector3 newPosition = oldPosition + transform.right * CameraSpeed * Time.deltaTime;
            float dist = m_CameraXDistance + Vector3.Distance(oldPosition, newPosition);

            if (!CheckForHorizontalBounds(dist))
            {
                transform.position = newPosition;
                m_CameraXDistance = dist;
            }
        }
    }

    // updates camera zoom with scroll wheel input
    private void UpdateZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Vector3 oldPosition = transform.position;
            Vector3 newPosition = oldPosition + transform.forward * ZoomSpeed * Time.deltaTime;
            float dist = m_ZoomDistance + Vector3.Distance(oldPosition, newPosition);

            if (!CheckForZoomBounds(dist))
            {
                transform.position = newPosition;
                m_ZoomDistance = dist;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Vector3 oldPosition = transform.position;
            Vector3 newPosition = oldPosition - transform.forward * ZoomSpeed * Time.deltaTime;
            float dist = m_ZoomDistance - Vector3.Distance(oldPosition, newPosition);

            if (!CheckForZoomBounds(dist))
            {
                transform.position = newPosition;
                m_ZoomDistance = dist;
            }
        }
    }

    // check if camera has reached horizontal bounds
    private bool CheckForHorizontalBounds(float testDistance)
    {
        if (testDistance >= MOUSE_MAX_X_DISTANCE)
            return true;
        else if (testDistance <= MOUSE_MIN_X_DISTANCE)
            return true;

        return false;
    }

    // check if camera has reached vertical bounds
    private bool CheckForVerticalBounds(float testDistance)
    {
        if (testDistance >= MOUSE_MAX_Y_DISTANCE)
            return true;
        else if (testDistance <= MOUSE_MIN_Y_DISTANCE)
            return true;

        return false;
    }

    // check if zoom has reached bounds
    private bool CheckForZoomBounds(float testDistance)
    {
        if (testDistance >= ZOOM_IN_MAX_DISTANCE)
            return true;
        else if (testDistance <= ZOOM_OUT_MAX_DISTANCE)
            return true;

        return false;
    }
}
