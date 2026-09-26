using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject particle;
    float playerYPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (!particle.activeInHierarchy)
            {

            particle.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0))
            {

                PositionSwitch();
                GameManager.instance.Shake();

            }
        }
       
    }

    void PositionSwitch()
    {
        playerYPos = -playerYPos;
        transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.UpdateLives();
        GameManager.instance.Shake();
    }
}
