using UnityEngine;
using UnityEngine.UI;

public class WaterSliderControllerTwo : MonoBehaviour
{
    public Image image1; // 첫 번째 이미지
    public Image image2; // 두 번째 이미지
    public Image image3; // 세 번째 이미지
    public Button nextButton; // 버튼

    private int clickCount = 0; // 버튼 클릭 횟수 추적

    private void Start()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        nextButton.onClick.AddListener(OnNextButtonClick);

        // 시작할 때 세 이미지를 비활성화
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
    }

    private void OnNextButtonClick()
    {
        clickCount++;

        if (clickCount == 1)
        {
            // 첫 번째 클릭: 첫 번째 이미지 활성화
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(false); // 두 번째 이미지는 비활성화
            image3.gameObject.SetActive(false); // 세 번째 이미지는 비활성화
        }
        else if (clickCount == 2)
        {
            // 두 번째 클릭: 두 번째 이미지 활성화
            image1.gameObject.SetActive(false); // 첫 번째 이미지는 비활성화
            image2.gameObject.SetActive(true);
            image3.gameObject.SetActive(false); // 세 번째 이미지는 비활성화
        }
        else if (clickCount == 3)
        {
            // 세 번째 클릭: 세 번째 이미지 활성화
            image1.gameObject.SetActive(false); // 첫 번째 이미지는 비활성화
            image2.gameObject.SetActive(false); // 두 번째 이미지는 비활성화
            image3.gameObject.SetActive(true);
        }

        // 클릭 횟수가 3을 넘으면 더 이상 버튼이 작동하지 않도록 설정
        if (clickCount >= 3)
        {
            nextButton.interactable = false;
        }
    }
}
