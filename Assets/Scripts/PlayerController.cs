using System.Collections;
using UnityEngine;

public class PlayerController : PlayerBase
{
#pragma warning disable IDE0044 // Add readonly modifier
    [SerializeField] InputManagerSO inputs;
    [SerializeField] bool isP2;
    [SerializeField][Min(0.01f)] float speed = 1;
    [SerializeField] Animation tauntAnimator1, tauntAnimator2;
    [SerializeField] AnimationClip tauntAnimation1, tauntAnimation2;
#pragma warning restore IDE0044 // Add readonly modifier

    CharacterController chCo;
    Vector3 movement;

    void OnEnable()
    {
        movement = Vector3.zero;
        if (isP2)
        {
            inputs.Move2 += Move;
            inputs.Taunt2 += Taunt;
        }
        else
        {
            inputs.Move1 += Move;
            inputs.Taunt1 += Taunt;
        }
    }
    void OnDisable()
    {
        if (isP2)
        {
            inputs.Move2 -= Move;
            inputs.Taunt2 -= Taunt;
        }
        else
        {
            inputs.Move1 -= Move;
            inputs.Taunt1 -= Taunt;
        }
    }

    void Awake()
    {
        tauntAnimator1.AddClip(tauntAnimation1, "Taunt");
        tauntAnimator2.AddClip(tauntAnimation2, "Taunt");
        tauntAnimator1.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
        tauntAnimator2.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
    }
    void Start()
    {
        chCo = GetComponent<CharacterController>();
    }
    void Update()
    {
        movement.y = -1f / speed;
        chCo.Move(transform.TransformDirection(movement) * speed * Time.deltaTime);
    }


    protected override void Move(bool isPressed, Vector2 direction) => movement = isPressed ? new(-direction.x, 0, -direction.y) : Vector3.zero;

    public override void Taunt(bool isPressed)
    {
        if (isPressed)
        {
            tauntAnimator1.Rewind("Taunt");
            tauntAnimator2.Rewind("Taunt");
            tauntAnimator1.Play("Taunt");
            tauntAnimator2.Play("Taunt");
            Invoke("StopTaunt", 2);
        }
    }
    void StopTaunt()
    {
        tauntAnimator1.Stop("Taunt");
        tauntAnimator2.Stop("Taunt");
    }
}
