using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public float speed;
  private Animator anim;
  public Transform rival;
  private bool isRight;

    // Start is called before the first frame update
    void Start()
    {
      anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

      Vector3 mov = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
      transform.position = Vector3.MoveTowards(transform.position, transform.position + mov, speed * Time.deltaTime);
      if(mov.x != 0 || mov.y != 0)
      {
        anim.SetBool("Moving", true);
      } else {
        anim.SetBool("Moving", false);
      }

      if (transform.position.y < rival.position.y)
      {
        isRight = true;
      } else {
        isRight = false;
      }

      if (Input.GetButtonDown("Fire1"))
      {
        if (!isRight)
        {
          PunchLeft();
        } else {
          PunchRight();
        }
      }
    }

    void PunchRight()
    {
      anim.SetTrigger("PunchRight");
      //Debug.Log("Right punch");
    }

    void PunchLeft()
    {
      anim.SetTrigger("PunchLeft");
      //Debug.Log("Left punch");
    }
}
