using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    CPlayer()
    {
        m_nUid = 10086;
    }


    public int m_nUid;


    private static CPlayer m_this = null;
    public static CPlayer Instance()
    {
        if(m_this==null)
        {
            m_this = new CPlayer();
        }

        return m_this;
    }
}
