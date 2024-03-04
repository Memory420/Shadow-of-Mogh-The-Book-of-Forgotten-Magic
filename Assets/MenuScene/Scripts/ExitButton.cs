using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // �����, ������� ����� ������ ��� ������� ������ ������
    public void QuitGame()
    {
        // ���������, �������� �� ���� � ��������� Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ���� ���� �������� ��� ��������� Unity (��������, � ������),
        // �� ������� �� ����������
        Application.Quit();
#endif
    }
}
