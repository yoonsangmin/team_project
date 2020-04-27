using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    public GameObject Player; //플레이어 오브젝트 넣을 곳
    public float playerSpeed;

    public Transform Stick; //조이스틱


    private Vector3 StickFirstPos;
    private Vector3 JoyVec;

    public Vector3 JoyRe;


    private float Radius;  //조이스틱 배경 반지름

    private bool MoveFlag; //??

    private float acceleration;



    // Start is called before the first frame update
    void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f; //오브젝트 반지름 구하기
        StickFirstPos = Stick.transform.position; //조이스틱 처음위치 초기화

        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;


        MoveFlag = false; // ??

        playerSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        //캐릭터 이동
        if (MoveFlag && JoyVec.y > 0.3f)
            Player.transform.Translate(Vector3.forward * Time.deltaTime * acceleration * playerSpeed, Space.Self);
        if (MoveFlag && JoyVec.y < -0.7f)
            Player.transform.Translate(Vector3.back * Time.deltaTime * acceleration * playerSpeed / 2, Space.Self);
        if (MoveFlag && JoyVec.x > 0.4f)
            Player.transform.Rotate(0, 1f, 0);
        if (MoveFlag && JoyVec.x < -0.4f)
            Player.transform.Rotate(0, -1f, 0);

    }
    // 드래그
    public void Drag(BaseEventData _Data)
    {
        MoveFlag = true;//캐릭터를 이동하게 한다

        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래) 방향 벡터
        JoyVec = (Pos - StickFirstPos).normalized;



        JoyRe = JoyVec;
        // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        acceleration = Vector3.Distance(Pos, StickFirstPos);

        // 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는곳으로 이동. 
        if (Dis < Radius)
            Stick.position = StickFirstPos + JoyVec * Dis;
        // 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
        else
            Stick.position = StickFirstPos + JoyVec * Radius;

        //Player.transform.eulerAngles = new Vector3(0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg, 0); //캐릭터가 보는 방향
    }

    // 드래그 끝.
    public void DragEnd()
    {
        Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        JoyVec = JoyRe;          // 방향을 0으로.
        
        
        Debug.Log("asadsasdas");

        MoveFlag = false;
    }

}
