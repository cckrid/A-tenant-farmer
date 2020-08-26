using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int talkCnt = 12;       // 대화의 총 갯수를 설정해줍니다.
    int strCnt = 0;         // 이 변수가 하나씩 커져가면서 대화를 진행합니다.
    string[] talk;          // 대화 내용을 저장할 공간입니다.
    public Text txt;        // Text 오브젝트에 접근하기
    public Image[] charactors;
    public Image showText;
    public GameObject ask;
    int[] showCnt;
    // Use this for initialization
    void Start()
    {
        strCnt = 0;
        talk = new string[talkCnt]; // 대화 저장 공간을 초기화해줍니다.
        showCnt = new int[talkCnt];
        txt = GameObject.Find("TalkBox").transform.Find("Text").GetComponent<Text>();
        // 캔버스 오브젝트 아래 자식 오브젝트로 있는 Text를 호출합니다.
        showText = GameObject.Find("Talk").transform.Find("TalkBox").GetComponent<Image>();
        // 캔버스 오브젝트 아래 자식 오브젝트로 있는 talkScreen을 호출합니다.

        charactors = new Image[2];  // 이미지 호출할 배열을 만듭니다.
        charactors[0] = GameObject.Find("Talk").transform.Find("Player").GetComponent<Image>();  // 주인공
        charactors[1] = GameObject.Find("Talk").transform.Find("sisnomal").GetComponent<Image>();  // 동생        
        // 각 배열에 오브젝트를 연결합니다.
        // 등장 인물이 많다면 여러개를 생성해야 합니다.

        initialized();      // 대화를 설정하는 함수입니다.

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))

        { 
            if (strCnt<11)
            strCnt+=1;
           

            // '엔터'나 '스페이스바'를 누르면 카운트가 올라갑니다.
        }
        
                
        showAll();  // 화면에 나오게 하는 함수로 연ㅋ결ㅋ        
    }
    void showAll()
    {
        showText.gameObject.SetActive(true);
        
        for (int i = 0; i < 2; i++)      // 등장인물의 수만큼을 써줍니다. 여기는 3명이 등장합니다.
        {
            charactors[i].gameObject.SetActive(false);      // 모든 오브젝트를 비활성화합니다.(사람 이미지)            
            ask.gameObject.SetActive(false);
        }
        charactors[showCnt[strCnt]].gameObject.SetActive(true);
        // 캐릭터의 showCnt라는 배열의 숫자에 대한 오브젝트만을 활성화합니다.
        txt.text = talk[strCnt];
        // strCnt의 차례에 맞춰 대화를 출력합니다.
        
        if (strCnt >= 11)
           askshow();
    }

    void initialized()
    {
        // 대화 내용을 하나하나 추가합니다.
        talk[0] = "?? : 안녕? 만나서 반가워!";
        talk[1] = "?? : 나는 타니마을에 사는 소작농 풀(fool)이야!";
        talk[2] = "풀 : 농사를 하면서 동생과 살고 있...";
        talk[3] = "?? : 오빠!!!!";
        talk[4] = "풀 : 아 왜! 지금 설명하는거 안보여? 보즈?";
        talk[5] = "보즈 : 응 알지. ";
        talk[6] = "보즈 : 그러니까, 나 케이크 사줘. ";
        talk[7] = "풀 : 이런 시골에 케이크를 어디서 판다고 그래! 보즈!";
        talk[8] = "보즈 : 휴즈 왕국에 제과점에 가면 되지.";
        talk[9] = "풀 : 제정신이야? 거기 까지 가는건 너무 위험해!";
        talk[10] = "풀 : 가는 길에 몬스터가 잔뜩 있다고!";
        talk[11] = "보즈 : 응 아니야. 사 와.";

        ////////////////////////////////////////

        // 캐릭터의 등장 순서를 설정합니다.
        showCnt[0] = 0;     // 주인공
        showCnt[1] = 0;     // 주인공
        showCnt[2] = 0;     // 주인공
        showCnt[3] = 1;     // 동생
        showCnt[4] = 0;     // 주인공
        showCnt[5] = 1;     // 동생
        showCnt[6] = 1;     // 동생
        showCnt[7] = 0;     // 주인공
        showCnt[8] = 1;     // 동생
        showCnt[9] = 0;     // 주인공
        showCnt[10] = 0;     // 주인공
        showCnt[11] = 1;     // 동생
        // 순서로 이루어지는 대화
    }

    void askshow()
    {
        
        //ask[0].gameObject.SetActive(true);
        ask.gameObject.SetActive(true);
    }
   // void
}
