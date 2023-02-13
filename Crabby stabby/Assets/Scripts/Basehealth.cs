using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basehealth : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Game over
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
