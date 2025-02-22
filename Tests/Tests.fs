namespace CS220

open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =
  member private __.CheckEquality<'T> stream ans =
    List.fold (fun stream (x: 'T) ->
      let y, stream = Seq.head stream, Seq.tail stream
      Assert.AreEqual<'T> (x, y)
      stream) stream ans |> ignore

  [<TestMethod; Timeout 1000; TestCategory "1">]
  member __.``Problem 1.A``() =
    let stream = PositionStream.create 0
    let ans = [ 4; 3; 3; 4; 2; 6; 5; 2; 4 ]
    __.CheckEquality<int> stream ans

  [<TestMethod; Timeout 1000; TestCategory "1">]
  member __.``Problem 1.B``() =
    let stream = PositionStream.create 220
    let ans = [ 3; 4; 7; 5; 0; 2; 1; 5; 6 ]
    __.CheckEquality<int> stream ans

  [<TestMethod; Timeout 1000; TestCategory "2">]
  member __.``Problem 2.A``() =
    let stream = MoleEventStream.create 3u 0
    let ans =
      [ Popup 4; NothingHappened; NothingHappened; Popup 3; NothingHappened
        NothingHappened; Popup 3; NothingHappened; NothingHappened ]
    __.CheckEquality<MoleEvent> stream ans

  [<TestMethod; Timeout 1000; TestCategory "2">]
  member __.``Problem 2.B``() =
    let stream = MoleEventStream.create 3u 12345
    let ans =
      [ Popup 5; NothingHappened; NothingHappened; Popup 2; NothingHappened
        NothingHappened; Popup 4; NothingHappened; NothingHappened ]
    __.CheckEquality<MoleEvent> stream ans

  [<TestMethod; Timeout 1000; TestCategory "2">]
  member __.``Problem 2.C``() =
    let stream = MoleEventStream.create 1u 12345
    let ans =
      [ Popup 5; Popup 2; Popup 4; Popup 3; Popup 3; Popup 0; Popup 4; Popup 7
        Popup 5 ]
    __.CheckEquality<MoleEvent> stream ans

  [<TestMethod; Timeout 1000; TestCategory "2">]
  member __.``Problem 2.D``() =
    let stream = MoleEventStream.create 9u 12345
    let ans =
      [ Popup 5; NothingHappened; NothingHappened; NothingHappened
        NothingHappened; NothingHappened; NothingHappened; NothingHappened
        NothingHappened ]
    __.CheckEquality<MoleEvent> stream ans

  [<TestMethod; Timeout 1000; TestCategory "2">]
  member __.``Problem 2.E``() =
    let stream = MoleEventStream.create 1u 1
    let ans =
      [ Popup 6; Popup 1; Popup 8; Popup 6; Popup 0; Popup 0; Popup 1
        Popup 0; Popup 6; Popup 0; Popup 5; Popup 6; Popup 1; Popup 4
        Popup 2; Popup 6; Popup 6; Popup 8; Popup 1; Popup 7; Popup 3 ]
    __.CheckEquality<MoleEvent> stream ans

  [<TestMethod; Timeout 1000; TestCategory "3">]
  member __.``Problem 3.A``() =
    let stream = MalletEventStream.create 0
    let ans =
      [ Hit 4; Hit 3; Hit 3; Hit 4; Hit 2; Hit 6; Hit 5; Hit 2; Hit 4 ]
    __.CheckEquality<MalletEvent> stream ans

  [<TestMethod; Timeout 1000; TestCategory "3">]
  member __.``Problem 3.B``() =
    let stream = MalletEventStream.create 31337
    let ans =
      [ Hit 5; Hit 3; Hit 1; Hit 4; Hit 4; Hit 8; Hit 6; Hit 4; Hit 3 ]
    __.CheckEquality<MalletEvent> stream ans

  [<TestMethod; Timeout 1000; TestCategory "3">]
  member __.``Problem 3.C``() =
    let stream = MalletEventStream.create 2
    let ans =
      [ Hit 8; Hit 8; Hit 6; Hit 6; Hit 7; Hit 3; Hit 6; Hit 7; Hit 6
        Hit 0; Hit 6; Hit 5; Hit 8; Hit 6; Hit 4; Hit 2; Hit 0; Hit 8
        Hit 3; Hit 3; Hit 3 ]
    __.CheckEquality<MalletEvent> stream ans

  [<TestMethod; Timeout 1000; TestCategory "4">]
  member __.``Problem 4.A``() =
    let moles = MoleEventStream.create 3u 0
    let mallets = MalletEventStream.create 0
    let score: uint32 = Score.compute moles mallets 9u
    Assert.AreEqual<uint32> (1u, score)

  [<TestMethod; Timeout 1000; TestCategory "4">]
  member __.``Problem 4.B``() =
    let moles = MoleEventStream.create 3u 12345
    let mallets = MalletEventStream.create 31337
    let score: uint32 = Score.compute moles mallets 9u
    Assert.AreEqual<uint32> (2u, score)

  [<TestMethod; Timeout 1000; TestCategory "4">]
  member __.``Problem 4.C``() =
    let moles = MoleEventStream.create 1u 12345
    let mallets = MalletEventStream.create 31337
    let score: uint32 = Score.compute moles mallets 9u
    Assert.AreEqual<uint32> (3u, score)

  [<TestMethod; Timeout 1000; TestCategory "4">]
  member __.``Problem 4.D``() =
    let moles = MoleEventStream.create 1u 12345
    let mallets = MalletEventStream.create 12345
    let score: uint32 = Score.compute moles mallets 9u
    Assert.AreEqual<uint32> (9u, score)

  [<TestMethod; Timeout 1000; TestCategory "4">]
  member __.``Problem 4.E``() =
    let moles = MoleEventStream.create 1u 1
    let mallets = MalletEventStream.create 2
    let score: uint32 = Score.compute moles mallets 21u
    Assert.AreEqual<uint32> (10u, score)