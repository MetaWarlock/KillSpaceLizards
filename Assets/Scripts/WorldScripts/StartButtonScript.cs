using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    // �������� ��������� �����, ������� ����� ���������
    public string nextSceneName;

    // ����� ��� ������ ��� ������� �� ������
    public void OnStartButtonPressed()
    {
        // �������� ��������� �����
        SceneManager.LoadScene(nextSceneName);
    }
}
