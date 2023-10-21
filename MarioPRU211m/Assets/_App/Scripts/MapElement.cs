using UnityEngine;
namespace _App.Scripts
{
	public class MapElement : MonoBehaviour
	{
		private GameController GameController => GameController.instance;
		
		void Update()
		{
			if(GameController.IsStop) return;
			transform.Translate( GameController.speedMoveMap * Time.deltaTime * Vector2.left);
			if(transform.position.x < -30)
			{
				GameController.DoneMapMove();
				Destroy(gameObject);
			}
		}
	}
}