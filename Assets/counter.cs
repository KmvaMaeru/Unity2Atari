using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class counter : MonoBehaviour
{
    public TextMeshProUGUI timeMarker;

    public float startTime = 100.0f;
    private float currentTime;

    public GameObject finalScreen;
    // Start is called before the first frame update
    void Start()
    {
      currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
      currentTime -= Time.deltaTime;

      timeMarker.text = "TIME:" + currentTime.ToString("0");

      if (currentTime <= 0) {
        GameEnd();
      }
    }

    void GameEnd()
    {
      finalScreen.gameObject.SetActive(true);
      Time.timeScale = 0;
    }

    public void ReloadScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      Time.timeScale = 1;
    }
}
