using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion1 : MonoBehaviour
{
    //public GameObject plane;
    public static int count=0;
    public float speed;
    private Rigidbody rd;
    public float fireRate;
    private float nextFire;
    private bool doubleJump = true;

    public int getCount()
    {
        return count;
    }
    private void Start()
    {
        rd = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 moment = new Vector3(moveH, 0.0f, moveV);
        rd.AddForce(moment * speed);
        if (rd.position.y <= 0.5f)
        {
            rd.position = Vector3.one;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            if (doubleJump)
            {
                fireRate -= 1.5f;
                doubleJump = false;
            }
            else
            {
                fireRate += 1.5f;
                doubleJump = true;
            }
            nextFire = Time.time + fireRate ;
            rd.AddForce(new Vector3(0, 300.0f, 0));
            
        }
        if (Input.GetKey(KeyCode.E))
        {
            rd.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.K))
        {
            rd.transform.localScale += Vector3.one;
        }
        else if(Input.GetKey(KeyCode.J))
        {
            rd.transform.localScale = Vector3.one;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            //Destroy(other.gameObject);
            //GenerateMap();
        }
    }
    

}
