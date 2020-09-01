using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEffect : MonoBehaviour
{
    private Animator anim;
    private PlayerInput playerInput;
    //private GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            gameObject.SetActive(true);
            Debug.Log("이펙트");
        }
        //else
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
