module CS220.Score


/// This function computes the score after the number of epochs given. We assume
/// that for every epoch, we have a MoleEventStream and a MalletEventStream. A
/// mole will stay popped up for three epochs. For example, if there was a Popup
/// event at epoch 2 for a mole, then the mole will stay popped up until epoch
/// 4. If there is a MalletEvent for the mole during the period, then a player
/// earns +1 score. When a mole receives another Popup event while it is already
/// popped up, then we simply keep the mole be popped up for the next two more
/// epochs (i.e. we do not add up the epoch counter). If both MoleEvent and
/// MalletEvent of the same position occurred at the same epoch, we also give +1
/// score. To be clear, let us consider the following example. Let t1, t2, ...,
/// tn be n different epochs, and let numbers between 1 and 9 be a position of a
/// hole.
///
///          -------------------------------->
/// epochs:   t1 t2 t3 t4 t5 t6 t7 t8 t9 t10
/// mallet:    1  2  3  4  5  6  7  8  9   3
/// mole:      9  8  7  6  5  4  3  2  1   9
/// hit?                   o  o
///
/// In the above case, the score will become 2 after 10 epochs, because we have
/// hit two moles at epoch t5 and t6. This function should return uint32 as
/// output.
let compute (moles: MoleEventStream)
            (mallets: MalletEventStream)
            (epochs: uint32) =
  failwith "Implement" // REMOVE this line when you implement your own code
