using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Player
{

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovimentation : MonoBehaviour
    {
        
        private Rigidbody playerRigidbody;
        private Camera mainCamera;

        [HideInInspector]
        public float playerVelocity;

        [SerializeField] private float mouseSensitivity = 2.0f;

        private Quaternion originalBodyRotation;
        private Quaternion originalCamRotation;

        float rotationX = 0.0f;
	    float rotationY = 0.0f;            

        private void Start()
        {

            playerRigidbody = GetComponent<Rigidbody>();
            mainCamera = GetComponentInChildren<Camera>();

            // Gets the original rotations for mouselook.
            originalBodyRotation = transform.localRotation;
            originalCamRotation = mainCamera.transform.localRotation;

        }

        private void Update()
        {            

            // Moves the player.
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
            Vector3 newVel = playerVelocity * transform.TransformDirection(input);
            float yVel = playerRigidbody.velocity.y;
            newVel.y = yVel;

            playerRigidbody.velocity = newVel;

            // Rotates on the x-axis.
            rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationX = ClampAngle (rotationX, -360.0f, 360.0f);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalBodyRotation * xQuaternion;

            // Rotates on the y-axis.
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationY = ClampAngle (rotationY, -90.0f, 90.0f);

            Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
            mainCamera.transform.localRotation = originalCamRotation * yQuaternion;

        }

        // Clamps pĺayer's rotation angles.
        private float ClampAngle (float angle, float min, float max)
        {
            if (angle < -360.0f)
                angle += 360.0f;
            if (angle > 360.0f)
                angle -= 360.0f;
            return Mathf.Clamp (angle, min, max);
        }

    }
    
}
