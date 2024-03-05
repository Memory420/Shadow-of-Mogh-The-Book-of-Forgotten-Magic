using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; // ���������� ��� ������� � Light2D
using UnityEngine.Rendering.Universal;

public class CandleFlicker : MonoBehaviour
{
    public Light2D spotLight2D; // ������ �� ��������� Light2D
    public float minIntensity = 0.8f; // ����������� �������������
    public float maxIntensity = 1.2f; // ������������ �������������
    public float flickerSpeed = 0.5f; // �������� ��������

    private float targetIntensity; // ������� ������������� ��� ���������� ���� ��������

    void Start()
    {
        if (spotLight2D == null)
        {
            spotLight2D = GetComponent<Light2D>(); // ������������� �������� ��������� Light2D
        }
        targetIntensity = Random.Range(minIntensity, maxIntensity); // ��������� ������� �������������
    }

    void Update()
    {
        if (spotLight2D != null)
        {
            // ������ �������� ������������� ����� � ������� �������������
            spotLight2D.intensity = Mathf.Lerp(spotLight2D.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

            // ���� ������� ������������� ���������� ������ � �������, �������� ����� ������� �������������
            if (Mathf.Abs(spotLight2D.intensity - targetIntensity) < 0.05)
            {
                targetIntensity = Random.Range(minIntensity, maxIntensity);
            }
        }
        else
        {
            Debug.LogWarning("Light2D component is not attached to the object.");
        }
    }
}

