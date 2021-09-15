using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public GameObject player;
    float speed;
    public bool attack;
    public bool isdead;
    Animator anm;
    public float attackRange=1f;
    public int damage=5;
    public float attackTime;
    float attackDelay;
    // Start is called before the first frame update
    void Start()
    {
        attack = false;
        isdead = false;
        player = GameObject.FindGameObjectWithTag("PlayerPos");
        speed = Random.Range(8, 10);
        anm = gameObject.GetComponent<Animator>();
    }
    void UpdateAttackTime()
    {
        attackTime = Time.time;
        attackDelay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        anm.SetBool("isAttack", attack);
        anm.SetBool("isDead", isdead);
        anm.SetFloat("speed", speed);

        if (player == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, player.transform.position)>attackRange)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            attack = false;
        }
        else
        {
            attack = true;
            
        }
        if (attack&&Time.time>attackTime+attackDelay)
        {
            Attack();
        }
        if (isdead)
        {
            attack = false;
            speed/=2 ;
            StartCoroutine(Dead());
        }
    }
    void Attack()
    {
        PlayerMove mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        mainPlayer.GetDamaged(damage);
        UpdateAttackTime();
    }
    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
