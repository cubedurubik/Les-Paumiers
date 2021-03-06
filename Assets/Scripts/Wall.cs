using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite dmgSprite;
    public int hp = 2;

    public AudioClip chop;
    public AudioSource audio;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void DamageWall(int loss)
    {
        //spriteRenderer.sprite = dmgSprite;
        hp -= loss;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(chop, transform.position);
        }
    }
}
