using System;
using JMRSDK.InputModule;
using UnityEngine;

namespace Shreyansh
{
    /// <summary>
    /// Move and orient the object with the controller.
    /// </summary>
    public class ControllerOrientation : MonoBehaviour
    {
        /// <summary>
        /// Add additional offset to the object position
        /// </summary>
        [Tooltip("Add additional offset to the object")]
        public Vector3 additionalOffset;
    
        private Vector3 _orientation;

        /// <summary>
        /// Get JMRPointer Ray; Orient the bow looking at the raycast, and add offset to the position of bow.
        /// </summary>
        public void LateUpdate()
        {
            //get JMR Pointer Raycast
            Ray controllerRay = JMRPointerManager.Instance.GetCurrentRay();
            transform.position = controllerRay.GetPoint(additionalOffset.magnitude);

            //look towards the raycast
            transform.LookAt(controllerRay.GetPoint(5));

            //try getting controller orientation.
            IInputSource source = JMRInteractionManager.Instance.GetCurrentSource();
            Quaternion controllerOrientation = Quaternion.identity;
            try
            {
                source.TryGetPointerRotation(out controllerOrientation);
            }
            catch (Exception e)
            {
                //in editor there is no controller so ignore errors in editor.
                if (!Application.isEditor)
                {
                    Debug.Log(e.Message);
                }
            }

            //assign the orientation to the transform
            _orientation = transform.rotation.eulerAngles;
            _orientation.z = controllerOrientation.eulerAngles.z;
            transform.eulerAngles = _orientation;
        }
    }
}
