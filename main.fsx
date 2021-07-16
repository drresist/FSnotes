// Notes during FSharp learning

// 1. Conditional branching
module Conditional = 
    let conditionalBranching (argv:string[]) = 
        let simpleString = argv.[0] // first element of argv array
        printfn $"Hello %s{simpleString}" 
        // check that argv not empty
        let checkedString = 
            if argv.Length > 0 then
                argv.[0]
            else
                "(EMPTY)"
        0 // return something

// 2. Loops and iterations
module Iterations = 
    let iterations (argv:string[]) = 
        for str in argv do 
            printfn $"%s{str}"
        let sayHello person =
            printfn $"Hello %s{person}"
        // Iter with function
        Array.iter sayHello argv // higher order function * 

// 3. Forward piping
module Piping =
    open System
    let isValid str = not(String.IsNullOrWhiteSpace str)
    let sayHello str = printfn $"Hello %s{str}"
    let fwPiping (argv:string[]) =
        let valid = argv  |> Array.filter isValid  // check that values not null and return valid array
        // Pipeline
        argv
        |> Array.filter isValid
        |> Array.iter sayHello 
        0
// 4. Collection functions
module CollectionsFunc =
    open System
    let isValid str = not(String.IsNullOrWhiteSpace str)
    let collectionFunctions (argv:string[]) = 
        let count = (argv |> Array.length) - 1 
        argv
        |> Array.skip 1
        |> Array.filter isValid
        |> Array.map float // iter through elems and use func tp all elements