# 3D-Scatter-Plot-Unity
An interactive 3D scatter plot created in unity

** Initial commit : Read Iris-test.csv file and show data points with different coordinates, size and colors on the 3D space

- CreatePlot.cs : Reads the CSV file via CSVReader.cs script. Creates DataPoint objects(with different positions, size and colors) and places them on the world as 3D Spheres.

- CreatePlanes.cs : Creates three planes on the world. ( XY, XZ, and YZ)

- Grid.cs : Applies the grid on the planes.


** Update : Added mouse click property to the points which currently prints the point information to the console. ( This will be updated to show a panel on click)
- PointClicker.cs is attached to each point object. 


** Update : Panel is added. When data points are clicked, the panel will be shown in the middle of the screen. When clicked away from the panel, it will close. Left and Right arrow buttons on the panel will help navigate between data points.
Data points will animate when selected.
- PanelControl.cs controls the panel operations.
- ClickAwayDetector.cs detects the clicks outside of panel.
- PointAnimator.cs animates the active game object(data point)
