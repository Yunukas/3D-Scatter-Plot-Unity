# 3D-Scatter-Plot-Unity
An interactive 3D scatter plot created in unity

#### Initial commit : 
Read Iris-test.csv file and show data points with different coordinates, size and colors on the 3D space

- ScatterPlot.cs : Reads the CSV file via CSVReader.cs script. Creates DataPoint objects(with different positions, size and colors) and places them on the world as 3D Spheres.
- CreatePlanes.cs : Creates three planes on the world. ( XY, XZ, and YZ)
- Grid.cs : Applies the grid on the planes.


#### Update : 
Added mouse click property to the points which currently prints the point information to the console. ( This will be updated to show a panel on click)
- PointClicker.cs is attached to each point object. 


#### Update : 
Panel is added. When data points are clicked, the panel will be shown in the middle of the screen. When clicked away from the panel, it will close. Left and Right arrow buttons on the panel will help navigate between data points.
Data points will animate when selected.
- PanelControl.cs controls the panel operations.
- ClickAwayDetector.cs detects the clicks outside of panel.
- PointAnimator.cs animates the active game object(data point)

#### Update : 
Camera controller is added. Viewer can move around the scene with keyboard and mouse inputs.
- RTS_Camera.cs handles the camera movements. If panel is active when camera is moved, panel will close.

#### Update :
Loading scene is added. Input file is read by a coroutine and added to a static data store to be shared with other scenes.
After file is parsed, a transition happens to the main scene.
Plane labels are added, (XY, YZ, XZ planes)
- Loader.cs parses the input file with a coroutine. This coroutine creates a thread to read the input file. 
- Spinner.cs spins the loading circle.
