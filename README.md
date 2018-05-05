# MandelbrotSet
A C# Windows Forms application to create Mandelbrot Sets.  
  
## Roadmap
- [ ] Add rulers to the bottom and left side.
- [ ] Export .png image of a user desired portion of the Mandelbrot Set with a custom resolution  
  
## Understanding the code
> ## What is a complex number?
> A complex number is a number expressed in the form a + bi where *a* and *b* are real numbers and *i* is an "imaginary number". For example 7 + 3*i* where *i* could be ![](https://latex.codecogs.com/svg.latex?\sqrt{-1})

```c#
  double c_real = ((pixelCoords.X - bitmapWidth / 2) * planeWidth / bitmapWidth)
      + planeCentre.X;

  double c_im = ((pixelCoords.Y - bitmapHeight / 2) * planeHeight / bitmapWidth)
      + planeCentre.Y;

  // If you don't understand this code Look at the README.
  double z_real = 0;
  double z_im = 0;

  int iteration = 0;

  while (z_real * z_real + z_im * z_im < 4 && iteration < MAX_ITERATIONS)
  {
      double z_real_tmp = z_real * z_real - (z_im * z_im) + c_real;

      z_im = 2 * z_real * z_im + c_im;
      z_real = z_real_tmp;

      iteration++;
  }
```

### How do you multiply complex numbers?
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
