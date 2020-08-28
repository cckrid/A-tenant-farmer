using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    public int atkNum = 0;
    public int plusNum;    

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        onClick();
        cases();
    }

        public void onClick()
        {
        if (Input.GetButtonDown("Fire1"))
        {
            plusNum += 1;
            Debug.Log("클릭공격");
        }        
        
        
        }

    public void cases()
    {
        switch (atkNum)
        {
            case 1 :
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetBool("isAttack", true);
                }                
                break;
            case 2 :
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isAttack2", true);
                }                
                break;
            case 3 :
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetBool("isAttack2", false);
                    anim.SetBool("isAttack3", true);
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    anim.SetBool("isAttack3", false);                    
                    atkNum = 0;
                    plusNum = 0;
                }
                break;
        }
    }
}
