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
        
// 5. Record Types
module RecordTypes = // module - combine functions that have something common (record type)
    open System
    type Student =
            {
                Name : string
                ID : string
                MeanScore : float
            }
    let fromString (s:string) =
        let name = "Maksim"
        let id = "Maksim199"
        let meanScore = 6.7
        {
            Name = name
            ID = id
            MeanScore = meanScore
        }
// 6. Missing data
module MissingData =
    // fn that try parse from string
    let tryFromString (s:string) =
        if s = "N/A" then
            None
        else
            Some (float s) // array.choose using when we use Option type (Some)
    let fromStringOr d s =
        s
        |> tryFromString
        |> Option.defaultValue d  // default value

// 7. args and params
// TODO: need to get a better handle on the currying
module ArgsAndParams =
    let multipleParams (i:int) (s:string) : string = // use i int s string and return string
        let elements = s.Split(',')
        elements.[i].Trim()
    let tupledParams (a,b) =
        a + b
    let sumAB a b =
        a + b
    let sumA3  = // curried func, using only part of args
        sumAB 3
