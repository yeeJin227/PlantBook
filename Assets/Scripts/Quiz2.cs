using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quiz2 : MonoBehaviour
{
    public Canvas canvas2;  // ���� Ȱ��ȭ�� ĵ���� (��ư 2�� ������ ��Ȱ��ȭ�� ĵ����)
    public Canvas canvas3;  // ��ư 2�� ������ �� Ȱ��ȭ�� ĵ����
    public Image image1;    // ��ư 1 �Ǵ� ��ư 3�� ������ �� Ȱ��ȭ�� �̹���
    public Image image2;    // ��ư 2�� ������ �� 3�� ���� Ȱ��ȭ�� �̹���

    // ������ ��ư
    public Button button1;
    public Button button2;
    public Button button3;

    void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ �Ҵ�
        button1.onClick.AddListener(OnButton1Or3Click);
        button2.onClick.AddListener(OnButton2Click);
        button3.onClick.AddListener(OnButton1Or3Click);

        // ���� �� �̹��� ��Ȱ��ȭ
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
    }

    // ��ư 1�� 3 Ŭ�� ó�� (Image1�� 3�� ���� Ȱ��ȭ)
    void OnButton1Or3Click()
    {
        // �ڷ�ƾ ���� (3�� �� �̹��� ��Ȱ��ȭ)
        StartCoroutine(ShowImage1ForDuration(3.0f));
    }

    // ��ư 2 Ŭ�� ó�� (Image2�� 3�� ���� Ȱ��ȭ �� Canvas3���� ��ȯ)
    void OnButton2Click()
    {
        // �ڷ�ƾ ���� (Image2 3�� Ȱ��ȭ �� ĵ���� ��ȯ)
        StartCoroutine(ShowImage2ThenSwitchCanvas(3.0f));
    }

    // Coroutine: Image1�� 3�� ���� Ȱ��ȭ�ߴٰ� ��Ȱ��ȭ�ϴ� �Լ�
    IEnumerator ShowImage1ForDuration(float duration)
    {
        // Image1 Ȱ��ȭ
        image1.gameObject.SetActive(true);

        // �־��� �ð�(��: 3��) ���� ���
        yield return new WaitForSeconds(duration);

        // Image1 ��Ȱ��ȭ
        image1.gameObject.SetActive(false);
    }

    // Coroutine: Image2�� 3�� ���� Ȱ��ȭ�� �� Canvas3���� ��ȯ�ϴ� �Լ�
    IEnumerator ShowImage2ThenSwitchCanvas(float duration)
    {
        // Image2 Ȱ��ȭ
        image2.gameObject.SetActive(true);

        // �־��� �ð�(��: 3��) ���� ���
        yield return new WaitForSeconds(duration);

        // Image2 ��Ȱ��ȭ
        image2.gameObject.SetActive(false);

        // Canvas2 ��Ȱ��ȭ
        if (canvas2 != null)
            canvas2.gameObject.SetActive(false);

        // Canvas3 Ȱ��ȭ
        if (canvas3 != null)
            canvas3.gameObject.SetActive(true);
    }
}
