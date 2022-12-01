using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private Toggle _toggle;

    private PauseMenu _pauseMenu;
    private AudioSource _audio;
    private float _delay = 0;

    private void Start()
    {
        _pauseMenu = FindObjectOfType<PauseMenu>().GetComponent<PauseMenu>();
        _audio = FindObjectOfType<AudioSource>().GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        _delay -= Time.deltaTime;

        AutoShooting();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _pauseMenu.isGameActive && !_toggle.isOn)
        {
            _audio.PlayOneShot(_fireSound, 0.2f);
            GameObject pooledProjectile = ObjectPooling.Instance.GetPooledObject();

            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true);
                pooledProjectile.transform.position = transform.position;
            }

        }
    }

    public void AutoShooting()
    {
        if (_pauseMenu.isGameActive && _delay <= 0 && _toggle.isOn)
        {
            _audio.PlayOneShot(_fireSound, 0.2f);
            GameObject pooledProjectile = ObjectPooling.Instance.GetPooledObject();

            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true);
                pooledProjectile.transform.position = transform.position;
            }

            _delay = 0.3f;
        }
    }

}
