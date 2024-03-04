using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Метод, который будет вызван при нажатии кнопки
    public void ChangeScene(string sceneName)
    {
        // Загрузка указанной сцены
        SceneManager.LoadScene(sceneName);
    }
}
