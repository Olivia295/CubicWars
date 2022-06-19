using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	private int killCounter = 0;
	public Text textKillCounter;

	void Start() {
		_camera = GetComponent<Camera>();

		// Cursor.lockState = CursorLockMode.Locked;
		// Cursor.visible = false;
		
		textKillCounter.text = "已击杀敌人数："+killCounter.ToString();
	}

	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
					killCounter += 1;
					textKillCounter.text = "已击杀敌人数：" + killCounter.ToString();
				} else {
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(0.5f);

		Destroy(sphere);
	}
}