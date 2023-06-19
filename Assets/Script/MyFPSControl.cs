using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFPSControl : MonoBehaviour
{
    public Transform controlCamera;
    public Transform cameraFollowPT;
    public Transform gunRoot;

    public float rotateSpeed = 1.0f;
    public float moveSpeed = 2.0f;
    public float cameraH = 0.0f;

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
        float rotateAmountX = rotateSpeed * mouseX;

        transform.Rotate(0, rotateAmountX, 0);

        controlCamera.Rotate(0, rotateAmountX, 0, Space.World);
        controlCamera.Rotate(mouseY, 0, 0, Space.Self);
        gunRoot.Rotate(mouseY, 0, 0, Space.Self);



        float fMoveV = Input.GetAxis("Vertical");
        float fMoveH = Input.GetAxis("Horizontal");

        Vector3 vForward = transform.forward;
        Vector3 vRigght = transform.right;

        Vector3 moveAmount = (vForward * fMoveV + vRigght * fMoveH) * moveSpeed * Time.deltaTime;
        transform.position = transform.position + moveAmount;
        controlCamera.position = Vector3.Lerp(transform.position, cameraFollowPT.position, 0.8f);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray rayGun = new Ray(controlCamera.position, controlCamera.forward);
            int targetMask = 1 << LayerMask.NameToLayer("Enemy") | 1 << LayerMask.NameToLayer("Terrain");

            RaycastHit rh = new RaycastHit();
            bool bHit = Physics.Raycast(rayGun,out rh, 500.0f, targetMask);

            if (bHit)
            {
                //Debug.Log(rh.collider.name);
                //Debug.Log(rh.point);
                if (rh.collider.tag == "enemy")
                {
                    Myenemy ey = rh.collider.gameObject.GetComponent<Myenemy>();
                    Debug.Log(ey);
                    if (ey == null)
                    {
                        Debug.Log(ey);
                    }
                    else
                    {
                        ey.Damage(30.0f);
                        Debug.Log(ey);
                    }

                }

                //Destroy(rh.collider.gameObject);
            }
        }

    }
}
