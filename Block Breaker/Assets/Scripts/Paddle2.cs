using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{

    // configuration parameters

    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;
    //[SerializeField] float screenWidthInUnits = 16f;
    public GameObject myPrefabObject = null;


    public float playerVelocity;
    private Vector3 playerPosition;
    //public float boundary;



    // cached reference

    Ball2 ball2;
    GameSession gameSession;

    // Use this for initialization
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball2 = FindObjectOfType<Ball2>();
        playerPosition = gameObject.transform.position;


        // Spawn Extra Ball2
        Instantiate(
            myPrefabObject,
            new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
            Quaternion.identity);
        
        /*
        Instantiate(
            myPrefabObject,
            transform.position,
            Quaternion.identity);
        */

    }

    void Update()
    {
        // horizontal movement
        playerPosition.x = GetXPos();


        // boundaries
        if (playerPosition.x < xMin)
        {
            playerPosition.x = xMin;
        }
        if (playerPosition.x > xMax)
        {
            playerPosition.x = xMax;
        }

        // update the game object transform
        transform.position = playerPosition;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball2.transform.position.x;
        }
        else
        {
            return (playerPosition.x + Input.GetAxis("Horizontal") * playerVelocity);
        }
    }


    /*
    // Update is called once per frame
    void Update ()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;

    }
    
    */



}
