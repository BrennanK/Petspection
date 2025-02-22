using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Lever : MonoBehaviour
{
    //private bool canActivate;
    // Start is called before the first frame update
    private bool flipped;
    private bool canTrigger;
    [SerializeField]
    private float timeTillFlipBack;

    private float timePassed;

    [SerializeField]
    private Sprite unflippedSprite;

    [SerializeField]
    private Sprite flippedSprite;

    private SpriteRenderer sr;

    public Light2D lightAffected;

    private float originalLightIntensity;

    public GameEvent lightEvent;

    public AK.Wwise.Event LeverDown;

    public AK.Wwise.Event LeverUp;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        flipped = false;
        originalLightIntensity = lightAffected.intensity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && flipped == false && canTrigger==true)
        {
            Debug.Log("E pressed");
            flipped = true;
            sr.sprite = flippedSprite;
            lightAffected.intensity = 0f;
            lightEvent.Raise(this, true);
            LeverDown.Post(gameObject);
            InvokeRepeating("checkForFlipBack", Time.deltaTime, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Dog>()!=null)
        {
            canTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Dog>() != null)
        {
            canTrigger = false;
        }
    }

    private void checkForFlipBack()
    {
        if(timePassed>=timeTillFlipBack)
        {
            flipped = false;
            timePassed = 0;
            sr.sprite = unflippedSprite;
            lightAffected.intensity = originalLightIntensity;
            lightEvent.Raise(this, false);
            CancelInvoke();
            LeverUp.Post(gameObject);
            return;
        }

        timePassed += Time.deltaTime;


    }

   public void eneteredLight(Component sender, object data)
    {
        lightEvent.Raise(this, flipped);
    }
}
