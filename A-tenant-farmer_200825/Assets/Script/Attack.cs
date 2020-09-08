using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    public GameObject enemy;
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트       
    public int plusNum= 0;
    public int AttackNum = 0;
    private MonsterControll monster;
    private bool Hit;
    private bool isDead;
    public enum PlayerState { idle, walk, attack1, attack2, attack3, dead, damaged };
    public PlayerState playState = PlayerState.idle;

    void Start()
    {
        anim = GetComponent<Animator>();        
        
    }
    private void Update()
    {
        OnClick();
        cases();
        PlayState();
    }


    public void OnClick()
    {
            if (Input.GetButtonDown("Fire1"))
            {                
                plusNum = AttackNum + 1;            
                Debug.Log("클릭공격 : " + plusNum);
                Debug.Log("어택카운트 : " + anim.GetBool("AttackCount"));

            Hit = true;

            }
        else if (Input.GetButtonUp("Fire1") && anim.GetFloat("AttackCount")==3)
        {
            anim.SetBool("isAttack", false);
            anim.SetFloat("AttackCount", 0);
            Hit = false;

        }
        AttackNum = plusNum;

    }

    public void cases()
    {
        switch (AttackNum)
        {
            case 1 :
                playState = PlayerState.attack1;                
                break;
            case 2 :                
                
                playState = PlayerState.attack2;
                break;
                
            case 3 :                
                playState = PlayerState.attack3;
                break;
            default:
                
                    anim.SetBool("isAttack", false);
                    anim.SetFloat("AttackCount", 0);
                //plusNum = 0;
                //AttackNum = 0;      
                break;
        }
    }    

    public void PlayState()
    {        
                switch (playState)
                {
                    case PlayerState.attack1:
                        anim.SetBool("isAttack", true);
                        anim.SetFloat("AttackCount", 1);                        
                        break;
                    case PlayerState.attack2:
                
                    anim.SetBool("isAttack", true);
                    anim.SetFloat("AttackCount", 2);                                
                        break;
                    case PlayerState.attack3:
                
                    anim.SetBool("isAttack", true);
                    anim.SetFloat("AttackCount", 3);
                    if(anim.GetBool("isWalk") == true)                    
                    {
                    anim.SetBool("isAttack", false);
                    anim.SetFloat("AttackCount", 0);
                    AttackNum = 0;
                    plusNum = 0;
                    }

                    break;
                }
            
        
    }

    private void OnTriggerEnter(Collider other)
    {        
            MonsterControll monster = other.gameObject.GetComponent<MonsterControll>();
            if(monster != null)
            {
                Debug.Log(Hit);
                if(Hit == true)
                {
                    monster.TakeDamage(10);
                    Debug.Log("칼");
                    //Hit = false;
                }
                                
            }        
       
    }
}
