using UnityEngine;

public class Tomato_Three : MonoBehaviour
{
    public GameObject oldCanvas; // 원래 캔버스
    public GameObject intermediateCanvas; // 중간에 띄울 캔버스
    public GameObject nextObject; // 다음에 활성화할 오브젝트
    public GameObject currentObject;
    public GameObject supportStick;
    public GameObject fixedStick;
    public GameObject fixedTomato;
    public GameObject image1; // 이미지1
    public GameObject image2; // 이미지2
    public GameObject associatedObject; // 추가된 오브젝트
    public float activationDistance = 3.0f; // 플레이어와 오브젝트 간 거리
    public float supportDistance = 1.0f;

    private Transform player; // 플레이어의 Transform
    private bool intermediateCanvasActivated = false; // 중간 캔버스가 이미 활성화되었는지 여부

    void Start()
    {
        oldCanvas.SetActive(false);
        intermediateCanvas.SetActive(false);
        nextObject.SetActive(false);
        fixedStick.SetActive(false);
        associatedObject.SetActive(false); // 추가된 오브젝트 비활성화
        player = Camera.main.transform; // 주 카메라 Transform 가져오기
        Debug.Log("Start: Initial setup completed.");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        Debug.Log("Update: Distance to player: " + distance);
        float distance_support = Vector3.Distance(supportStick.transform.position, fixedStick.transform.position);

        // 플레이어가 오브젝트에 가까이 있고, oldCanvas가 활성화되어 있지 않을 때
        if (distance <= activationDistance)
        {
            if (!oldCanvas.activeSelf && !image1.activeInHierarchy && !image2.activeInHierarchy && !intermediateCanvasActivated)
            {
                oldCanvas.SetActive(true);
                associatedObject.SetActive(true); // 추가된 오브젝트 활성화
                supportStick.SetActive(true);
                Debug.Log("Update: Old Canvas and Associated Object Activated");
            }
            if(distance_support <= supportDistance){
                supportStick.SetActive(false);
                fixedStick.SetActive(true);
                currentObject.SetActive(false);
                fixedTomato.SetActive(true);
            }

            if (image1.activeInHierarchy && image2.activeInHierarchy && !intermediateCanvasActivated)
            {
                oldCanvas.SetActive(false); // 원래 캔버스 비활성화
                associatedObject.SetActive(false); // 추가된 오브젝트 비활성화
                gameObject.SetActive(false); // 현재 오브젝트 비활성화
                intermediateCanvas.SetActive(true); // 중간 캔버스 활성화
                intermediateCanvasActivated = true; // 중간 캔버스가 활성화되었음을 기록
                Debug.Log("Update: Intermediate Canvas Activated");

                // 5초 후에 IntermediateCanvasDeactivate 메서드를 호출
                Invoke("DeactivateIntermediateCanvas", 3.0f);
            }
        }
        else
        {
            if (oldCanvas.activeSelf)
            {
                Debug.Log("Update: Old Canvas and Associated Object Deactivated due to distance");
            }
            oldCanvas.SetActive(false);
            associatedObject.SetActive(false); // 추가된 오브젝트 비활성화
        }
    }

    void DeactivateIntermediateCanvas()
    {
        intermediateCanvas.SetActive(false); // 중간 캔버스 비활성화
        nextObject.SetActive(true); // 다음 오브젝트 활성화
        intermediateCanvasActivated = false; // 상태 초기화
        Debug.Log("DeactivateIntermediateCanvas: Intermediate Canvas Deactivated, Next Object Activated");
    }
}
