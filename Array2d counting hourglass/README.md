Given a *6x6*  2D Array, : *arr*:  
```
1 1 1 0 0 0  
0 1 0 0 0 0  
1 1 1 0 0 0  
0 0 0 0 0 0  
0 0 0 0 0 0  
0 0 0 0 0 0  
```

An hourglass is a subset of values with indices falling in this pattern in *arr*'s graphical representation:  
``` 
a b c
  d  
e f g
```  

There are **16** hourglasses in *arr* . An hourglass sum is the sum of an hourglass' values. Calculate the hourglass sum for every hourglass in *arr*, then print the maximum hourglass sum. The array will always be *6x6*.  

**Example**

```
arr = {
 -9 -9 -9  1 1 1 
  0 -9  0  4 3 2
 -9 -9 -9  1 2 3
  0  0  8  6 6 0
  0  0  0 -2 0 0
  0  0  1  2 4 0
}
```

**16 sums are**  

```
-63, -34, -9, 12, 
-10,   0, 28, 23, 
-27, -11, -2, 10, 
 9,  17, 25, 18
 ```
 
 **The highest hourglass sum is 28**  
 
 ```
 0 4 3
   1
8 6 6
```
 
 **Function Description**

hourglassSum has the following parameter(s):

* int arr[6][6]: an array of integers

**Returns**
* int: the maximum hourglass sum
