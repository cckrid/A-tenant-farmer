using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;    // 추적할 타겟 오브젝트의 transform
    public float dist = 10.0f;  // 카메라와의 일정거리
    public float height = 5.0f; // 카메라의 높이 설정
    public float smoothRotate = 5.0f;   // 부드러운 회전을 위한 변수

    private Transform tr;   // 카메라 자신의 Transform 변수


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 부드러운 회전을 위해 Mathf.LerpAngle
        float currYangle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y,
            smoothRotate * Time.deltaTime);

        // 오일러 타입을 쿼터니언으로 바꾸기
        Quaternion rot = Quaternion.Euler(0, currYangle, 0);

        // 카메라 위치를 타겟 회전작도만큼 회전 후 dist만큼 띄우고, 높이를 올리기
        tr.position = target.position - (rot * Vector3.forward * dist)
            + (Vector3.up * height);

        // 타겟을 바라보게 하기
        tr.LookAt(target);
    }
}
