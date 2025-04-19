using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform finishLine;
    [SerializeField] private CameraFollow cameraFollow;
    private Stickman stickman;
    [SerializeField] private float speedOnWin;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject particleEffect;

    private Vector3 initPos;
    private bool won;

    private void Start()
    {
        stickman = player.GetComponent<Stickman>();
        initPos = player.transform.position;
    }

    private void Update()
    {
        if (stickman.getSticked() == false)
        {
            if (player.transform.position.x < -5)
            {
                ResetGame();
            }
            if (player.transform.position.y < -6)
            {
                ResetGame();
            }
        }

        if (finishLine.position.x < player.transform.position.x && !won)
        {
            won = true;
            Win();
        }
    }

    private void ResetGame()
    {
        stickman.Reset(initPos);
    }

    private void Win()
    {
        // slow the player movement
        stickman.Win(speedOnWin);

        // player the particle effect
        particleEffect.SetActive(true);
        particleEffect.transform.parent = null;

        // slow the camera
        cameraFollow.Win();

        // finish the level
        StartCoroutine(FinishLevel());
    }

    IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0); // current scene because we don't have another scene yet
    }

}
