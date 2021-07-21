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