using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterControll : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, dead, damaged};
    public CurrentState curState = CurrentState.idle;
    int time = 0;
    private Attack attack;
    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    private Animator _animator;
    //private Animation animation;    


    public float traceDist = 5.0f;
    public float attackDist = 2.0f;
    public float Hp = 30.0f;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        _animator = this.gameObject.GetComponent<Animator>();

        // 추적 대상의 위치를 설정하면 바로 추적 시작
        // nvAgent.destination = playerTransform.position;

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    public void TakeDamage(int damage)
    {
        /*
         * hp -= damage;
         * if(hp < 0)
         */
        Hp = Hp - damage;
        
        if(Hp <= 0)
        {
            _animator.SetBool("isDie", true);
            isDead = true;
            curState = CurrentState.dead;
            
            time += 1;
        }
                

    }

    IEnumerator CheckState()
    {
        while (!isDead)
        {
            while (!isDead)
            {
                yield return new WaitForSeconds(0.2f);

                float dist = Vector3.Distance(playerTransform.position, _transform.position);

                if (dist<=attackDist)
                {                  
                    curState = CurrentState.attack;
                }
                else if(dist <= traceDist)
                {                                        
                    curState = CurrentState.trace;
                }
                else
                {                                       
                    curState = CurrentState.idle;
                }
            }
        }
    }

    IEnumerator CheckStateForAction()
    {
        while (!isDead)
        {
            switch (curState)
            {
                case CurrentState.idle:
                    nvAgent.Stop();
                    _animator.SetBool("isWalk", false);
                    _animator.SetBool("isAttack", false);
                    _animator.SetBool("isDamaged", false);
                    break;
                case CurrentState.trace:
                    _animator.SetBool("isWalk", true);
                    nvAgent.destination = playerTransform.position;
                    nvAgent.Resume();
                    break;
                case CurrentState.attack:
                    _animator.SetBool("isAttack", true);                    
                    break;
                case CurrentState.damaged:
                    break;
                case CurrentState.dead:                    
                    if (time >= 5)
                    {
                        nvAgent.Stop();
                        gameObject.SetActive(false);                        
                    }
                    break;
            }

            yield return null;
        }
    }    
}
