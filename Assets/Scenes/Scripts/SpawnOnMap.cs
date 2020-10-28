 // from Mapbox assets and modified

namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine.UI;

	public class SpawnOnMap : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		// [SerializeField]
		// [Geocode]
		string[] _locationStrings;
		Vector2d[] _locations;

		[SerializeField]
		float _spawnScale = 100f;

		[SerializeField]
		GameObject _markerPrefab;

		public static List<GameObject> _spawnedObjects;

		void Start()
		{
			//-----
			List<CsvreadAndGenerate.Row> lieux = CsvreadAndGenerate.FindAll_Nom_Lieu();

			ArrayList locationStringsTemp = new ArrayList();
			ArrayList namesTemp = new ArrayList();
			ArrayList visitTemp = new ArrayList();

			foreach (CsvreadAndGenerate.Row row in lieux) {
				if (row.Nom_Lieu == ""){
					continue;
				}
				string temp = "";
				temp += row.Latitude + ", " + row.Longitude;
				locationStringsTemp.Add(temp);
				namesTemp.Add(row.Nom_Lieu);
				visitTemp.Add(row.Visite);
			}
			_locationStrings = locationStringsTemp.ToArray(typeof(string)) as string[];
			string[] names = namesTemp.ToArray(typeof(string)) as string[];
			string[] visit = visitTemp.ToArray(typeof(string)) as string[];
			// -----

			_locations = new Vector2d[_locationStrings.Length];
			_spawnedObjects = new List<GameObject>();
			for (int i = 0; i < _locationStrings.Length; i++)
			{
				var locationString = _locationStrings[i];
				_locations[i] = Conversions.StringToLatLon(locationString);
				var instance = Instantiate(_markerPrefab);
				instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
				instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
		
				instance.transform.Find("TextMesh").GetComponent<TextMesh>().text = names[i];
				if (visit[i] == "1"){
					_changeToGreen(instance);
				}

				_spawnedObjects.Add(instance);
			}
		}

		private void Update()
		{
			int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{
				var spawnedObject = _spawnedObjects[i];
				var location = _locations[i];
				spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
				spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
			}
		}

		public static void changeToGreen(string place){
			GameObject instance = getPointObj(place);
			if (instance == null){
				Debug.LogError("lieu non placé sur la carte ? "+place);
			}
			_changeToGreen(instance);
		}

		public static void _changeToGreen(GameObject instance){
			Material mat = Resources.Load("Material/green", typeof(Material)) as Material;
			instance.transform.Find("Sphere").GetComponent<Renderer>().material = mat;
		}

		public static GameObject getPointObj(string name){
			foreach (GameObject obj in _spawnedObjects){
				if (obj.transform.Find("TextMesh").GetComponent<TextMesh>().text == name){
					return obj;
				}
			}
			return null;
		}
	}
}