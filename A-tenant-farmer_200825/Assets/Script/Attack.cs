using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;    
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트    
    public int plusNum= 0;
    public int AttackNum = 0;
    

    void Start()
    {
        anim = GetComponent<Animator>();        
        
    }
    private void Update()
    {
        OnClick();
        cases();
    }


    public void OnClick()
    {
            if (Input.GetButtonDown("Fire1"))
            {                
                plusNum = AttackNum + 1;            
                Debug.Log("클릭공격 : " + plusNum);

            }
        else
        {
            anim.SetBool("isAttack", false);            
            anim.SetFloat("AttackCount", 0);            

        }

        AttackNum = plusNum;

    }

    public void cases()
    {
        switch (AttackNum)
        {
            case 1 :
                
                    anim.SetBool("isAttack", true);
                    anim.SetFloat("AttackCount", 1);
                if (anim.GetBool("isWalk") == true)
                {
                    anim.SetBool("isAttack", false);
                    anim.SetFloat("AttackCount", 0);
                    plusNum = 0;
                    AttackNum = 0;
                }
                break;
            case 2 :                
                    anim.SetBool("isAttack", true);
                    anim.SetFloat("AttackCount", 2);
                if (anim.GetBool("isWalk") == true)
                {
                    anim.SetBool("isAttack", false);
                    anim.SetFloat("AttackCount", 0);
                    plusNum = 0;
                    AttackNum = 0;
                }
                break;
                
            case 3 :                
                    anim.SetBool("isAttack", true);
                    anim.SetFloat("AttackCount", 3);
                if (Input.GetButtonUp("Fire1"))
                {
                    anim.SetBool("isAttack", false);
                    anim.SetFloat("AttackCount", 0);
                    plusNum = 0;
                    AttackNum = 0;
                }
                    break;                   
        }
    }
}
