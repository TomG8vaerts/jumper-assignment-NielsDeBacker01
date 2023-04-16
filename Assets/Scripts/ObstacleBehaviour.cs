using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public float speed;
    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition -= new Vector3(0,0,speed);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Wall")
        {
             Destroy(this.gameObject);
        }
    }
}
