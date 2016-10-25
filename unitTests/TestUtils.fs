module TestUtils




let arrayEq arr1 arr2 = 
    let ls1 = arr1 |> Array.toList
    let ls2 = arr2 |> Array.toList
    ls1 = ls2


