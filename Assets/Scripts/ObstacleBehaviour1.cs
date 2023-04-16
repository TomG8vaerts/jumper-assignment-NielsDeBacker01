using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public float speed;
    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition -= new Vector3(speed,0,0);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Wall")
        {
             Destroy(this.gameObject);
        }
    }
}
