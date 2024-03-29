using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor( typeof(EZParallax))]
public class EZParallaxEditor : Editor
{
	private bool m_parallaxElementViewExpanded;
	private bool m_parallaxElementViewExpandedByUser;
	private bool[] m_parallaxElementExpanded;
	
	public override void OnInspectorGUI()
	{
		EZParallax target = (EZParallax)this.target;
		
		EditorGUILayout.BeginVertical();
		
		target.m_parallaxingTagName = EditorGUILayout.TagField(new GUIContent("Auto-Parallax Tag Name", "Choose the tag name you wish to use to automatically assign parallaxing objects to EZP."), target.m_parallaxingTagName);
		target.m_wrapXParallaxingTagName = EditorGUILayout.TagField(new GUIContent("Auto-WrapX-Parallax Tag Name", "Just like the field above, however, THIS tag name will also make the added elements automatically wrap infinitely along the x axis. If you wish to control spawn distance between objects, you'll neeed to actually add the object to the element array below and specify the desired spawn distance."), target.m_wrapXParallaxingTagName);
		target.m_mainCamera = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Camera", "The camera that we will be parallaxing from, most likely your main gameplay camera."), target.m_mainCamera, typeof(GameObject), true);
		target.m_playerObj = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Player", "The player game object."), target.m_playerObj, typeof(GameObject), true);
		target.m_parallaxSpeedScalarX = EditorGUILayout.FloatField(new GUIContent("Parallax Speed Scalar X", "0-1 value used as a multiplier against all x axis movement. Change this value if you want to slow down x movement for all of the parallaxing objects."), target.m_parallaxSpeedScalarX);
		
		if(target.m_parallaxSpeedScalarX > 1)
		{
			target.m_parallaxSpeedScalarX = 1;
		}
		
		if(target.m_parallaxSpeedScalarX < 0)
		{
			target.m_parallaxSpeedScalarX = 0;
		}
		
		target.m_parallaxSpeedScalarY = EditorGUILayout.FloatField(new GUIContent("Parallax Speed Scalar Y", "Same as above, but for the y axis."), target.m_parallaxSpeedScalarY);
		
		if(target.m_parallaxSpeedScalarY > 1)
		{
			target.m_parallaxSpeedScalarY = 1;
		}
		
		if(target.m_parallaxSpeedScalarY < 0)
		{
			target.m_parallaxSpeedScalarY = 0;
		}
		
		target.m_randomOffsetHistorySize = EditorGUILayout.IntField(new GUIContent("Random Offset History Size","The size of the history queue. Make this bigger if you start to notice a recognizable pattern in your randomly spawning objects."), target.m_randomOffsetHistorySize);
		target.m_enableDollyZoom = EditorGUILayout.Toggle(new GUIContent("Enable Dolly Zoom", "Uncheck this box if you do not want to use EZParallax's enhanced zoom effect, which makes changes in orthographic camera sizes create the effect of true camera dollying, instead of just a flat zoom."), target.m_enableDollyZoom);
		target.m_autoInitialize = EditorGUILayout.Toggle(new GUIContent("Auto Initialize", "Uncheck this box if you want to dynamically set values of EZParallax from script before it is actually initialized. If unchecked, be sure to call the initialization function from a script when you're ready to start duplication and parallaxing."), target.m_autoInitialize);
		
		if(m_parallaxElementViewExpandedByUser == false)
		{
			m_parallaxElementViewExpanded = true;
		}
		
		m_parallaxElementViewExpanded = EditorGUILayout.Foldout( m_parallaxElementViewExpanded, "ParallaxElements" );
		
		if(m_parallaxElementViewExpandedByUser == false && m_parallaxElementViewExpanded == false)
		{
			m_parallaxElementViewExpandedByUser = true;
		}
		
		if ( m_parallaxElementViewExpanded )
		{
			EditorGUI.indentLevel ++;
			int oldNumParallaxElements = (target.m_parallaxElements == null) ? 0 : target.m_parallaxElements.Length;
			int numParallaxElements    = EditorGUILayout.IntField( "Size", oldNumParallaxElements );
			EditorGUI.indentLevel ++;
			if(GUILayout.Button("Add New Parallax Element"))
			{
				numParallaxElements += 1;
			}
			if(GUILayout.Button("Remove Last Parallax Element"))
			{
				numParallaxElements -= 1;
			}
			EditorGUI.indentLevel --;
			if ( numParallaxElements != oldNumParallaxElements )
			{
				EZParallaxObjectElement[] newEZPOElements = new EZParallaxObjectElement[ numParallaxElements ];
				for ( int i = 0; i < oldNumParallaxElements && i < numParallaxElements; ++i )
				{
					newEZPOElements[i] = target.m_parallaxElements[i];
				}
				
				for ( int i = oldNumParallaxElements; i < numParallaxElements; ++i )
				{
					newEZPOElements[i] = new EZParallaxObjectElement(null);
				}
				
				target.m_parallaxElements = newEZPOElements;
			}
			
			if ( m_parallaxElementExpanded == null || (target.m_parallaxElements != null && m_parallaxElementExpanded.Length != numParallaxElements ) )
			{
				m_parallaxElementExpanded = new bool[numParallaxElements];
			}
			
			for ( int i = 0; i < numParallaxElements; ++i )
			{
				EZParallaxObjectElement targetEZParallaxObjectElement = target.m_parallaxElements[i];
				string elementDisplayName = ( targetEZParallaxObjectElement.name != null && targetEZParallaxObjectElement.name.Length != 0) ? targetEZParallaxObjectElement.name : !targetEZParallaxObjectElement.parallaxObject ? "Parallax Element " + i.ToString() : targetEZParallaxObjectElement.parallaxObject.name;
				m_parallaxElementExpanded[i] = EditorGUILayout.Foldout( m_parallaxElementExpanded[i], elementDisplayName);
				if ( m_parallaxElementExpanded[i] )
				{
					EditorGUI.indentLevel ++;
					
					targetEZParallaxObjectElement.name = EditorGUILayout.TextField("Name", targetEZParallaxObjectElement.name);
					
					if(targetEZParallaxObjectElement.name != "Parallax Element " + i.ToString())
					{
						if(targetEZParallaxObjectElement.parallaxObject)
						{
							if(targetEZParallaxObjectElement.name != targetEZParallaxObjectElement.parallaxObject.name && targetEZParallaxObjectElement.name != "")
							{
								targetEZParallaxObjectElement.hasCustomName = true;
							}
							else
							{
								targetEZParallaxObjectElement.hasCustomName = false;
							}
						}
						
					}
					targetEZParallaxObjectElement.parallaxObject = (Transform)EditorGUILayout.ObjectField("Parallaxing Object", targetEZParallaxObjectElement.parallaxObject, typeof(Transform), true);
					if(!targetEZParallaxObjectElement.hasCustomName && targetEZParallaxObjectElement.parallaxObject)
					{
						targetEZParallaxObjectElement.name = targetEZParallaxObjectElement.parallaxObject.name;
					}
					
					targetEZParallaxObjectElement.privateParallaxSpeedScalarX = EditorGUILayout.FloatField(new GUIContent("Private Speed Scalar X", "This 0-1 value works as a multiplier to slow down parallax movement for this object only. Use it for fine tuning your parallax speeds along x."), targetEZParallaxObjectElement.privateParallaxSpeedScalarX);
					
					if(targetEZParallaxObjectElement.privateParallaxSpeedScalarX > 1)
					{
						targetEZParallaxObjectElement.privateParallaxSpeedScalarX = 1;
					}
					
					if(targetEZParallaxObjectElement.privateParallaxSpeedScalarX < 0)
					{
						targetEZParallaxObjectElement.privateParallaxSpeedScalarX = 0;
					}
					
					targetEZParallaxObjectElement.privateParallaxSpeedScalarY = EditorGUILayout.FloatField(new GUIContent("Private Speed Scalar Y", "This 0-1 value works as a multiplier to slow down parallax movement for this object only. Use it for fine tuning your parallax speeds along y."), targetEZParallaxObjectElement.privateParallaxSpeedScalarY);
					
					if(targetEZParallaxObjectElement.privateParallaxSpeedScalarY > 1)
					{
						targetEZParallaxObjectElement.privateParallaxSpeedScalarY = 1;
					}
					
					if(targetEZParallaxObjectElement.privateParallaxSpeedScalarY < 0)
					{
						targetEZParallaxObjectElement.privateParallaxSpeedScalarY = 0;
					}
					
					targetEZParallaxObjectElement.isMotorized = EditorGUILayout.Toggle("Is Motorized", targetEZParallaxObjectElement.isMotorized);
					if(targetEZParallaxObjectElement.isMotorized)
					{
						EditorGUI.indentLevel ++;
						targetEZParallaxObjectElement.initialMotorSpeed = EditorGUILayout.FloatField(new GUIContent("Motor Speed (unit/sec)", "Unity units per second that the object will move at. Negative values will move down negative x, positive values down positive x."), targetEZParallaxObjectElement.motorSpeed);
						EditorGUI.indentLevel --;
						GUILayout.Space(5);
					}
					
					
					targetEZParallaxObjectElement.spawnsDuplicateOnX = EditorGUILayout.Toggle("Spawn Duplicates on X", targetEZParallaxObjectElement.spawnsDuplicateOnX);
					if(targetEZParallaxObjectElement.spawnsDuplicateOnX)
					{
						EditorGUI.indentLevel ++;
						if(!targetEZParallaxObjectElement.randomSpawnX)
						{
							targetEZParallaxObjectElement.initialSpawnDistanceX = EditorGUILayout.FloatField(new GUIContent("Units Between Dupes", "This will be the fixed space between each object. This value will be ignored if randomized distance is enabled."), targetEZParallaxObjectElement.spawnDistanceX);	
						}
						targetEZParallaxObjectElement.randomSpawnX = EditorGUILayout.Toggle("Randomize Distance", targetEZParallaxObjectElement.randomSpawnX);
						
						if(targetEZParallaxObjectElement.randomSpawnX)
						{
							EditorGUI.indentLevel ++;
							targetEZParallaxObjectElement.initialSpawnDistanceMinX = EditorGUILayout.FloatField(new GUIContent("Min Units Between", "The shortest distance between objects spawned from this element."), targetEZParallaxObjectElement.spawnDistanceMinX);
							targetEZParallaxObjectElement.initialSpawnDistanceMaxX = EditorGUILayout.FloatField(new GUIContent("Max Units Between", "The largest distance between objects spawned from this element."), targetEZParallaxObjectElement.spawnDistanceMaxX);
							EditorGUI.indentLevel --;
						}
						EditorGUI.indentLevel --;
						GUILayout.Space(5);
					}
					
					EditorGUI.indentLevel --;
					GUILayout.Space(10);
				}
			}
		}
		EditorGUIUtility.LookLikeControls();
		EditorGUILayout.EndVertical();
	}
}