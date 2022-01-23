using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE {
    // The base class for all third-person camera controllers
    public abstract class TPCBase {
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;

        public Transform CameraTransform {
            get {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform {
            get {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform) {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
        }

        public void RepositionCamera() {
            /*-------------------------------------------------------------------
             Implement here.
            -------------------------------------------------------------------
            -------------------------------------------------------------------
            Hints:
            -------------------------------------------------------------------
            check collision between camera and the player.
            find the nearest collision point to the player
            shift the camera position to the nearest intersected point
            -------------------------------------------------------------------*/
            int layerMask = 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("IgoreCameraReposition"); //Set layermask to player and IngoreCameraReposition
            layerMask = ~layerMask; //Inverse the layermask
            RaycastHit hit;

            Vector3 playerWithOffSet = mPlayerTransform.position + new Vector3(0, 1.5f, 0); //Set a preset for the player's height location
            Debug.DrawRay(mCameraTransform.position, playerWithOffSet - mCameraTransform.position, Color.green); //For debuging purposes, draw a ray from the camera to the player

            if (Physics.Raycast(mCameraTransform.position, playerWithOffSet - mCameraTransform.position, out hit, 3, layerMask)) { //Detect raycast hit.
                if (!hit.transform.CompareTag("Player")) { //Check if the hit object is not the player, technically obsolete due to layermasking.
                    //Reposition
                    mCameraTransform.position = hit.point; //Reposition the camera
                }
            }
        }

        public abstract void Update();
    }
}
