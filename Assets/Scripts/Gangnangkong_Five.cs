using UnityEngine;

public class Gangnangkong_Five : MonoBehaviour
{
    public GameObject oldCanvas; // 원래 캔버스
    public GameObject intermediateCanvas; // 중간에 띄울 캔버스
    public GameObject image1; // 이미지1
    public GameObject image2; // 이미지2
    public GameObject associatedObject; // 추가된 오브젝트
    public float activationDistance = 2.0f; // 플레이어와 오브젝트 간 거리

    private Transform player; // 플레이어의 Transform
    private bool intermediateCanvasActivated = false; // 중간 캔버스가 이미 활성화되었는지 여부

    void Start()
    {
        oldCanvas.SetActive(false);
        intermediateCanvas.SetActive(false);
        associatedObject.SetActive(false); // 추가된 오브젝트 비활성화
        player = Camera.main.transform; // 주 카메라 Transform 가져오기
        Debug.Log("Start: Initial setup completed.");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        Debug.Log("Update: Distance to player: " + distance);

        // 플레이어가 오브젝트에 가까이 있고, oldCanvas가 활성화되어 있지 않을 때
        if (distance <= activationDistance)
        {
            if (!oldCanvas.activeSelf && !image1.activeInHierarchy && !image2.activeInHierarchy && !intermediateCanvasActivated)
            {
                oldCanvas.SetActive(true);
                associatedObject.SetActive(true); // 추가된 오브젝트 활성화

                Debug.Log("Update: Old Canvas and Associated Object Activated");
            }

            if (image1.activeInHierarchy && image2.activeInHierarchy && !intermediateCanvasActivated)
            {
                oldCanvas.SetActive(false); // 원래 캔버스 비활성화
                associatedObject.SetActive(false); // 추가된 오브젝트 비활성화
                intermediateCanvas.SetActive(true); // 중간 캔버스 활성화
                intermediateCanvasActivated = true; // 중간 캔버스가 활성화되었음을 기록
                Debug.Log("Update: Intermediate Canvas Activated");

                // 5초 후에 KeepIntermediateCanvasActive 메서드를 호출
                Invoke("KeepIntermediateCanvasActive", 3.0f);
            }
        }
        else
        {
            if (oldCanvas.activeSelf || associatedObject.activeSelf)
            {
                oldCanvas.SetActive(false);
                associatedObject.SetActive(false); // 추가된 오브젝트 비활성화
                Debug.Log("Update: Old Canvas and Associated Object Deactivated due to distance");
            }
        }

        // intermediateCanvas가 활성화된 경우, 거리가 activationDistance 이상이면 비활성화
        if (intermediateCanvasActivated && distance > activationDistance)
        {
            intermediateCanvas.SetActive(false);
            intermediateCanvasActivated = false;
            Debug.Log("Update: Intermediate Canvas Deactivated due to distance");
        }
    }

    void KeepIntermediateCanvasActive()
    {
        // 플레이어와 오브젝트 간 거리를 다시 확인하여 조건에 맞으면 intermediateCanvas를 활성화 상태로 유지
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= activationDistance)
        {
            intermediateCanvas.SetActive(true);
            Debug.Log("KeepIntermediateCanvasActive: Intermediate Canvas remains active after 5 seconds.");
        }
        else
        {
            intermediateCanvas.SetActive(false);
            intermediateCanvasActivated = false;
            Debug.Log("KeepIntermediateCanvasActive: Intermediate Canvas deactivated due to distance");
        }
    }
}
