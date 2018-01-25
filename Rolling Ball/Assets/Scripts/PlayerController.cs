using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    private bool win = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        StartNewGame();
    }

    private void StartNewGame()
    {
        print("Start new game");
        count = 0;
        SetCountText();
        winText.text = "";
        
    }


    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //Did user press N?
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNewGame();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Pick Up") || other.gameObject.CompareTag("Pick Up++")) && win)
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.CompareTag("Pick Up"))
                ++count;
            else
                count += 5;

            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 16 && win == true)
        {
            winText.text = "You Win!";
            GameObject.Find("Player").SendMessage("Win");
        }
    }

    void Lose()
    {
        win = false;
    }
}
