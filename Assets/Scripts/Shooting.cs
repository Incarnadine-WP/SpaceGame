using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private AudioClip _fireSound;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GameObject.Find("Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audio.PlayOneShot(_fireSound, 0.5f);
            GameObject pooledProjectile = ObectPooling.Instance.GetPooledObject();

            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true);
                pooledProjectile.transform.position = transform.position;
            }
        }
    }
  
}
