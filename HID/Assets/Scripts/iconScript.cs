using UnityEngine;
using UnityEngine.EventSystems;

public class iconScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    Animator anim;
    void Start() => anim = gameObject.GetComponent<Animator>();

    public void OnPointerEnter(PointerEventData eventData) => anim.SetBool("Over", true);
    public void OnPointerExit(PointerEventData eventData) => anim.SetBool("Over", false);
    public void IsClicked() => anim.SetTrigger("Clicked");
}
