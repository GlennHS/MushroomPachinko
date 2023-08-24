using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    public GameObject ball;

    void OnMouseDown()
    {
        if(!GameManager.instance.ballDropping && GameManager.instance.ballsRemaining > 0)
        {
            GameManager.instance.ballDropping = true;
            GameManager.instance.ballsRemaining--;
            GameManager.instance.bluePegsHitThisDrop = 0;
            GameManager.instance.hitPegThisDrop = false;
            GameManager.instance.bouncinessIncreaseFromOrange = 0.0f;
            GameManager.instance.UpdateText();

            Vector3 actualMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            actualMousePos.z = 1;
            GameObject newBall = Instantiate(ball, actualMousePos, Quaternion.identity);
            newBall.GetComponent<Rigidbody2D>().sharedMaterial = GameManager.instance.originalBallMaterial;
        }
    }
}
