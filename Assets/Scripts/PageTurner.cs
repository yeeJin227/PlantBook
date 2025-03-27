using UnityEngine;
using UnityEngine.XR;

public class PageTurner : MonoBehaviour
{
    public Book book;  // Book Ŭ������ ���� (Book Page Curl ���¿��� ����)

    public Transform leftHotSpot;
    public Transform rightHotSpot;
    public float detectionRadius = 0.2f;

    // XR �� ��ġ ��������
    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;

    void Start()
    {
        // XR ��ġ �ʱ�ȭ
        InitializeInputDevices();
    }

    void Update()
    {
        // �� �����Ӹ��� ���� ��ġ�� ����
        Vector3 leftHandPosition, rightHandPosition;
        if (leftHandDevice.TryGetFeatureValue(CommonUsages.devicePosition, out leftHandPosition) &&
            rightHandDevice.TryGetFeatureValue(CommonUsages.devicePosition, out rightHandPosition))
        {
            // �޼��� ���� �ֽ��̿� ��������� ���� ������ �ѱ��
            if (Vector3.Distance(leftHandPosition, leftHotSpot.position) < detectionRadius)
            {
                book.DragLeftPageToPoint(leftHandPosition);
            }
            // �������� ������ �ֽ��̿� ��������� ������ ������ �ѱ��
            else if (Vector3.Distance(rightHandPosition, rightHotSpot.position) < detectionRadius)
            {
                book.DragRightPageToPoint(rightHandPosition);
            }
        }
    }

    // XR ��ġ �ʱ�ȭ
    void InitializeInputDevices()
    {
        leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
}
