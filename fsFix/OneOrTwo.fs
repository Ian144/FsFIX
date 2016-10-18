module OneOrTwo


// the NoLegs group has either 1 or 2 elements, 
// enforce at compile time with this container

type OneOrTwo<'a> =
    | One of 'a 
    | Two of 'a * 'a


let iter func oneTwo  : Unit = 
    match oneTwo with
    | One t1        -> func t1
    | Two (t1,t2)   -> func t1; func t2


