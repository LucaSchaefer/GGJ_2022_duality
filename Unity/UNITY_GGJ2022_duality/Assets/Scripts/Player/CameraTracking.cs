using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {

    public Transform trackingObject;
    public Transform followObject;
    public Vector3 followObjectDistance;

    private void Update( ) {
        transform.LookAt( trackingObject.position);

        transform.position = ( followObject.position + followObjectDistance );
    }

}
