module CS220.Program

/// Read the README.md before you proceed.
[<EntryPoint>]
let main _args =
  let molestream = MoleEventStream.create 3u 1
  let malletstream = MalletEventStream.create 0
  Score.compute molestream malletstream 20u |> printfn "%d"
  0
