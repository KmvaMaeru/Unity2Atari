using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
  public int maxScore = 9999;
  public int currentScore;

  public TextMeshProUGUI scoreDisplay;

  private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreDisplay.text = currentScore.ToString();

        anim = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
      if (currentScore >= maxScore) {
        return;
      }

      currentScore += damage;
      scoreDisplay.text = currentScore.ToString();

      anim.SetTrigger("GetHit");

    }

}
