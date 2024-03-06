using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine. UI;

public class MouseHandler_3th : MonoBehaviour
{
    /// <summary>
    /// 드래그 버튼을 누르고 드래그를 하게 되면 핸들링 모드로 진입
    /// 핸들링 모드에서 특정 위치에서 마우스 좌클릭을 하고 드래그 하면 리스트에 있는 애들 복사하기
    /// </summary>
    public static MouseHandler_3th instance;
    public MouseHandler_3th mouseHandler;

    public float blinkInterval = 0.3f; // 깜빡이는 간격

    [SerializeField]
    GameObject dragSquare; // 프리팹

    GameObject square;

    Vector3 startPos, nowPos, deltaPos;
    float deltaX, deltaY;

    public  bool mouseActive; // true 일 때만 영역 그리게 하기
    public bool HandlingMode;           // DragSquare 이동 중일 때
    public bool SuperHandlingMode;      // 드래그 할 때 마우스 과속 안전장치

    public DragMode dragmode;
    public FreeDraw. Drawable drawable;
    public GameObject Parentobj;
    public List<GameObject> HandlingObj;
    public List<GameObject> SavingObj;
    public List<GameObject> copiedObjects = new List<GameObject> ( );

    public Vector3 MinusPosition;
    float distance = 10;


    private void Awake ( )
    {
        // 싱글톤 인스턴스 설정
        if ( instance == null )
        {
            instance = this;
        }
        else
        {
        }

    }
    void Update ( )
    {
        if ( mouseActive == true )
        {
            if(!HandlingMode)
            {
                if ( Input. GetMouseButtonDown ( 0 ) ) // 눌렀을 때 영역 그리기 시작
                {
                    Destroy ( square );

                    startPos = Camera. main. ScreenToWorldPoint ( new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , Camera. main. transform. position. z * -1 ) );
                    square = Instantiate ( dragSquare , new Vector3 ( 0 , 0 , 0 ) , Quaternion. identity );
                    SetOrigin ( );

                }

                if ( Input. GetMouseButton ( 0 )&&!SuperHandlingMode ) // 드래그 중
                {
                    nowPos = Camera. main. ScreenToWorldPoint ( new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , Camera. main. transform. position. z * -1 ) );
                    deltaX = Mathf. Abs ( nowPos. x - startPos. x );
                    deltaY = Mathf. Abs ( nowPos. y - startPos. y );
                    deltaPos = startPos + ( nowPos - startPos ) / 2;
                    square. transform. position = deltaPos;

                    
                    
                   

                    square. transform. localScale = new Vector3 ( deltaX , deltaY , 0 );
                }

                if ( Input. GetMouseButtonUp ( 0 ) )
                {
                    // SavingObj에 HandlingObj의 모든 오브젝트를 추가합니다.
                    SavingObj. AddRange ( HandlingObj );
                    HandlingObj. Clear ( );

                    // SavingObj에 오브젝트가 있는지 확인하여 조건에 따라 square를 유지하거나 삭제합니다.
                    if ( SavingObj. Count > 0 )
                    {

                    }
                    else
                    {
                        // SavingObj에 오브젝트가 없는 경우 square를 삭제합니다.
                        Destroy ( square );
                    }
                }
            }
            else // handling 모드 일 때
            {
                if( Input. GetMouseButtonDown ( 0 ) )
                {

                    Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
                    Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );
                    // 마우스 위치를 잡아내고 변환
                    MinusPosition = this. transform. position - mousePosition1;

                    if ( copiedObjects. Count == 0 )
                    {
                        foreach ( GameObject obj in SavingObj )
                        {
                            // 각 요소를 복사합니다.
                            GameObject copiedObj = Instantiate ( obj , obj. transform. position , obj. transform. rotation );
                            copiedObj. name = obj. name;

                            // "DragSquare(Clone)" 오브젝트를 찾아서 부모로 설정합니다.
                            GameObject dragSquareObject = GameObject. Find ( "DragSquare(Clone)" );
                            if ( dragSquareObject != null )
                            {
                                copiedObj. transform. SetParent ( dragSquareObject. transform );
                            }

                            copiedObjects. Add ( copiedObj );
                        }
                    }
                }
                
            }

        }
        else
        {
            SetOrigin ( );
        }

    }

    public void MouseHandleToggle ( )
    {
        if(mouseActive)
        {
            MouseHandleOff ( );
        }
        else
        {
            MouseHandleOn ( ); 
        }
    }
    public void MouseHandleOn ( )
    {
        mouseActive = true;
        dragmode. isDragMode = false;
        drawable. isPenMode = false;
    }

    public void MouseHandleOff ( )
    {
        mouseActive = false;
        dragmode. isDragMode = true;
        drawable. isPenMode = true;
    }

    void OnTriggerEnter ( Collider other )
    {
       
    }

    void OnTriggerExit ( Collider other )
    {
        
    }  

    public void SetOrigin()
    {
        foreach ( GameObject obj in SavingObj )
        {
            SpriteRenderer spriteRenderer = obj. GetComponent<SpriteRenderer> ( );
            if ( spriteRenderer != null )
            {
                Color color = spriteRenderer. color;
                color. a = 1f; // 투명도를 다시 원래대로 설정
                spriteRenderer. color = color;
            }
        }
        SavingObj. Clear ( );
        copiedObjects. Clear ( );
    }

    public void SetHome ( )
    {
        Destroy ( dragSquare );
    }
  }