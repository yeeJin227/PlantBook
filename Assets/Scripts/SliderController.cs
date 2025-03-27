using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : MonoBehaviour
{
    public Image image1; // 첫 번째 이미지
    public Image image2; // 두 번째 이미지
    public Button nextButton; // 버튼
    public GameObject Sun; // 해 오브젝트

    private int clickCount = 0; // 버튼 클릭 횟수 추적
    private float effectDuration = 5.0f; // 해 쬐는 시간

    private void Start()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        nextButton.onClick.AddListener(OnNextButtonClick);

        // 시작할 때 두 이미지를 비활성화
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        
        Sun.SetActive(false); // 해 오브젝트 비활성화
    }

    private void OnNextButtonClick()
    {
        clickCount++;

        if (clickCount == 1)
        {
            StartCoroutine(ShowImageAfterSunEffect(image1)); // 첫 번째 이미지 활성화
        }
        else if (clickCount == 2)
        {
            StartCoroutine(ShowImageAfterSunEffect(image2)); // 두 번째 이미지 활성화
        }

        // 클릭 횟수가 2를 넘으면 더 이상 버튼이 작동하지 않도록 설정
        if (clickCount >= 2)
        {
            nextButton.interactable = false;
        }
    }

    private IEnumerator ShowImageAfterSunEffect(Image image)
    {
        nextButton.interactable = false;
        Sun.SetActive(true); // 해 오브젝트 활성화

        float elapsedTime = 0f;

        // 효과 지속 시간 동안 기다림
        while (elapsedTime < effectDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Sun.SetActive(false); // 해 오브젝트 비활성화
        // 해 쬐기가 끝난 후 이미지 활성화
        image.gameObject.SetActive(true);
        //다음 클릭을 위해 버튼 다시 활성화
        if(clickCount<2)
        {
            nextButton.interactable = true;
        }
    }
}