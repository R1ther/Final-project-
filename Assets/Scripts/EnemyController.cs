using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Sounds
{
    [SerializeField] private GameObject Player;
    private Animator _anim;
    [SerializeField] private Health_Player _hp;
    [SerializeField] private Transform _spawnRay;
    public GameObject bullet;
    public Transform spawnBullet;
    private AudioSource _au;

    public float shootForce;
    public float spread;
    [SerializeField] private float distance;
    [SerializeField] private float maxAngleChange;
    public static BoxCollider EnemyCollider;


    private bool _canShoot = true;
    private bool _canRecoil = true;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _au = GetComponent<AudioSource>();
        EnemyCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Player = col.gameObject;
            transform.LookAt(col.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            if (_canShoot == true && !_au.isPlaying)
            {
                StartCoroutine(Fire());
            }
        }
    }
    IEnumerator Fire()
    {
        _anim.SetTrigger("Fire");
        Vector3 direction = Quaternion.Euler(Random.Range(-maxAngleChange, maxAngleChange), Random.Range(-maxAngleChange, maxAngleChange), 0) * transform.forward;
        Ray ray = new Ray(_spawnRay.position, direction);

        PlaySound(sounds[0]);

        Debug.DrawRay(_spawnRay.position, direction * 100f);

        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
            if(hit.collider.CompareTag("Player"))
            {
                _hp.HealthDown();
            }
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

        _canRecoil = false;
        _canShoot = false;

        yield return new WaitForSeconds(1.3f);

        _canShoot = true;
        _canRecoil = true;
    }
}

