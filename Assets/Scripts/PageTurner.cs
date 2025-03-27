using UnityEngine;
using UnityEngine.XR;

public class PageTurner : MonoBehaviour
{
    public Book book;  // Book 클래스를 참조 (Book Page Curl 에셋에서 제공)

    public Transform leftHotSpot;
    public Transform rightHotSpot;
    public float detectionRadius = 0.2f;

    // XR 손 장치 가져오기
    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;

    void Start()
    {
        // XR 장치 초기화
        InitializeInputDevices();
    }

    void Update()
    {
        // 매 프레임마다 손의 위치를 추적
        Vector3 leftHandPosition, rightHandPosition;
        if (leftHandDevice.TryGetFeatureValue(CommonUsages.devicePosition, out leftHandPosition) &&
            rightHandDevice.TryGetFeatureValue(CommonUsages.devicePosition, out rightHandPosition))
        {
            // 왼손이 왼쪽 핫스팟에 가까워지면 왼쪽 페이지 넘기기
            if (Vector3.Distance(leftHandPosition, leftHotSpot.position) < detectionRadius)
            {
                book.DragLeftPageToPoint(leftHandPosition);
            }
            // 오른손이 오른쪽 핫스팟에 가까워지면 오른쪽 페이지 넘기기
            else if (Vector3.Distance(rightHandPosition, rightHotSpot.position) < detectionRadius)
            {
                book.DragRightPageToPoint(rightHandPosition);
            }
        }
    }

    // XR 장치 초기화
    void InitializeInputDevices()
    {
        leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
}
