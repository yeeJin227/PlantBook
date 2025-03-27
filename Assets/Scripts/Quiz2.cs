using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quiz2 : MonoBehaviour
{
    public Canvas canvas2;  // 현재 활성화된 캔버스 (버튼 2를 누르면 비활성화될 캔버스)
    public Canvas canvas3;  // 버튼 2가 눌렸을 때 활성화될 캔버스
    public Image image1;    // 버튼 1 또는 버튼 3이 눌렸을 때 활성화될 이미지
    public Image image2;    // 버튼 2를 눌렀을 때 3초 동안 활성화될 이미지

    // 각각의 버튼
    public Button button1;
    public Button button2;
    public Button button3;

    void Start()
    {
        // 버튼 클릭 이벤트 할당
        button1.onClick.AddListener(OnButton1Or3Click);
        button2.onClick.AddListener(OnButton2Click);
        button3.onClick.AddListener(OnButton1Or3Click);

        // 시작 시 이미지 비활성화
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
    }

    // 버튼 1과 3 클릭 처리 (Image1을 3초 동안 활성화)
    void OnButton1Or3Click()
    {
        // 코루틴 시작 (3초 후 이미지 비활성화)
        StartCoroutine(ShowImage1ForDuration(3.0f));
    }

    // 버튼 2 클릭 처리 (Image2를 3초 동안 활성화 후 Canvas3으로 전환)
    void OnButton2Click()
    {
        // 코루틴 시작 (Image2 3초 활성화 후 캔버스 전환)
        StartCoroutine(ShowImage2ThenSwitchCanvas(3.0f));
    }

    // Coroutine: Image1을 3초 동안 활성화했다가 비활성화하는 함수
    IEnumerator ShowImage1ForDuration(float duration)
    {
        // Image1 활성화
        image1.gameObject.SetActive(true);

        // 주어진 시간(예: 3초) 동안 대기
        yield return new WaitForSeconds(duration);

        // Image1 비활성화
        image1.gameObject.SetActive(false);
    }

    // Coroutine: Image2를 3초 동안 활성화한 후 Canvas3으로 전환하는 함수
    IEnumerator ShowImage2ThenSwitchCanvas(float duration)
    {
        // Image2 활성화
        image2.gameObject.SetActive(true);

        // 주어진 시간(예: 3초) 동안 대기
        yield return new WaitForSeconds(duration);

        // Image2 비활성화
        image2.gameObject.SetActive(false);

        // Canvas2 비활성화
        if (canvas2 != null)
            canvas2.gameObject.SetActive(false);

        // Canvas3 활성화
        if (canvas3 != null)
            canvas3.gameObject.SetActive(true);
    }
}
