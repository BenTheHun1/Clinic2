using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public bool following;
    PlayerController pl;
    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void Damage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (following)
        {
            gameObject.transform.LookAt(pl.gameObject.transform);
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * 5, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            following = true;
        }
    }

}
