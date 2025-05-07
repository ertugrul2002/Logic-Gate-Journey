using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


public class Micanical_door : MonoBehaviour {
	public bool open;	
	public AudioSource asource;
	public AudioClip openDoor,closeDoor;
	public GameObject text;
	public float openHeight = 3f; // ارتفاع الباب عند الفتح
    public float speed = 1f; // سرعة الفتح
    private Vector3 closedPosition;
    private Vector3 openPosition;
	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource> ();
        closedPosition = transform.localPosition;
        openPosition = closedPosition + new Vector3(0, openHeight, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (open)
		{
            transform.localPosition = Vector3.Lerp(transform.localPosition, openPosition, Time.deltaTime * speed);
			text.SetActive(false);
            
		}
		else
		{
            transform.localPosition = Vector3.Lerp(transform.localPosition, closedPosition, Time.deltaTime * speed);
		}  
	}

	public void OpenDoor(){
		open =!open;
		asource.clip = open?openDoor:closeDoor;
		asource.Play ();
	}
}
}