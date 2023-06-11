using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flapscript : MonoBehaviour
{
    public Sprite initialSprite;
    public Sprite swappedSprite;
    public float swapDuration =
        50;
    private SpriteRenderer spriteRenderer;
    private bool isSwapping = false;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = initialSprite;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSwapping)
        {
            StartCoroutine(SwapSprites());
        }
    }
    private IEnumerator SwapSprites()
    {
        isSwapping = true;
        spriteRenderer.sprite = swappedSprite;
        yield return new WaitForSeconds(swapDuration * Time.deltaTime);
        spriteRenderer.sprite = initialSprite;
        isSwapping = false;
    }


}
