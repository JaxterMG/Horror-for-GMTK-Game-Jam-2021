using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    bool _pickup = false;
    bool _interact = false;
    bool _monologue = false;
    ItemHolder _currentHolder;
    Interactor _currentInteractorHolder;
    MonologueManager _currentMonologueHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.E) && _pickup)
         {
            PickupController.Instance.PickItem(_currentHolder._image, _currentHolder._itemName, _currentHolder._audioClip);
            _pickup = false;
            _currentHolder.ChangeSprite();
            _currentHolder.Destruct();
         }
        if (Input.GetKeyDown(KeyCode.E) && _interact)
        {
     
            if (_currentInteractorHolder._itemNeeded != string.Empty)
            {
                
                if (PickupController.Instance.CheckForItem(_currentInteractorHolder._itemNeeded, _currentInteractorHolder._audioClip))
                {
                    Debug.LogError("At door"); 
                    _currentInteractorHolder.ChangeSprite();
                    _currentInteractorHolder.Interact();
                 
                }
                
            }
            else
            {
                if(_currentInteractorHolder._audioClip!=null)
                 SoundManager.Instance.PlaySound(_currentInteractorHolder._audioClip);
                _currentInteractorHolder.ChangeSprite();
                _currentInteractorHolder.Interact();
                

            }
            _interact = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && _monologue)
        {
            _currentMonologueHolder.ChangeSprite();
            _currentMonologueHolder.PlayMonologue();
          
            _monologue = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if(collision.GetComponent<ItemHolder>())
        {
            _currentHolder = collision.GetComponent<ItemHolder>();
            _pickup = true;
            _currentHolder.ChangeSprite();

        }
        if (collision.GetComponent<Interactor>())
        {
            _currentInteractorHolder = collision.GetComponent<Interactor>();
            _interact = true;
            _currentInteractorHolder.ChangeSprite();
        }
        if (collision.GetComponent<MonologueManager>())
        {
            _currentMonologueHolder = collision.GetComponent<MonologueManager>();
            _monologue = true;
            _currentMonologueHolder.ChangeSprite();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _pickup = false;
        _interact = false;
        _monologue = false;
       
        if (_currentHolder != null)
        {
            Debug.LogError("Exit");
            _currentHolder.ChangeSprite();
            _currentHolder = null;

        }
        if(_currentInteractorHolder!=null)
        {
            Debug.LogError("Exit");
            _currentInteractorHolder.ChangeToFalse();
            _currentInteractorHolder = null;
        }
        if(_currentMonologueHolder!=null)
        {
            Debug.LogError("Exit");
            _currentMonologueHolder.ChangeSprite();
            _currentMonologueHolder = null;
        }
        
    }
}
