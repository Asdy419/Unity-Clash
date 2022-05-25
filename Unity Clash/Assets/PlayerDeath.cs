using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        float randomNumber = Random.Range(-8, 8);
        if (collision.gameObject.CompareTag("BlastZones"))
        {
            transform.position = new Vector2(randomNumber, 8);
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            //yield return new WaitForSeconds(6);
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
