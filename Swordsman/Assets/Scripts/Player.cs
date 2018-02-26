using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

      private Player m_Player;
      public Vector3 offset;
      private float _pointY;
	public float Speed = 0.003f;
      public float damping = 1;
	//Default move speed

	// Use this for initialization
	void Start () {
		m_Player = GameObject.Find("Player").GetComponent<Player>(); 
            offset =  transform.position- m_Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        _pointY = m_Player.transform.eulerAngles.y;
        //Debug.Log(_pointY);//0~360  
        Quaternion rotatiom = Quaternion.Euler(0, _pointY, 0);
        transform.position = Vector3.Lerp(transform.position, m_Player.transform.position + (rotatiom * offset),Time.deltaTime*damping);  
        
        transform.LookAt(m_Player.transform.position);

		       if (Input.GetKey (KeyCode.W)) {
                              gameObject.GetComponent<Transform> ().Translate (Vector3.forward * 0.05f, Space.Self);
                   }
                   if (Input.GetKey (KeyCode.S)) {
                            gameObject.GetComponent<Transform> ().Translate (Vector3.back * 0.05f, Space.Self);
                   }
                   if (Input.GetKey (KeyCode.A)) {
                          gameObject.GetComponent<Transform> ().Translate (Vector3.left * 0.05f, Space.Self);
                   }
                   if (Input.GetKey (KeyCode.D)) {
                         gameObject.GetComponent<Transform> ().Translate (Vector3.right * 0.05f, Space.Self);
                   }
                   //跳跃
                   if (Input.GetKey (KeyCode.Space)) {
                            gameObject.GetComponent<Transform> ().Translate (Vector3.up * Time.deltaTime * Speed);
                   }
                   //转向
                   if (Input.GetKey (KeyCode.LeftArrow)) {
                            gameObject.GetComponent<Transform> ().Rotate (0f, -2f, 0f);
                   }
                   if (Input.GetKey (KeyCode.RightArrow)) {
                            gameObject.GetComponent<Transform> ().Rotate (0f, 2f, 0f);
                   }
		
	}
}
