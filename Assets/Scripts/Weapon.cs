using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : Sounds
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;
    private Animator _anim;

    public float shootForce;
    public float spread;

    private bool _canShoot = true;
    private bool _canRecoil = true;

    [SerializeField] private int reloadAmmo;
    [SerializeField] private int totalAmmo;
    [SerializeField] private int canuseAmmo;

    [SerializeField] private TMP_Text CA;
    [SerializeField] private TMP_Text AA;

    [SerializeField] private RagdollEnemy _enemy;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        CA.text = canuseAmmo.ToString();
        AA.text = reloadAmmo.ToString();

        if (Input.GetMouseButtonDown(0) && _canShoot == true && canuseAmmo > 0)
        {
            StartCoroutine(Shoot());
        }
        if (Input.GetKeyDown(KeyCode.R) && _canRecoil == true)
        {
            StartCoroutine(recoil());
        }
        if(canuseAmmo == 0 && _canRecoil == true && reloadAmmo > 0)
        {
            StartCoroutine(recoil());
        }
        if(canuseAmmo == totalAmmo || reloadAmmo == 0)
        {
            _canRecoil = false;
        }
    }

    IEnumerator Shoot()
    {
        _anim.SetTrigger("Shoot");
        canuseAmmo -= 1;

        PlaySound(sounds[0]);

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.right * -100, Color.red);

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
            if(hit.collider.CompareTag("Enemy"))
            {
                _enemy.Kill();
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

        yield return new WaitForSeconds(0.3f);

        _canShoot = true;
        _canRecoil = true;
    }
    IEnumerator recoil()
    {
        _anim.SetTrigger("recoil");

        PlaySound(sounds[1]);

        if (reloadAmmo - (totalAmmo - canuseAmmo) < 0)
        {
            canuseAmmo += reloadAmmo;
            reloadAmmo = 0;
        }
        else
        {
            reloadAmmo = reloadAmmo - (totalAmmo - canuseAmmo);
            canuseAmmo += totalAmmo - canuseAmmo;
        }

        _canRecoil = false;
        _canShoot = false;

        yield return new WaitForSeconds(2f);

        _canShoot = true;
        _canRecoil = true;

    }
}
