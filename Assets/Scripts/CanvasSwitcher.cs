using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvas1; // Canvas1
    public GameObject canvas2; // Canvas2
    public GameObject canvas3;
    public GameObject button1;
    public GameObject button2;
    public float activationDistance = 3.0f; // Canvas1과 플레이어 간의 거리

    private Transform player; // 플레이어의 Transform
    private bool canvas2Activated = false; // Canvas2가 이미 활성화되었는지 여부
    private bool canvas3Activated = false;
    private bool button1Activated = false;
    private bool button2Activated = false;

    void Start()
    {
        // 초기 설정: Canvas1 활성화, Canvas2 비활성화
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);


        // 플레이어의 Transform 가져오기
        player = Camera.main.transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, canvas1.transform.position);

        // 플레이어가 Canvas1에 가까워지면 Canvas2 활성화
        if (distance <= activationDistance && !canvas2Activated)
        {
            ActivateCanvas2();
        }
        if (distance <= activationDistance && !canvas3Activated)
        {
            ActivateCanvas3();
        }
        if (distance <= activationDistance && !button1Activated)
        {
            ActivateButton1();
        }
        if (distance <= activationDistance && !button2Activated)
        {
            ActivateButton2();
        }
    }

    // Canvas2 활성화 메서드
    private void ActivateCanvas2()
    {
        canvas2.SetActive(true);
        canvas2Activated = true;
        Debug.Log("Canvas2 Activated");
    }

    private void ActivateCanvas3()
    {
        canvas3.SetActive(true);
        canvas3Activated = true;
        Debug.Log("Canvas2 Activated");
    }

    private void ActivateButton1()
    {
        button1.SetActive(true);
        button1Activated = true;
        Debug.Log("Canvas2 Activated");
    }
    private void ActivateButton2()
    {
        button2.SetActive(true);
        button2Activated = true;
        Debug.Log("Canvas2 Activated");
    }
}


