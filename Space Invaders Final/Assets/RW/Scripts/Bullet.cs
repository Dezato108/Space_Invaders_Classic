using UnityEngine;

namespace RayWenderlich.SpaceInvadersUnity
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] 
        private float speed = 200f;
        
        [SerializeField] 
        private float lifeTime = 5f;

        internal void DestroySelf()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            GameManager.Instance.CreateExplosion(transform.position);
        }

        internal void Disappear()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            //GameManager.Instance.CreateExplosion(transform.position);
        }

        private void Awake()
        {
            Invoke("Disappear", lifeTime);
        }

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            DestroySelf();
        }
    }
}
