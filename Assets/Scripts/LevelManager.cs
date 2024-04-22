using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private Animator _transitionAnim;
   // [SerializeField] private GameObject _UIElements;
    [SerializeField] private GameObject _imageObject;

    private void Awake()
    {
        if(Instance == null)
        {
        Instance= this;
            DontDestroyOnLoad(gameObject);
        }

        //StopCoroutine(LevelTransition());
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMazeScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LevelTransition());
    }

    IEnumerator LevelTransition()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(1);
        _transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        _imageObject.SetActive(false);
       // _UIElements.SetActive(true);
    }
}
