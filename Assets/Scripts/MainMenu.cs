using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor; // Seulement dispo dans l’éditeur
#endif

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private SceneReference sceneJouer;
    [SerializeField] private SceneReference sceneSettings;

    // Bouton Jouer
    public void Jouer()
    {
        if (!string.IsNullOrEmpty(sceneJouer.SceneName))
            SceneManager.LoadScene(sceneJouer.SceneName);
    }

    // Bouton Settings
    public void Settings()
    {
        if (!string.IsNullOrEmpty(sceneSettings.SceneName))
            SceneManager.LoadScene(sceneSettings.SceneName);
    }
}

[System.Serializable]
public class SceneReference
{
#if UNITY_EDITOR
    [SerializeField] private SceneAsset sceneAsset; 
#endif
    [SerializeField] private string sceneName;

    public string SceneName => sceneName;

#if UNITY_EDITOR
    // Quand on change la scène dans l’Inspector, on enregistre son nom
    void OnValidate()
    {
        if (sceneAsset != null)
        {
            sceneName = sceneAsset.name;
        }
    }
#endif
}
