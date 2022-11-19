using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private AudioClip _fireSound;

    private PauseMenu _pauseMenu;
    private AudioSource _audio;

    private void Start()
    {
        _pauseMenu = FindObjectOfType<PauseMenu>().GetComponent<PauseMenu>();
        _audio = GameObject.Find("Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _pauseMenu.isGameActive)
        {
            _audio.PlayOneShot(_fireSound, 0.2f);
            GameObject pooledProjectile = ObectPooling.Instance.GetPooledObject();

            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true);
                pooledProjectile.transform.position = transform.position;
            }
        }
    }
  
}
