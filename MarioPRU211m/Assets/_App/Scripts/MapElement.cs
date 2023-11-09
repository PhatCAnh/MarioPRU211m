using UnityEngine;
namespace _App.Scripts
{
	public class MapElement : MonoBehaviour
	{
		private GameController gameController => GameController.instance;
		
		void Update()
		{
			if(gameController.isStop) return;
			transform.Translate(gameController.speedMoveMap * Time.deltaTime * Vector2.left);
			if(transform.position.x < -30)
			{
				gameController.DoneMapMove();
				Destroy(gameObject);
			}
		}
	}
}