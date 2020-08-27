using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    public int atkNum;
    bool isAtk = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        ComboAtk();
    }

    public void PlayAnimation(int atkNum)
    {
        anim.SetFloat("Blend", atkNum);
        anim.SetTrigger("Atk");
    }   

    public void ComboAtk()
    {
        
        if (Input.GetButton("Fire1"))
        {
            
            PlayAnimation(atkNum++);
            if (atkNum > 3)
            {
                atkNum = 0;
                isAtk = false;
            }
        }
        else
        {
            PlayAnimation(0);
            isAtk = false;
            atkNum = 0;
        }
    }
    public void Update()
    {
        if (Input.GetButton("Fire1") )
        {            
            isAtk = true;
            Debug.Log("클릭공격");
        }
    }
}
