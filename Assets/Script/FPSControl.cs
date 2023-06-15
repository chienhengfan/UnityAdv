using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControl : MonoBehaviour
{
    public Transform controlCamera;
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 1.0f;
    public Transform cameraFollowPt;
    public Transform gunRoot;
    public Transform emitPoint;
    public Object hitEffect;
    public Object lineEffect;
    // public LayerMask hitMask;
    private float cameraH = 0.0f;
    private float focusDistance = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = controlCamera.position - transform.position;
        cameraH = vec.y;
        
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        float rotateAmount = mouseX * rotateSpeed;
        transform.Rotate(0, rotateAmount, 0);

        float fMoveV = Input.GetAxis("Vertical");
        float fMoveH = Input.GetAxis("Horizontal");
        Vector3 vForward = transform.forward;
        controlCamera.Rotate(mouseY, 0, 0, Space.Self);
        controlCamera.Rotate(0, rotateAmount, 0, Space.World);

        gunRoot.Rotate(mouseY, 0, 0, Space.Self);

        Vector3 vRight = transform.right;
        Vector3 moveAmount = (vForward * fMoveV + vRight * fMoveH)* moveSpeed* Time.deltaTime;
        transform.position = transform.position + moveAmount;
        controlCamera.position = Vector3.Lerp(controlCamera.position, cameraFollowPt.position, 1.0f);//transform.position + Vector3.up * cameraH;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 1. Camera dir
            // 2. Screen pos 0.5, 0.5,  Screen.Width*0.5, Screen.Height*0.5
            Ray r = new Ray(controlCamera.position, controlCamera.forward);
            int iLayerMask = 1 << LayerMask.NameToLayer("Enemy") | 1 << LayerMask.NameToLayer("Terrain") | 1 << LayerMask.NameToLayer("Wall");
            // string[] strs = new string[1];
            //strs[0] = "Enemy";
            // int iLayerMask = LayerMask.GetMask(strs);
            RaycastHit rh = new RaycastHit();
            bool bHit = Physics.Raycast(r, out rh, 1000.0f, iLayerMask);

            GameObject go = GameObject.Instantiate(lineEffect) as GameObject;
            BulletLine bleffect =  go.GetComponent<BulletLine>();
            go.transform.position = emitPoint.position;
            if (bHit)
            {
                Debug.Log(rh.collider.name);
                Debug.Log(rh.point);
                if(rh.distance < focusDistance)
                {
                    Vector3 tempPos = controlCamera.position + controlCamera.forward * focusDistance;
                    Vector3 emitDir = tempPos - emitPoint.position;
                    go.transform.forward = emitDir;
                    emitDir.Normalize();
                    Ray r2 = new Ray(emitPoint.position, emitDir);
                    RaycastHit rh2 = new RaycastHit();
                    if(Physics.Raycast(r2, out rh2, 1000.0f, iLayerMask))
                    {
                       
                        GameObject gEffect = GameObject.Instantiate(hitEffect) as GameObject;
                        gEffect.transform.position = rh2.point;
                        gEffect.transform.forward = rh2.normal;
                        bleffect.SetupLine(rh2.distance, 0.1f);
                        if (rh.collider.tag == "enemy")
                        {
                            GameObject g = rh2.collider.gameObject;
                            g.SendMessage("Damage", 10.0f);
                            // enemy ey = g.GetComponent<enemy>();
                            // ey.Damage(10.0f);

                        }
                    } else
                    {
                        bleffect.SetupLine(1000.0f, 0.1f);
                    }
                } else
                {
                    GameObject gEffect = GameObject.Instantiate(hitEffect) as GameObject;
                    gEffect.transform.position = rh.point;
                    gEffect.transform.forward = rh.normal;
                    go.transform.forward = rh.point - emitPoint.position;
                    bleffect.SetupLine(rh.distance, 0.1f);
                    if (rh.collider.tag == "enemy")
                    {
                        GameObject g = rh.collider.gameObject;
                        g.SendMessage("Damage", 10.0f);
                        // enemy ey = g.GetComponent<enemy>();
                        // ey.Damage(10.0f);

                    }
                }
                
            } else
            {
                Vector3 tempPos = controlCamera.position + controlCamera.forward * 1000.0f;
                go.transform.forward = tempPos - emitPoint.position;
                bleffect.SetupLine(1000.0f, 0.1f);
                // GameObject lineEffect;
                //  lineEffect.po
                // controlCamera.position + controlCamera.forward * focusDistance;
            }
           // Debug.Log(bHit);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(controlCamera.position, controlCamera.position + controlCamera.forward * focusDistance);
    }
}
