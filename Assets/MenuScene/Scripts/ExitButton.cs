using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Метод, который будет вызван при нажатии кнопки выхода
    public void QuitGame()
    {
        // Проверяем, запущена ли игра в редакторе Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Если игра запущена вне редактора Unity (например, в сборке),
        // то выходим из приложения
        Application.Quit();
#endif
    }
}
