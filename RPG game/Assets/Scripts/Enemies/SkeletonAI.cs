using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject Player;
    public Animator anim;
    private float updateTime = 0;
    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        //Invoke("FindTarget", 2);
    }

    public void Update()
    {
        updateTime += Time.deltaTime;
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        if (distance <= 4)
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
            //attack
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
            //walk
        }
    }
    private void LateUpdate()
    {
        transform.LookAt(Player.transform);
        if (updateTime > 2)
        {
            anim.SetBool("Walk", true);
            nav.destination = Player.transform.position;
            updateTime = 0;
        }
    }


}
