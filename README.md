CS220 - HW7
===

## Introduction

In this homework, you are going to write a simulator for a [whac-a-mole
game](https://en.wikipedia.org/wiki/Whac-A-Mole). To simulate the game, you will
use infinite streams of game events. In our model, we split time into a sequence
of epochs, and we obtain two distinct events for every epoch.

#### Basic Setting

We assume 3x3 grid for the game. The grid is represented as follows.

```
 1 | 2 | 3
---+---+---
 4 | 5 | 6
---+---+---
 7 | 8 | 9
```

#### Position Stream

Your goal here is to implement the `create` function in Position.fs.
PositionStream is an infinite stream of pseudo-random positions (from 1 to 9).
We use a linear congruential generator where its state is updated with the
following algorithm:
```
nextState := (214013 * currentState + 2531011) % (2^31)
r := nextState % 9
```
This stream always returns a new `r` value while updating its internal state
using the above formula.

#### Mole Event Stream

A mole event (MoleEvent) represents an event for a mole. We assume that only one
(out of 9) mole can appear at each epoch. There are two types of mole events:
(1) one of the moles appears, and (2) none of them appears. When a mole is
popped up at epoch `t`, it will disappear at epoch `t+3`. Therefore, a player
can hit the mole only during three epochs (i.e., `t`, `t+1`, and `t+2`). When a
pop-up event occurs for the same mole at `t` and `t+1`, then the mole will
disappear at `t+4`.

This is an infinite stream, which internally uses a `PositionStream` to create a
random position. The `MoleEventStream.create` function takes in two parameters
as input: `freq` and `seed`. The `freq` parameter decides how often a pop-up
event should be generated. If `freq` is 3, it means that the resulting stream
will have a pop-up event every 3 epochs, i.e., 1st, 4th, 7th, 10th, and so on.
The `seed` parameter is passed directly to a `PositionStream` to decide the next
pop-up position.

#### Mallet Event Stream

A mallet event (MalletEvent) represents an action of a player (i.e., hitting a
mole with a mallet). For simplicity, we assume that the player will always hit
something for every epoch (no miss!).

The `MalletEventStream.create` function takes in a seed as input, and returns an
infinite stream of mallet events. The function internally possesses a
`PositionStream` to randomly generate hitting positions. The `seed` parameter is
passed directly to the `PositionStream` to decide the next hitting position.

#### Scoring

The `Score.compute` function computes the score of a player using the two event
streams described earlier. We simply assume that we always receive one event
from both `MoleEventStream` and `MalletEventStream` for every epoch. This way,
we can easily simulate the whole game in an elegant way without having to rely
on mutable states.

The function takes in as input the number of epochs to simulate,
`MoleEventStream`, and `MalletEventStream`. And it returns a score (`uint32`) as
output. A mole is activated for three epochs as described above. Thus, if there
is a hit on the mole within three epochs, the player gets +1 point. Let's
consider the following scenario with 10 epochs.

```
         -------------------------------->
epochs:   t1 t2 t3 t4 t5 t6 t7 t8 t9 t10
mallet:    1  2  3  4  5  6  7  8  9   3
mole:      9  8  7  6  5  4  3  2  1   9
hit?                   o  o
```

In this first epoch, the 9th mole has popped up, and the player hit the first
hole. In the second epoch, the 8th mole has popped up, and the player hit the
second hole. We can see that player earned points at `t5` and `t6`. At `t5` the
player hit "mole 5" as soon as it popped up as we assume that if both mallet and
mole event occur at the same epoch, the player gets a point.

## Build?

You can compile the project by typing `dotnet build`.

## Test?

You can test your implementation by typing `dotnet test`. If you can pass
all the tests, you should be good to commit and push your code.

## Structure

- `Program.fs`: The main entry point of the project.
- `Tests/Tests.fs`: The test suite for the project.
- `HomeworkX.fsproj`: The F# project file for the project, where `X` is the
  homework number.

## Problems

You should read the fsproj file and read the relevant source files to understand
the problems. Typically, we will provide an empty (or partial) implementation
for you to fill in where you can find some comments describing the problem. Of
course, you can also read the relevant test cases to understand the problem.

## Submission

You are given a GitHub classroom link to start the assignment, which will
automatically create a private repository for you. If your repository URL
contains your GitHub username, then you are in the right place. If not, please
get your own private repository from the GitHub classroom link.

You should make modification to your own repository to finish your homework.
Again, your own repository is only visible to you and the course staff. Plus,
your repository URL should contain your GitHub username. You should commit and
push your code to your own repository in order to get a grade.

Whenever you push your code to your repository, the GitHub classroom workflow
will automatically run the test cases and give you a grade based on the test
results. You can check the test results by clicking the "Actions" tab in your
repository page.

If you see a red cross in the "Actions" tab, it means that some of the test
cases are failing. You should check the test results to understand why the test
cases are failing. If you see a green check, it means that all the test cases
are passing, and you should be good to go.

You can always make another commit to fix problems in your implementation, and
push the changes to the repository. The GitHub classroom workflow will
re-evaluate your implementation and update your grade.

## Failure from the Workflow?

Don't panic if you see a red cross in the "Actions" tab. You can always make
another commit to fix problems in your implementation, and push the changes to
the repository. The GitHub classroom workflow will re-evaluate your
implementation and update your grade automatically.

## Auto-Grading?

Auto-grading is performed via the GitHub classroom workflow, which is defined in
`.github/workflows/classroom.yml`. The workflow basically runs `dotnet test` to
test your implementation and then gives you a grade based on the test results.
If you can pass all the tests in your local environment, you should be able to
get a full score.

## Cheating Policy

One may exploit the automatic grading system by hardcoding the expected result
in the test cases --- that is, one can simply add if-then-else statements in the
program to pass all the tests. But, we consider this attempt as cheating.

If we detect any cheating attempt (including but not limited to the one above),
we will immediately give you an F grade for the course, and report the case to
the department.

## Solutions?

There is no single correct solution to the problems. You can always come up with
your own solution as long as it can pass the test cases. If you have any
questions about the problems, feel free to write an issue in the
[main](https://github.com/KAIST-CS220/CS220-Main) repository. But please do
search the existing issues to see if your question has already been answered
before writing a new one.
