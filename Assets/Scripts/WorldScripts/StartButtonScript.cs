using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    // Название следующей сцены, которую нужно загрузить
    public string nextSceneName;

    // Метод для вызова при нажатии на кнопку
    public void OnStartButtonPressed()
    {
        // Загрузка следующей сцены
        SceneManager.LoadScene(nextSceneName);
    }
}
