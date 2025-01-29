using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PageAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform rFlip;
    private float turnSpeed = 0.75f; // Velocidade da virada

    private bool isTurning = false;

    public void COTurnRPage() {

        if(!isTurning) {
            StartCoroutine(TurnRPage());
        }

    }

    public void COTurnLPage() {

    }

    private IEnumerator TurnRPage() {
        isTurning = true;

        Image i = GameObject.Find("Right Flip").GetComponent<Image>();

        Color c = i.color;
        c.a = 1;
        i.color = c;
        
        Quaternion startRotation = rFlip.rotation; // posição inicial
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0); // rotação da página (90º 2D)

        float timeElapsed = 0f;

        // animação da rotação
        while(timeElapsed < 1f) {
            timeElapsed += Time.deltaTime * turnSpeed;
            rFlip.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed); // atualiza a rotação
            yield return null;
        }

        c.a = 0;
        i.color = c;

        rFlip.rotation = Quaternion.Euler(0, 0, 0); // reseta a posição da imagem

        isTurning = false;
    }

    private void TurnLPage() {

    }
}
