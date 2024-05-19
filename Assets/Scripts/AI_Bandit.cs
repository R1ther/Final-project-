using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Bandit : MonoBehaviour {
	private float timer;
	public GameObject Player;
	private Animator _anim;
	private Health_Player _hp;
	[SerializeField] private GameObject _spawnRay;
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
		_hp = Player.GetComponent<Health_Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player") {
			Player = col.gameObject;
			_anim.SetBool ("Fire", true);
			transform.LookAt (col.transform.position);
			transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
			onFire ();
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			_anim.SetBool ("Fire", false);
		}
	}
	void onFire()
	{
		Ray ray = new Ray(transform.position, transform.forward*100);
		RaycastHit hit;
		Debug.DrawRay(_spawnRay.transform.position, transform.forward * 100, Color.yellow);
		if (Physics.Raycast(ray, out hit))
		{
			if (gameObject.transform.CompareTag("Player"))
			{
				timer += 1 * Time.deltaTime;
				if (timer >= 1.2f)
				{
					_hp.Health -= 24;
					timer = 0;
				}
			}
		}
	}
}