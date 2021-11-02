**Left Rotation**  

A left rotation operation on an array of size shifts each of the array's elements unit to the left. For
example, if **2** left rotations are performed on array [1, 2, 3, 4, 5] , then the array would become [4, 3, 5, 2, 1].  

Given an array of *n* integers and a number, *d* , perform *d* left rotations on the array. Then print the updated
array as a single line of space-separated integers.  

**Input Format**   
The first line contains two space-separated integers denoting the respective values of (the number of
integers) and (the number of left rotations you must perform).
The second line contains space-separated integers describing the respective elements of the array's initial
state.  

**Output Format**  
Print a single line of space-separated integers denoting the final state of the array after performing left
rotations.    

**Sample Input**  
```
5 4  
1 2 3 4 5  
```
**Sample Output**  
```
5 1 2 3 4
```
Explanation
When we perform left rotations, the array undergoes the following sequence of changes: ![image](https://user-images.githubusercontent.com/48887571/139948811-1e4c144a-6435-4558-b31e-ccf1a52c54c2.png)

Thus, we print the array's final state as a single line of space-separated values, which is 5 1 2 3 4 .
