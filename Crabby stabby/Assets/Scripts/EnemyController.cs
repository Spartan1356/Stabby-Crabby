using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //set the values in the inspector
    public Transform target; //drag and stop player object in the inspector
    public float witanonymousn_range;
    public float speed;
    public int attackTimer;
    public int cooldown = 1000;
    public int Damage;

    public void Update()
    {
        attackTimer--;
        //get the distance between the player and enemy (t$$anonymous$$s object)
        float dist = Vector3.Distance(target.position, transform.position);
        //check if it is wit$$anonymous$$n the range you set
        if (dist <= witanonymousn_range){
            //move to target(player) 
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        if (dist <= 0.1 && attackTimer <= 0)
        {
            FindObjectOfType<Basehealth>().health -= Damage;
            attackTimer = cooldown;
        }
        //else, if it is not in rage, it will not follow player
    }
}
