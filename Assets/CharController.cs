using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed;
    public float speedRotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, Input.GetAxisRaw("Mouse X")) * -Time.deltaTime * speedRotate);
    }
}
