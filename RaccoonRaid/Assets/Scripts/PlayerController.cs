using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public GameObject trash;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.rotation.eulerAngles;

        if (Input.GetKey(KeyCode.W))
        {
            temp.y = 0.0f;
            transform.rotation = Quaternion.Euler(temp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            temp.y = 90.0f;
            transform.rotation = Quaternion.Euler(temp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            temp.y = 45.0f;
            transform.rotation = Quaternion.Euler(temp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            temp.y = 180.0f;
            transform.rotation = Quaternion.Euler(temp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            temp.y = 135.0f;
            transform.rotation = Quaternion.Euler(temp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            temp.y = 270.0f;
            transform.rotation = Quaternion.Euler(temp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            temp.y = 225.0f;
            transform.rotation = Quaternion.Euler(temp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            temp.y = 315.0f;
            transform.rotation = Quaternion.Euler(temp);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == trash)
        {
            Object.Destroy(other.gameObject);
            SceneManager.LoadScene(3);
        }
    }
}
