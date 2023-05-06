using UnityEngine;

    public class BillboardText : MonoBehaviour
    {
        
        public Transform cam;
        void Update() {
            transform.rotation = cam.transform.rotation;
        }
    }
