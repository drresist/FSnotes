// Notes during FSharp learning

// 1. Conditional branching

let conditionalBranching (argv:string[]) = 
    let simpleString = argv.[0] // first element of argv array
    printfn "Hello %s" simpleString 
    // check that argv not empty
    let checkedString = 
        if argv.Length > 0 then
            argv.[0]
        else
            "(EMPTY)"
    0 // return something

// 2. Loops and iterations

let iterations (argv:string[]) = 
    for str in argv do 
        printfn "%s" str
    let sayHello person =
        printfn "Hello %s" person
    // Iter with function
    Array.iter sayHello argv // higher order function * 

// 3. Forward piping
open System
let fwPiping (argv:string[]) =
    let isValid str = not(String.IsNullOrWhiteSpace str)
    let sayHello str = printfn "Hello %s" str
    let valid = argv  |> Array.filter isValid  // check that values not null and return valid array
    // Pipeline
    argv
    |> Array.filter isValid
    |> Array.iter sayHello 
    0
// 4. Collection functions 
let collectionFuncs (argv:string[]) = 
    let count = (argv |> Array.length) - 1 
    let isValid str = not(String.IsNullOrWhiteSpace str)
    argv
    |> Array.skip 1
    |> Array.filter isValid
    |> Array.map float // iter through elems and use func tp all elements