using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;


    public float hp;
    public Image displayHP;
    public float sp;
    public Image displaySP;

    public Transform model;
    public Transform lookat;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        UpdateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetAxis("Vertical") != 0f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime, ForceMode.Impulse);
        }

        if (gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("punch");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger("kick");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("block");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("special");
        }

        lookat.localPosition = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        model.LookAt(lookat);
    }

    void UpdateStats()
    {
        displayHP.fillAmount = hp / 100;
        displaySP.fillAmount = sp / 20;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 10;
            UpdateStats();
        }
    }
}
