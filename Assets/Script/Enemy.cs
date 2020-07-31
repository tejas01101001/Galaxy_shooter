using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 4.0f;

    private player _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed* Time.deltaTime);
        if(transform.position.y<-5.0f)
        {
            float RandomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(RandomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            Destroy(this.gameObject);
            player player=other.transform.GetComponent<player>();

            if(player!=null)
            {
                player.Damage();
            }

        }

        if(other.tag=="Laser")
        {
            Destroy(this.gameObject);
            if(_player!=null)
            {
                _player.AddScore();
            }
            Destroy(other.gameObject);
        }
    }
}
