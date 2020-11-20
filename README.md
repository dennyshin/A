# A
keeping track of my unity progress

Unity 2020.1.1f1

Visual Studio Community 2019 Version 16.7.0

Microsoft .NET Framework Version 4.8.03752



## Cube and Plane
By default, Camera and Directional Lights are made

In the Hierarchy:  
right-click -> 3D Object -> Plane  
right-click -> 3D Object -> Cube

In the Project:  
right-click -> Create -> Material (one each for the cube and plane)

Select a colour for each material to make it easier on the eye.  
Drag each material to the 3D Object to apply.


### Cube Script
In the Project:  
right-click -> Create -> C# Script

By following this [video](https://www.youtube.com/watch?v=rnqF6S7PfFA) we can set specific keyboard inputs to control the cube with WASD. The video tutorial is for camera control but it will work just the same for the cube. For the camera, we can control it using the arrow keys. Below is the first iteration of the Cube Script. Later, we can change this to move with mouse clicks instead.
```CSharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float moveSpeed;
    public float moveTime;

    public Vector3 newPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1f;
        moveTime = 10f;
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += (transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition += (transform.forward * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPosition += (transform.right * -moveSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveTime);
    }
}
```

First, the variables:  
moveSpeed and moveTime are not strictly neccessary. But they do allow us to control the cube's speed much more easily. More detail when we talk about transform.forward, transform.right and Lerp.  
newPosition we will use to determine our target location.

Now, a small side note:  
inside void Start() we set the starting values for our variables. If we don't do this, every time we "play" the game, it will default back to 0. You can change the values in the Unity editor, but I don't like this at all. Also, setting default variable values will also not work (I don't know if this is strictly because we are CSharp for Unity). So, the below code will NOT set the moveSpeed and moveTime values when we play. Again, I don't know why.
```CSharp
public float moveSpeed = 1f;
public float moveTime = 10f;

void Start()
{
    
}
```

So, inside Start:  
We set the default values for moveSpeed and moveTime. Play around with these in the editor to get a good feeling for what they change. newPosition is set to the Cube's location we set in the Unity Editor. You can see the syntax is quite nice, as it follows the inspector from Unity Editor. The Cube (because we attached our script as a component of our 3D Object Cube), its "transform" and then its "position".
```CSharp
void Start()
{
    moveSpeed = 1f;
    moveTime = 10f;
    newPosition = transform.position;
}
```

You can also try printing things before and after you set the variables to see what happens. Like this:
```CSharp
print(transform.position);
print(newPosition);
newPosition = transform.position;
print(newPosition);
```

Next:  
We will create a new method HandleMovementInput and call this method every frame using Update. Now, of course you could chuck all it directly into Update, but this will help us keep track in the future if/when we want to add even more things.

transform.forward is like calling Vector3.forward which is essentiall (0,0,1). But, transform.forward will also take into consideration the object's rotation. So it will move "forward" relative to its own z-axis rather than the world's z-axis. The same can be done with transform.right. Multiplying by moveSpeed allows us to easily control how fast the cube will move. Try removing the moveSpeed from the W input, adjust moveSpeed while you play and see how the cube moves. Like this: (VS will yell at you to fix the formatting but you can ignore it for now)
```CSharp
if(Input.GetKey(KeyCode.UpArrow))
{
    newPosition += (transform.forward);
}
if (Input.GetKey(KeyCode.DownArrow))
{
    newPosition += (transform.forward * -moveSpeed);
}
if (Input.GetKey(KeyCode.RightArrow))
{
    newPosition += (transform.right * moveSpeed);
}
if (Input.GetKey(KeyCode.LeftArrow))
{
    newPosition += (transform.right * -moveSpeed);
}
```

Input.GetKey returns True if the key is held down. This lets us do diagonal movement. I'm not sure what I would call instead if I DIDN'T want diagonal movement.

Vector3.Lerp(A, B, t) returns back a Vector3. Imagine a line going through A and B. Lerp will return a point on that line depending on t. Now, t is set to Time.deltaTime in a lot of tutorials. I am not 100% sure why or how it works, but it lets us have "smooth" movement when fps fluctuates. But I am yet to find a good example/demonstration online.

In a practical setting, we can kiiiinda ignore Time.deltaTime and just trust that it works. Try removing Time.deltaTime and adjusting moveTime to see the effects. You can see we can sort of "cheat" and simulate momentum with small values of moveTime.


### Camera Controller Script
