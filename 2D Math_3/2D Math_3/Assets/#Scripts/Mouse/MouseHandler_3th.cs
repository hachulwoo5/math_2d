using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine. UI;

public class MouseHandler_3th : MonoBehaviour
{
    /// <summary>
    /// �巡�� ��ư�� ������ �巡�׸� �ϰ� �Ǹ� �ڵ鸵 ���� ����
    /// �ڵ鸵 ��忡�� Ư�� ��ġ���� ���콺 ��Ŭ���� �ϰ� �巡�� �ϸ� ����Ʈ�� �ִ� �ֵ� �����ϱ�
    /// </summary>
    public static MouseHandler_3th instance;
    public MouseHandler_3th mouseHandler;

    public float blinkInterval = 0.3f; // �����̴� ����

    [SerializeField]
    GameObject dragSquare; // ������

    GameObject square;

    Vector3 startPos, nowPos, deltaPos;
    float deltaX, deltaY;

    public  bool mouseActive; // true �� ���� ���� �׸��� �ϱ�
    public bool HandlingMode;           // DragSquare �̵� ���� ��
    public bool SuperHandlingMode;      // �巡�� �� �� ���콺 ���� ������ġ

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
        // �̱��� �ν��Ͻ� ����
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
                if ( Input. GetMouseButtonDown ( 0 ) ) // ������ �� ���� �׸��� ����
                {
                    Destroy ( square );

                    startPos = Camera. main. ScreenToWorldPoint ( new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , Camera. main. transform. position. z * -1 ) );
                    square = Instantiate ( dragSquare , new Vector3 ( 0 , 0 , 0 ) , Quaternion. identity );
                    SetOrigin ( );

                }

                if ( Input. GetMouseButton ( 0 )&&!SuperHandlingMode ) // �巡�� ��
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
                    // SavingObj�� HandlingObj�� ��� ������Ʈ�� �߰��մϴ�.
                    SavingObj. AddRange ( HandlingObj );
                    HandlingObj. Clear ( );

                    // SavingObj�� ������Ʈ�� �ִ��� Ȯ���Ͽ� ���ǿ� ���� square�� �����ϰų� �����մϴ�.
                    if ( SavingObj. Count > 0 )
                    {

                    }
                    else
                    {
                        // SavingObj�� ������Ʈ�� ���� ��� square�� �����մϴ�.
                        Destroy ( square );
                    }
                }
            }
            else // handling ��� �� ��
            {
                if( Input. GetMouseButtonDown ( 0 ) )
                {

                    Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
                    Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );
                    // ���콺 ��ġ�� ��Ƴ��� ��ȯ
                    MinusPosition = this. transform. position - mousePosition1;

                    if ( copiedObjects. Count == 0 )
                    {
                        foreach ( GameObject obj in SavingObj )
                        {
                            // �� ��Ҹ� �����մϴ�.
                            GameObject copiedObj = Instantiate ( obj , obj. transform. position , obj. transform. rotation );
                            copiedObj. name = obj. name;

                            // "DragSquare(Clone)" ������Ʈ�� ã�Ƽ� �θ�� �����մϴ�.
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
                color. a = 1f; // ������ �ٽ� ������� ����
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