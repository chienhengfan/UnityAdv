using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLookTarget : MonoBehaviour
{
    public Transform head;
    public Transform lookpt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 vFor = transform.forward;
        Vector3 vec = lookpt.position - head.position;
        Vector3 hvec = vec;
        hvec.y = 0;
        hvec.Normalize();
        float vAngle = Vector3.Angle(vec, hvec);
        float hAngle = Vector3.Angle(hvec, vFor);
        if(hAngle > 30)
        {
            hAngle = 30;

        }
        float fDot = Vector3.Dot(transform.right, hvec);
        if (fDot < 0)
        {
            hAngle = -hAngle;
        }
        if (vAngle > 10)
        {
            vAngle = 10;
        }
        if (vec.y > 0)
        {
            vAngle = -vAngle;
        }

        // new vector = quaternion * old vector
        Quaternion qRot0 = Quaternion.Euler(0, hAngle, 0);
        Vector3 vecR0 = qRot0 * vFor;
        Vector3 vAxis = Vector3.Cross(Vector3.up, vecR0);
        Quaternion qRot = Quaternion.AngleAxis(vAngle, vAxis);
        vec = qRot * vecR0;

        head.rotation = qRot*qRot0*head.rotation;

       // head.forward = vec;
       // head.Rotate(0, 0, -90, Space.Self);
      //  head.Rotate(90, 0, 0, Space.Self);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(lookpt.position, head.position);
    }
}
