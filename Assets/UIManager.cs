using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button play;
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(() => SceneManager.LoadSceneAsync("Game"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
