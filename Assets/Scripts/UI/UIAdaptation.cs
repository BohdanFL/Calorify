using UnityEngine;
using UnityEngine.UI;

public class UIAdaptation : MonoBehaviour
{
    public RectTransform[] elements;
    private Vector2[] initialPositions;
    private Vector2 screenResolution;

    void Awake()
    {
        // �������� �������� ������� ��������
        initialPositions = new Vector2[elements.Length];
        for (int i = 0; i < elements.Length; i++)
        {
            initialPositions[i] = elements[i].anchoredPosition;
        }
        // �������� ����� ������
        screenResolution = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        // �������� �������� ����� ������
        Vector2 currentResolution = new Vector2(Screen.width, Screen.height);
        // ���������� ����������� �������������
        float scaleX = currentResolution.x / screenResolution.x;
        float scaleY = currentResolution.y / screenResolution.y;
        // ����������� ����������� ������������� �� ��������
        for (int i = 0; i < elements.Length; i++)
        {
            // ���������� ��� ������� ��������
            float newX = initialPositions[i].x * scaleX;
            float newY = initialPositions[i].y * scaleY;
            Vector2 newPosition = new Vector2(newX, newY);
            // ����������� ��� ������� � �������� �� ��������
            elements[i].anchoredPosition = newPosition;
            elements[i].localScale = new Vector2(scaleX, scaleY);
        }
    }
}
