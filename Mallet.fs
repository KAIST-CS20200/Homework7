namespace CS220

/// Mallet event. For simplicity, we assume that we always hit something for
/// every epoch.
type MalletEvent =
  | Hit of Position

/// Stream of MalletEvents.
type MalletEventStream = seq<MalletEvent>

module MalletEventStream =
  /// Create an infinite stream of MalletEvents. This stream internally uses the
  /// PositionStream, and the seed to the PositionStream is given by the seed
  /// parameter of this function.
  let create (seed: int): MalletEventStream =
    failwith "Implement" // REMOVE this line when you implement your own code
