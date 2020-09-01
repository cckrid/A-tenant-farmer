using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.01f; // 앞뒤 움직임의 속도
    public float rotateSpeedA = 150.0f; // 좌우 회전 속도
    public float rotateSpeedB = 150.0f; // 좌우 회전 속도
    
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디

    private void Start()
    {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate()
    {
        // 회전 실행
        Rotate();
        // 움직임 실행
        Move();        

        // 입력값에 따라 애니메이터의 Move 파라미터 값을 변경
        playerAnimator.SetFloat("Move", playerInput.moveX);
        playerAnimator.SetFloat("Move", playerInput.moveY);

        

    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {
       
        // 상대적으로 이동할 거리 계산
        if (Input.GetButton("Vertical"))
        {
            playerAnimator.SetBool("isWalk", true);
            Vector3 moveDistance =
            playerInput.moveY * transform.forward * moveSpeed * Time.deltaTime;

            playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
            if (Input.GetButton("Horizontal"))
            {
                playerAnimator.SetBool("isWalk", true);
               // Vector3 moveDistance2 =
                 //playerInput.moveX * transform.right * moveSpeed * Time.deltaTime;
                // 상대적으로 회전할 수치 계산
                float turn =
                playerInput.rotateB * rotateSpeedB * Time.deltaTime;
                // 리지드바디를 통해 게임 오브젝트 회전 변경
                playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);

                //playerRigidbody.MovePosition(playerRigidbody.position + moveDistance2);
            }
        }
        else
        {
            

            if (Input.GetButton("Horizontal"))
            {
                playerAnimator.SetBool("isWalk", true);
                Vector3 moveDistance =
                 playerInput.moveX * transform.right * moveSpeed * Time.deltaTime;
                // 상대적으로 회전할 수치 계산
                float turn =
                playerInput.rotateB * rotateSpeedB * Time.deltaTime;
                // 리지드바디를 통해 게임 오브젝트 회전 변경
                playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);

                playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
            }
            else
            {
                playerAnimator.SetBool("isWalk", false);
            }
        }


        
        
        
        // 리지드바디를 통해 게임 오브젝트 위치 변경

    }


    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        
            // 상대적으로 회전할 수치 계산
            float turn =
            playerInput.rotateA * rotateSpeedA * Time.deltaTime;
            // 리지드바디를 통해 게임 오브젝트 회전 변경
            playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
        
    }
}