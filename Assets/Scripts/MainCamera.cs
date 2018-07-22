using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public float zoomSpeed = 500f;
    public float maxDistanceBtwCameraCharacter = 25f;
    public float minDistanceBtwCameraCharacter = 3f;
    public bool mouseLock = true;
    public bool isTopView = false;

    GameObject characterObj = null;
    GameObject cameraPointObj = null;    

    float inputCameraZoom = 0f;
    bool inputViewMode;

    float distanceBtwCameraCharacter = 0f;
    float timeAccForViewMode = 0f;
    bool viewModeChangeEnable = false;

    // Use this for initialization
    void Start ()
    {
        characterObj = GameObject.Find("RPG-Character");
        cameraPointObj = GameObject.Find("Camera Point");
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanceBtwCameraCharacter = Vector3.Distance(transform.position, characterObj.transform.position);
        Inputs();
        CameraMove();        
    }

    void Inputs()
    {
        inputCameraZoom = Input.GetAxis("Mouse ScrollWheel");
        inputViewMode = Input.GetButtonDown("ViewMode");
    }

    void CameraMove()
    {
        if (inputCameraZoom < 0f)
        {
            if(distanceBtwCameraCharacter <= maxDistanceBtwCameraCharacter)
                transform.position += transform.forward * inputCameraZoom * Time.deltaTime * zoomSpeed;
        }

        if (inputCameraZoom > 0f)
        {
            if (distanceBtwCameraCharacter >= minDistanceBtwCameraCharacter)
                transform.position += transform.forward * inputCameraZoom * Time.deltaTime * zoomSpeed;
        }

        if(inputViewMode)
        {
            isTopView = !isTopView;
            viewModeChangeEnable = true;
        }

        if (isTopView && viewModeChangeEnable)
        {
            timeAccForViewMode += Time.deltaTime;

            if (timeAccForViewMode <= 1f)
                transform.RotateAround(cameraPointObj.transform.position, cameraPointObj.transform.forward, timeAccForViewMode);
            else
            {
                timeAccForViewMode = 0f;
                viewModeChangeEnable = false;
            }
        }
        else if(!isTopView && viewModeChangeEnable)
        {
            timeAccForViewMode += Time.deltaTime;

            if (timeAccForViewMode <= 1f)
                transform.RotateAround(cameraPointObj.transform.position, cameraPointObj.transform.forward, -timeAccForViewMode);
            else
            {
                timeAccForViewMode = 0f;
                viewModeChangeEnable = false;
            }
        }        
    }
}
