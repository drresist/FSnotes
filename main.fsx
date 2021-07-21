// Notes during FSharp learning

// 1. Conditional branching

open Main.PatternMatching
open Microsoft.VisualBasic.FileIO

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


// 8. DUs
module DUs =

    // If need to update operations type and we add additional type (create)
    // then compiler inform us that we need to update our "match" function
    type Operations =
        | Insert
        | Delete
        | Update of string
    
    let fromString (s:string) =
        if s = "I" then
            Insert
        elif s = "D" then
            Delete
        else
            let val = s |> string
            Update val
        
        let tryParseResult (operations : Operations) =
            match operations with
            | Insert -> Some "Insert COMMAND"
            | Delete -> Some "Delete COMMAND"
            | Update val -> Some val

// 9. Pattern matching
module PatternMatching =
    
    let numOfCars n =
        match n with
        | 1 -> "One car"
        | 2 -> "Two cars"
        | _ -> $"%i{n} cars" //default case. Wildcard pattern, that matches anything
    
    module OptionType =
        let describe x =
            match x with
            | Some v -> sprintf "Value was %O" v // %O - non type-specific format spec 
            | None -> sprintf "No value"
        // test module
    printfn "---"
    printfn "%s" (Some 99 |> OptionType.describe)
    printfn "%s" (Some "abc" |> OptionType.describe)
    printfn "%s" (Some None |> OptionType.describe)
    
    module Arrays =
        let describe a =
            match a  with
            | [||] -> "Empty"
            | [|x|] -> sprintf "Array with one element %O" x
            | [|x;y|] -> sprintf "Array with two elements %O %O" x y
            | _ -> sprintf "Array with %i elements." a.Length
        
        let anonRecordTypes (s:string) =
            let vals = s.Split(',')
            match vals with
            | [|x;y|] ->
                {|X = x.Trim()
                  Y = y.Trim()|}
            | [|x|] ->
                {|X = x.Trim()
                  Y = "NONE"|}
            | _ -> raise (System.FormatException(sprintf "Invalid format : %s" s))