using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour {

    // configuration parameters

    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    // cached reference

    Ball1 ball1;
    GameSession gameSession;

    // Use this for initialization
    void Start ()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball1 = FindObjectOfType<Ball1>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;
        
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball1.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        }
    }

}
