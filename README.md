# MandelbrotSet
A C# Windows Forms application to create Mandelbrot Sets.  
  
## Roadmap
- [ ] Add rulers to the bottom and left side.
- [ ] Export .png image of a user desired portion of the Mandelbrot Set with a custom resolution  
  
## Understanding the code  

> ### What is a complex number?
> A complex number is a number expressed in the form a + bi where *a* and *b* are real numbers and *i* is an "imaginary number". For example 7 + 3*i* where *i* could be ![](https://latex.codecogs.com/svg.latex?\sqrt{-1})

> ### The algorithm
> ![](https://latex.codecogs.com/svg.latex?z_%7Bn&plus;1%7D%20%3D%20z_%7Bn%7D%5E%7B2%7D%20&plus;%20c)  
> *c* and *z* are complex numbers.

### How do you write the algorithm in code?
In the following example, *i* = ![](https://latex.codecogs.com/svg.latex?%5Csqrt%7B-1%7D).
IGNORE i in code
```c#
      while (z_real * z_real + z_im * z_im < 4 && iteration < MAX_ITERATIONS)
      {
        double z_real_tmp = z_real * z_real - (z_im * z_im) + c_real;

        z_im = 2 * z_real * z_im + c_im;
        z_real = z_real_tmp;
      }
```

![](https://latex.codecogs.com/svg.latex?Z%7B_%7Br%7D%7D) (z_real) is derived from ![](https://latex.codecogs.com/svg.latex?Z%7B_%7Br%7D%7D%5E%7B2%7D%20-%20Z%7B_%7Bi%7D%7D%5E%7B2%7D%20&plus;%20C_%7Br%7D).  
![](https://latex.codecogs.com/svg.latex?Z%7B_%7Bi%7D%7D) (z_im) is derived from ![](https://latex.codecogs.com/svg.latex?2*Z_%7Br%7D*Z_%7Bi%7D&plus;C_%7Bi%7D).  

For example, where ![](https://latex.codecogs.com/svg.latex?Z_%7B1%7D) (the first iteration of Z) and C are ![](https://latex.codecogs.com/svg.latex?%283%20&plus;%204i%29)...

![](https://latex.codecogs.com/svg.latex?z_%7B2%7D%3Dz%7B_%7B1%7D%7D%5E%7B2%7D&plus;c)  
![](https://latex.codecogs.com/svg.latex?z_%7B2%7D%3D%283&plus;4i%29%5E2%20&plus;%20%283&plus;4i%29)  
![](https://latex.codecogs.com/svg.latex?z_%7B2%7D%3D%283&plus;4i%29%283&plus;4i%29%20&plus;%20%283&plus;4i%29)  
![](https://latex.codecogs.com/svg.latex?z_%7B2%7D%3D9&plus;12i&plus;12i&plus;16i%5E2%20&plus;%20%283&plus;4i%29)  
![](https://latex.codecogs.com/svg.latex?z_%7B2%7D%3D9&plus;24i&plus;16i%5E2%20&plus;%20%283&plus;4i%29)  

![](https://latex.codecogs.com/svg.latex?16i%5E2%20%3D%20-16) because...  
![](https://latex.codecogs.com/svg.latex?16i%5E2%20%3D%2016%5Csqrt%7B-1%7D%5E2)  
![](https://latex.codecogs.com/svg.latex?%3D%2016%20*%20-1)  
![](https://latex.codecogs.com/svg.latex?%3D%20-16)  

Therefore...  

![](https://latex.codecogs.com/svg.latex?z_%7B2%7D%20%3D%209%20&plus;%2024i%20-16%20&plus;%20%283&plus;%204i%29)  
![](https://latex.codecogs.com/svg.latex?z_%7B2%7D%20%3D%20-7%20&plus;%2024i%20&plus;%20%283&plus;%204i%29)  
![](https://latex.codecogs.com/svg.latex?z_%7B2%7D%20%3D%20-7%20&plus;%2024i%20&plus;%203&plus;%204i)  
![]()


### Using a ComplexNumber class
```c#
  // Convert the pixel coordinate to the equivalent coordinate on the given portion of the complex plane.
  double c_real = ((pixelCoords.X - bitmapWidth / 2) * planeWidth / bitmapWidth)
      + planeCentre.X;

  double c_im = ((pixelCoords.Y - bitmapHeight / 2) * planeHeight / bitmapWidth)
      + planeCentre.Y;

  var z = new ComplexNumber(0,0);
  var c = new ComplexNumber(c_real, c_im);
            
  int iteration = 0;
  
  while (z.Normal < 4 && iteration < MAX_ITERATIONS)
  {
      z = z * z + c;

      iteration++;
  }
```

### How do you multiply two complex numbers?
For example, If we multiply out these brackets and simplify where *i* = ![](https://latex.codecogs.com/svg.latex?%5Cinline%20%5Csqrt%7B-1%7D)

![](https://latex.codecogs.com/svg.latex?%5Cinline%20%284%20&plus;%203i%29%282%20&plus;%202i%29)  
![](https://latex.codecogs.com/svg.latex?%5Cinline%208%20&plus;%208i%20&plus;%206i%20&plus;%206i%5E%7B2%7D)  
![](https://latex.codecogs.com/svg.latex?%5Cinline%208%20&plus;%2014i%20&plus;%206i%5E%7B2%7D)  

And since we know that *i* is an imaginary number which is is the square-root of a real number.  
![](https://latex.codecogs.com/svg.latex?%5Cinline%206i%5E%7B2%7D)  
= ![](https://latex.codecogs.com/svg.latex?%5Cinline%206%5Csqrt%7B-1%7D%5E%7B2%7D)  
= ![](https://latex.codecogs.com/svg.latex?%5Cinline%206%20*%20-1)  
= ![](https://latex.codecogs.com/svg.latex?%5Cinline%20-6)

Therefore...  
![](https://latex.codecogs.com/svg.latex?%5Cinline%208%20&plus;%2014i%20&plus;%206i%5E%7B2%7D)  
= ![](https://latex.codecogs.com/svg.latex?%5Cinline%208%20&plus;%2014i%20-6)  
= ![](https://latex.codecogs.com/svg.latex?%5Cinline%202%20&plus;%2014i)

There we go!  
![](https://latex.codecogs.com/svg.latex?%5Cinline%20%284%20&plus;%203i%29%282%20&plus;%202i%29) = ![](https://latex.codecogs.com/svg.latex?%5Cinline%202%20&plus;%2014i)
