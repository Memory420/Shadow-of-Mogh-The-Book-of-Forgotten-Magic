using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; // Необходимо для доступа к Light2D
using UnityEngine.Rendering.Universal;

public class CandleFlicker : MonoBehaviour
{
    public Light2D spotLight2D; // Ссылка на компонент Light2D
    public float minIntensity = 0.8f; // Минимальная интенсивность
    public float maxIntensity = 1.2f; // Максимальная интенсивность
    public float flickerSpeed = 0.5f; // Скорость мерцания

    private float targetIntensity; // Целевая интенсивность для следующего шага мерцания

    void Start()
    {
        if (spotLight2D == null)
        {
            spotLight2D = GetComponent<Light2D>(); // Автоматически получаем компонент Light2D
        }
        targetIntensity = Random.Range(minIntensity, maxIntensity); // Начальная целевая интенсивность
    }

    void Update()
    {
        if (spotLight2D != null)
        {
            // Плавно изменяем интенсивность света к целевой интенсивности
            spotLight2D.intensity = Mathf.Lerp(spotLight2D.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

            // Если текущая интенсивность достаточно близка к целевой, выбираем новую целевую интенсивность
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

