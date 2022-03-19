using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class SkeletonAI : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject Player;
    public Animator anim;
    private float updateTime = 0;

    private PlayerData data;
    private bool isAttacking = false;
    public float minDamage;
    public float maxDamage;
    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        data = FindObjectOfType<PlayerData>();
        //Invoke("FindTarget", 2);
    }

    public void Update()
    {
        updateTime += Time.deltaTime;
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        if (distance <= 4)
        {
            if (!isAttacking)
            {
                StartCoroutine((Attack()));
            }
            
            //anim.SetBool("Attack", true);
            //anim.SetBool("Walk", false);
            //attack
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
            isAttacking = false;
            //walk
        }
    }

    IEnumerator Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
            yield return new WaitForSeconds(3f);
            data.TakeDamage(Random.Range(minDamage,maxDamage));
            isAttacking = false;
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
