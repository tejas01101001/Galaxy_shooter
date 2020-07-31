using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserprefab;
    [SerializeField]
    private float _firerate=0.15f;
    [SerializeField]
    private float _canfire = -1f;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private Spawn_Manager _spawnmanager;
    [SerializeField]
    private AudioClip _laserSoundClip;
    [SerializeField]
    private AudioSource _audiosource;
    [SerializeField]
    private int _score = 0;

    private UIManager _uiManager;
    void Start()
    {

        //take the current postion =new postion (0,0,0)
        transform.position = new Vector3(0, -2f, 0);
        _audiosource = GetComponent<AudioSource>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnmanager = GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>();
        if(_spawnmanager==null)
        {
            Debug.LogError("Hey dont ship");
        }
        if (_uiManager == null)
        {
            Debug.LogError("Hey UI manager is null");
        }
        if (_audiosource == null)
        {
            Debug.LogError("Audio Source of player is NULL");
        }
        else
        {
            _audiosource.clip = _laserSoundClip;
        }

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
        {
            firelaser();
        }
    }
    void movement()
    {
        float Hinput = Input.GetAxis("Horizontal");
        float Vinput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right*Hinput*_speed*Time.deltaTime);
        //ransform.Translate(Vector3.up * Vinput * _speed * Time.deltaTime);

        Vector3 direction = new Vector3(Hinput, Vinput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.x >= 11.2f)
        {
            transform.position = new Vector3(-11.2f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.2f)
        {
            transform.position = new Vector3(11.1f, transform.position.y, 0);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.97f,5.97f),0);
    }

    void firelaser()
    {
         _canfire = Time.time + _firerate;
         Instantiate(_laserprefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);

        _audiosource.Play();
    }

    public void Damage()
    {
        _lives --;
        _uiManager.UpdateLives(_lives);
        if(_lives<=0)
        {
            _spawnmanager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void AddScore()
    {
        _score += 10;
        _uiManager.UpdateScore(_score);
    }
}
