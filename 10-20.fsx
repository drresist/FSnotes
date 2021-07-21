// 10. Error handling


module Errors = 
    open System
    open System.IO

    let readFile (argv:string[]) =
        let filePath = argv.[0]
        if File.Exists filePath then 
            printfn "Processing %s" filePath
            try
                argv
                |> Array.skip 1
                |> Array.iter Console.WriteLine
                
            with
            | :? FormatException as e -> // :? - type test operator, e - is the Exception instance
                printfn "Error is : %s" e.Message
                printfn "File was not in expected format"
            | :? IOException as e -> 
                printfn "Error  is :%s" e.Message
                printfn "Can't access file for reading"
            | _ as e ->  // default case for other errors
                printfn "Error is %s" e.Message

// 11. Generics

module GenericDU = 
    type Optional<'T> = 
        | Something of 'T
        | Nothing
    module Optional = 
        let defaultValue (d : 'T) (optional : Optional<'T>) = 
            match optional with
            | Something v -> v
            | Nothing -> d
module GenericPoints = 
    type Point<'T> =  // 'T - generic 
        {
            X: 'T
            Y: 'T
        }
    module Point = 
        let inline moveBy (dx:'T) (dy:'T) (p:Point<'T>) = 
            {
                X = p.X + dx
                Y = p.Y + dy
            }
    let pFloat = {X = 1.0; Y = 2.0}
    let pFloat2 = pFloat |> Point.moveBy 3.0 4.0
    printfn "pFloat: %A pFloat2: %A" pFloat pFloat2

    let pFloatInt = {X = 1; Y = 2}
    let pFloatInt2 = pFloatInt |> Point.moveBy 3 4
    printfn "pFloatInt: %A pFloatInt2: %A" pFloatInt pFloatInt2