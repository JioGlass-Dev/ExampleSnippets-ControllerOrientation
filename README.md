# Controller Orientation
An example scene of controlling gameobject by using controller orientation.

## Summary
This project have detailed scene for controlling the orientation of GameObject (bow) with the help of JioGlass controller

## Scripts 

### Class ControllerOrientation
Move and orient the object with the controller.</br>
- To get controller orientation
```cs
Quaternion controllerOrientation = Quaternion.identity;
try
{
     source.TryGetPointerRotation(out controllerOrientation);
}
```

## How to use
Steps to follow:
1. Download and unzip this project.
2. Open the project using Unity Hub.
3. Download and import the latest version of JMRSDK package.
4. Open and play the ControllerOrientation scene from Assets/Scenes folder.
