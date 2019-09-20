# 3D-Scatter-Plot-Unity
An interactive 3D scatter plot created in unity

** Initial commit : Read Iris-test.csv file and show data points with different coordinates, size and colors on the 3D space

- CreatePlot.cs : Reads the CSV file via CSVReader.cs script. Creates DataPoint objects(with different positions, size and colors) and places them on the world as 3D Spheres.

- CreatePlanes.cs : Creates three planes on the world. ( XY, XZ, and YZ)

- Grid.cs : Applies the grid on the planes.


** Update : Added mouse click property to the points which currently prints the point information to the console. ( This will be updated to show a panel on click)
- PointClicker.cs is attached to each point object. 