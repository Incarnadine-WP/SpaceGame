using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private GameObject _enemybullet;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GameObject.Find("Camera").GetComponent<AudioSource>();
        StartCoroutine(EnemyFire());
    }

   
    private IEnumerator EnemyFire()
    {
        var waitTimer = new WaitForSeconds(1f);
         
        while (true)
        {
            _audio.PlayOneShot(_fireSound, 0.2f);
            Instantiate(_enemybullet, transform.position, Quaternion.Euler(0, 0, 180));
            yield return waitTimer;
        }
    }

}
