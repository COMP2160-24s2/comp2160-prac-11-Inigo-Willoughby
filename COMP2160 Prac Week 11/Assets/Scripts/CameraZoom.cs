using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{

    [SerializeField] private Camera cam;

    #region Actions
    private Actions actions;
    private InputAction zoomAction;
    #endregion

    #region Values
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;
    [SerializeField] private float current;
    [SerializeField] private float zoom;
    [SerializeField] private float zoomSpeed;
    #endregion


    void Awake(){
        actions = new Actions();
        zoomAction = actions.camera.zoom;
    }

    void OnEnable(){
      actions.camera.Enable();
    }

    void OnDisable(){
      actions.camera.Disable();
    }

    void Start(){
        if(cam.orthographic){
            zoom = 5.0f;
        }
        else{
            zoom = 59.0f;
        }
    }


    // Update is called once per frame
    void Update(){    
        current = zoomAction.ReadValue<float>();
        if(cam.orthographic){
           zoom = Mathf.Clamp(zoom, minSize, maxSize);
           zoom -= current * zoomSpeed * Time.deltaTime;
           cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * 2.0f);
        }
        else{
            zoom = Mathf.Clamp(zoom, minFOV, maxFOV);
            zoom -= current * zoomSpeed * Time.deltaTime;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom, Time.deltaTime * 2.0f);
        }
    }
}
