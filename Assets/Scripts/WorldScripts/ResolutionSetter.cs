using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSetter : MonoBehaviour
{
    void Start()
    {
        // Установите желаемое соотношение сторон, например 16:9
        float targetAspect = 10.0f / 16.0f;

        // Получаем текущее разрешение экрана
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Вычисляем масштаб по вертикали
        float scaleHeight = windowAspect / targetAspect;

        // Создаем новый Rect для камеры
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;

        if (scaleHeight < 1.0f)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        camera.rect = rect;
    }
}