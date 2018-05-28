using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour {

    [SerializeField]
    private int sceneToLoad;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(sceneToLoad);
    }
}
