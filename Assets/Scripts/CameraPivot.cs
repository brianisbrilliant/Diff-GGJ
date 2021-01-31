using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    // when clicking, track mouse movement
    // if moving horizontal, rotate camerapivotY
    // if moving vertical, rotate camerapivotX
        // stretch goal, if scrolling, translate along camera's Z axis.

    Transform pivotX, pivotY, camera;
    [Tooltip("Whether or not to invert our Y axis for mouse input to rotation.")]
    public bool invertY = false;

    Vector2 verticalCameraBounds = new Vector2(-15f, 75f);


    // Start is called before the first frame update
    void Start()
    {
        pivotY = this.transform;
        pivotX = this.transform.GetChild(0);
        camera = this.transform.GetChild(0).GetChild(0);

        Debug.Log("pX: " + pivotX + " pY: " + pivotY);
    }

    public void Restart() {
        Application.LoadLevel(0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Exit Sample  
        if (Input.GetKey(KeyCode.Escape))
        {
            Restart();
        }


        // if(Input.GetMouseButtonDown(0)) {
        //     Cursor.lockState = CursorLockMode.Locked;
        // }

        // if(Input.GetMouseButtonUp(0)) {
        //     #if UNITY_EDITOR
        //     Cursor.visible = true;
        //     #endif
        //     Cursor.lockState = CursorLockMode.None;
        // }

        if (Input.GetMouseButton(0)) {
            var mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * (invertY ? 1 : -1));

            Debug.Log(mouseMovement);
    
            pivotX.Rotate(mouseMovement.y, 0, 0);
            pivotY.Rotate(0, mouseMovement.x, 0);
        }
    }
}
