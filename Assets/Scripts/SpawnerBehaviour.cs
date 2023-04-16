using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public GameObject obstacle;
    public float lowerCooldown;
    public float upperCooldown;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(lowerCooldown, upperCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(cooldown <= 0)
        {
            Instantiate(obstacle, this.transform.localPosition, Quaternion.identity);   
            cooldown = Random.Range(lowerCooldown, upperCooldown);
        }
        else 
        {
            cooldown -= 1;
        }
             
    }
}
