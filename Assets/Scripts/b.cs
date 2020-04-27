using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b : MonoBehaviour
{
    bool isempty;
    bool zDown;
    bool handgoal;

    // Start is called before the first frame update
    void Start()
    {
        isempty = true;
        zDown = false;
        handgoal = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHand();


        if (Input.GetKeyDown(KeyCode.X) && isempty == false)
        {
            //Destroy(transform.GetChild(0).gameObject);
            transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            transform.GetChild(0).parent = null;
            transform.position = transform.parent.GetChild(2).transform.position;
            isempty = true;
        }
        
    }

    void MoveHand()
    {
        if(Input.GetKeyDown(KeyCode.Z) && zDown == false && isempty == true)
        {
            zDown = true;
            handgoal = false;
        }

        if (Vector3.Distance(transform.position, transform.parent.position) <= 5f && zDown == true && handgoal == false && isempty == true)
            transform.Translate(Vector3.forward * 0.1f);
        else if(Vector3.Distance(transform.position, transform.parent.position) > 5f)
        {
            transform.position = transform.parent.GetChild(2).transform.position;
            handgoal = true;
            zDown = false;
        }
        //if(Vector3.Distance(transform.position, transform.parent.position) < 5f)
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash" && isempty == true && zDown == true)
        {
            //Destroy(other.gameObject, 0);
            other.transform.parent = gameObject.transform;
            
            other.GetComponent<Rigidbody>().useGravity = false;
            transform.position = transform.parent.GetChild(2).transform.position;

            zDown = false;
            isempty = false;
        }
    }
}
