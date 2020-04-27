using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera_Move : MonoBehaviour
{
    public GameObject target;
    public GameObject obj;
    public float CameraZ = -10;


    public float offset_x = 1.0f;
    public float offset_y = 5.0f;
    public float offset_z = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        //Vector3 cameraMove = new Vector3((transform.position.x - obj.transform.position.x)*Mathf.Cos(obj.transform.rotation.y) - (transform.position.z-obj.transform.position.z)*Mathf.Sin(obj.transform.rotation.y) + obj.transform.position.x, obj.transform.position.y
        //    , (transform.position.x-obj.transform.position.x)*Mathf.Sin(obj.transform.rotation.y)+(transform.position.z-obj.transform.position.z)*Mathf.Cos(obj.transform.rotation.y)+obj.transform.position.z);


        //if (obj.transform.rotation.y >= 0 && obj.transform.rotation.y < 90)
        //{
        //    Vector3 TargetPos =
        //       new Vector3(-Mathf.Sin(obj.transform.rotation.y) * 10, 3, -Mathf.Cos(obj.transform.rotation.y) * 10);
        //    transform.position = TargetPos;
        //}
        //if (obj.transform.rotation.y >= 90 && obj.transform.rotation.y < 180)
        //{
        //    Vector3 TargetPos =
        //       new Vector3(-Mathf.Sin(obj.transform.rotation.y) * 10, 3, Mathf.Cos(obj.transform.rotation.y) * 10);
        //    transform.position = TargetPos;
        //}
        //if (obj.transform.rotation.y >= -180 && obj.transform.rotation.y < -90)
        //{
        //    Vector3 TargetPos =
        //       new Vector3(Mathf.Sin(obj.transform.rotation.y) * 10, 3, -Mathf.Cos(obj.transform.rotation.y) * 10);
        //    transform.position = TargetPos;
        //}
        //if (obj.transform.rotation.y >= -90 && obj.transform.rotation.y < 0)
        //{
        //    Vector3 TargetPos =
        //       new Vector3(Mathf.Sin(obj.transform.rotation.y) * 10, 3, Mathf.Cos(obj.transform.rotation.y) * 10);
        //    transform.position = TargetPos;
        //}

        float keyHorizontal = Input.GetAxis("Horizontal");



        //Vector3 TargetPos = new Vector3(obj.transform.position.x + offset_x, obj.transform.position.y + offset_y, obj.transform.position.z + offset_z);

        transform.RotateAround(obj.transform.position, Vector3.up, keyHorizontal * Time.deltaTime * 50.0f);

        float z = 0.0f;
        float x = 0.0f;
        if(obj.transform.rotation.y - transform.rotation.y >= 0)
        {

            z = offset_x * Mathf.Sin(obj.transform.rotation.y - transform.rotation.y) + offset_z * Mathf.Cos(obj.transform.rotation.y - transform.rotation.y);
            x = offset_x * Mathf.Cos(obj.transform.rotation.y - transform.rotation.y) - offset_z * Mathf.Sin(obj.transform.rotation.y - transform.rotation.y);

        }
        if (obj.transform.rotation.y - transform.rotation.y < 0)
        {

            z = -offset_x * Mathf.Sin(obj.transform.rotation.y - transform.rotation.y) + offset_z * Mathf.Cos(obj.transform.rotation.y - transform.rotation.y);
            x = -offset_x * Mathf.Cos(obj.transform.rotation.y - transform.rotation.y) - offset_z * Mathf.Sin(obj.transform.rotation.y - transform.rotation.y);

        }



        transform.position = obj.transform.position + new Vector3(x, offset_y, z);

        offset_x = x;
        offset_z = z;



        //transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 2f);

        //transform.position = TargetPos;

        //transform.Rotate(Vector3.up * 50.0f * Time.deltaTime * keyHorizontal);

        //transform.position = cameraMove;






        //if (transform.rotation != obj.transform.rotation)
        //{
        //    transform.Rotate(obj.transform.rotation.x, obj.transform.rotation.y, obj.transform.rotation.z);
        //}
    }

    private void LateUpdate()
    {
    }

}
