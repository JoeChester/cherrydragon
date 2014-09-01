#pragma strict

function Update () {
	var dir : Vector3 = Vector3.zero;

	// we assume that the device is held parallel to the ground
	// and the Home button is in the right hand

	// remap the device acceleration axis to game coordinates:
	//  1) XY plane of the device is mapped onto XZ plane
	//  2) rotated 90 degrees around Y axis
	dir.x = Input.acceleration.x;
	dir.y = Input.acceleration.y;
	dir.z = Input.acceleration.z;

	gameObject.guiText.text = " x:" + dir.x.ToString() + "\n y:" + dir.y.ToString() + "\n z:" + dir.z.ToString();

	
}