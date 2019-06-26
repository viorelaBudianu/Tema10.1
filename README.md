# Tema10.1

**Problem 1. Generic class
Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString().
Check all input parameters to avoid accessing elements at invalid positions.
  
**Problem 2. Auto-grow
Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

**Problem 3. Min and Max
Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
You may need to add a generic constraints for the type T.
  
**Problem 4. Matrix
Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).
  
**Problem 5. Matrix indexer
Implement an indexer this[row, col] to access the inner matrix cells.

**Problem 6. Matrix operations
Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
Throw an exception when the operation cannot be performed.
Implement the true operator (check for non-zero elements).
