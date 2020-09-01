using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScean : MonoBehaviour
{

    // CharacterController가 다른 물체의 Collider와
    // 닿았을때 자동으로 호출되는 매서드 (반드시 충돌체가 있어야함)
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            SceneManager.LoadScene("BrightDay");
        }
    }
}
